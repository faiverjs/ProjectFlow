using Microsoft.VisualBasic;
using ProjectFlow.Application.DTOs;
using ProjectFlow.Application.Interfaces;
using ProjectFlow.Domain.Entities;
using ProjectFlow.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace ProjectFlow.Application.Services
{
    public class ProjectService : IProjectService

    {
        private readonly IProjectRepository _projectRepository;
       private readonly IUserRepository _userRepository;
        private readonly IUserProjectRepository _userProjectRepository;

        public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository,
                                IUserProjectRepository userProjectRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _userProjectRepository = userProjectRepository;
        }
        public async Task<ProjectDto> Add(ProjectDto dto)
        {
            var leader = await _userRepository.GetById(dto.LeaderId);

            if (leader == null)
                throw new Exception("El usuario líder no existe.");

            var project = new Project(
                dto.Name,
                dto.Description,
                dto.LeaderId,
                DateTime.UtcNow
            );

            await _projectRepository.Add(project);
            await _projectRepository.SaveChanges();
            //  agregar líder a UserProject
            var userProject = new UserProject(dto.LeaderId, project.Id);
            await _userProjectRepository.Add(userProject);
            await _userProjectRepository.SaveChanges();

            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                LeaderId = project.LeaderId,
                dateCreation = project.DateCreation
            };
        }

        public Task<IEnumerable<Project>> GetProjectsByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectDto?> Remove(Guid id)
        {


            var project = await _projectRepository.GetById(id);
            if (project == null)
                throw new Exception("El projecto no se encuentra registrado");


           var projectDto = new  ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                LeaderId = project.LeaderId

            };
            ///proximamente  hacer que la eliminacion d elo proyecto se a por roles
            //var rolecorrct = await _userRepository.GetById(project.LeaderId);
           // if (rolecorrct.ToString() != "" )

            var userProjects = await _userProjectRepository.GetByProjectId(project.Id);
            foreach (var up in userProjects)
            {
                await _userProjectRepository.Delete(up);
            }
            await _userProjectRepository.SaveChanges();

            await _projectRepository.Delete(project);
            await _projectRepository.SaveChanges();

            return projectDto;

        }

        public async Task<ProjectDto?> update(ProjectDto dto)
        {
            var project = await _projectRepository.GetById(dto.Id);
            if (project == null)
                throw new Exception("El proyecto no se encontro");

            project.Name = dto.Name;
            project.Description = dto.Description;
            project.LeaderId = dto.LeaderId;
            project.DateUpdate = DateTime.UtcNow;

            await _projectRepository.SaveChanges();
            return new ProjectDto
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                LeaderId = dto.LeaderId

            };
        }
    }
}
