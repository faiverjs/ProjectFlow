using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectFlow.Application.DTOs;
using ProjectFlow.Application.Interfaces;
using ProjectFlow.Application.Services;
using ProjectFlow.Domain.Entities;
using ProjectFlow.Domain.Interfaces;

namespace ProjectFlow.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IIssueRepository issueRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICommentRepository commentRepository;
        private readonly IUserService userService;
        private readonly IProjectService projectService;

        public UserController(
            IUserRepository userRepository,
            IIssueRepository issueRepository,
            IProjectRepository projectRepository,
            ICommentRepository commentRepository,
            IUserService userService, IProjectService projectService)
        {
            this.userRepository = userRepository;
            this.issueRepository = issueRepository;
            this.commentRepository = commentRepository;
            this.projectRepository = projectRepository;
            this.userService = userService;
            this.projectService = projectService;
            
        }
        /// <summary>
        ///                             USUARIOS
        /// </summary>

        ///  TOKENS
        ///  Iniciar sesión. Devuelve JWT de acceso y refresh token.
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await userService.Login(dto);
            return Ok(token);
        }

        [HttpGet("getlAll")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var users = await userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetUsersByID(Guid id)
        {
            var user = await userRepository.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        //Registrar nuevo usuario con nombre, email y contraseña.
        [HttpPost("register")]
        public async Task<IActionResult> Add(UserInsertDto userInsertDto)
        {
            var result = await userService.Add(userInsertDto);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<ActionResult<UserDto>> Update(UserDto dto)
        {
            var result = await userService.Update(dto);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await userService.Remove(id);
            return Ok(result);
        }

        /// <summary>
        ///  PROYECTOS
        /// </summary>

        [HttpGet("allprojects")]
        public async Task<IActionResult> GetProject(Guid userId)
        {
            var projects = await projectRepository.GetAll();
            return Ok(projects);
        }
        [HttpGet("listByUser")]
        public async Task<ActionResult<Project>> GetProjectsByUserId(Guid userId)
        {
            var projects = await projectRepository.GetProjectsByUserId(userId);
            return Ok(projects);
        }
        [HttpPost("addProject")]
        public async Task<IActionResult> AddNewProject(ProjectDto dto)
        {
            var result = await projectService.Add(dto);
            return Ok(result);
        }
        [HttpPut("Project/update")]
        public async Task<ActionResult<ProjectDto>> updateProjects(ProjectDto dto)
        {
            var result = await projectService.update(dto);
            return Ok(result);
        }

        /// <summary>
        ///  ISSUES (TAREAS)
        /// </summary>
        [HttpGet("{issue}")]
        public async Task<IActionResult> GetIssues()
        {
            var issues = await issueRepository.GetAll();
            return Ok(issues);
        }
        [HttpGet("{issueID}")]
        public async Task<IActionResult> GetIssuesById(Guid id)
        {
            var issues = await issueRepository.GetById(id);
            return Ok(issues);
        }


        [HttpGet("{project}")]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await projectRepository.GetAll();
            return Ok(projects);
        }
        [HttpGet("{projectID}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var projects = await projectRepository.GetById(id);
            return Ok(projects);
        }



        /// <summary>
        ///  COMENTARIOS
        /// </summary>
        /// 
        [HttpGet("{comments}")]
        public async Task<IActionResult> Getcomments()
        {
            var projects = await commentRepository.GetAll();
            return Ok(projects);
        }
        [HttpGet("{commentsID}")]
        public async Task<IActionResult> GetcommentById(Guid id)
        {
            var projects = await commentRepository.GetById(id);
            return Ok(projects);
        }

    }
}
