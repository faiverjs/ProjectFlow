using System;
using System.Collections.Generic;

namespace ProjectFlow.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid LeaderId { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateUpdate { get; set; }

        // Muchos a muchos con User
        public ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();

        // Relación con el líder (User)
        public User Leader { get; set; }

        //  Un proyecto tiene muchos Issues
        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        private Project() { } 
        public Project(string name, string description, Guid leaderId, DateTime dateCreation)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            LeaderId = leaderId;
            DateCreation = dateCreation; 
        }
    }
}