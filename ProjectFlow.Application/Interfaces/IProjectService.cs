using ProjectFlow.Application.DTOs;
using ProjectFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjectsByUserId(Guid userId);
       Task<ProjectDto> Add( ProjectDto  dto);
        Task<ProjectDto?> Remove(Guid id);
        Task<ProjectDto?> update(ProjectDto dto);
    }
}
