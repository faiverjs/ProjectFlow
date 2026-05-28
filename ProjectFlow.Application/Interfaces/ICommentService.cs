using ProjectFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Application.Interfaces
{
    public interface ICommentService
    {
        Task Add(Comment comment);
        Task Remove(Comment comment);
        Task SaveChanges();
    }
}
