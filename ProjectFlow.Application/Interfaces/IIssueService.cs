using ProjectFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Application.Interfaces
{
    public interface IIssueService
    {
        Task Add(Issue issue);
        Task Remove(Issue issue);
        Task SaveChanges();
    }
}
