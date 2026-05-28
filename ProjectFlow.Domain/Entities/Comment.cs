using System;
using System.Collections.Generic;

namespace ProjectFlow.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateUpdate { get; set; }

        // 🔥 Foreign Keys reales
        public Guid IssueId { get; set; }
        public Guid UserId { get; set; }

        // 🔥 Relaciones de navegación
        public Issue Issue { get; set; }
        public User User { get; set; }

        private Comment() { }

        public Comment(Guid id, string description, Guid issueId, Guid userId)
        {
            Id = id;
            Description = description;
            IssueId = issueId;
            UserId = userId;
            DateCreation = DateTime.UtcNow;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
            DateUpdate = DateTime.UtcNow;
        }
    }
}