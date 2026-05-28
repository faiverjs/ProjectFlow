using ProjectFlow.Application.Interfaces;
using ProjectFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Domain.Interfaces
{
    public interface IProjectRepository: IRepository<Project>
    {
        Task<List<Project>> GetProjectsByUserId(Guid userId);
        /*Task<Project?> GetById(Guid id);
        Task<IEnumerable<Project>> GetAll();*/
       
    }
}
