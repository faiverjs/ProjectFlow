using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Domain.Entities
{
    public class UserProject
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        private UserProject() { }

        public UserProject(Guid userId, Guid projectId)
        {
            UserId = userId;
            ProjectId = projectId;
        }
    }
}
