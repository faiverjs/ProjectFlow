using System;
using System.Collections.Generic;
using BCrypt;
using ProjectFlow.Domain.Entities;

namespace ProjectFlow.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid RoleId { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateUpdate { get; set; }

        // 🔥 Relación con Role (MUY IMPORTANTE)
        public Role Role { get; set; }

        // 🔥 Relación muchos a muchos con Project
        public ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();

        // 🔥 Relación con Issue (creador)
        public ICollection<Issue> CreatedIssues { get; set; } = new List<Issue>();

        // 🔥 Relación con Issue (asignado)
        public ICollection<Issue> AssignedIssues { get; set; } = new List<Issue>();


        public User(string userName, string email, string passwordHash, Guid roleId)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            RoleId = roleId;
            DateCreation = DateTime.UtcNow;
        }

        public bool ValidatePassword(string password)
            => BCrypt.Net.BCrypt.Verify(password, PasswordHash);

        public void ChangeUserName(string userName)
        {
            UserName = userName;
            DateUpdate = DateTime.UtcNow;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            DateUpdate = DateTime.UtcNow;
        }

        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
            DateUpdate = DateTime.UtcNow;
        }

        public void ChangeRole(Guid roleId)
        {
            RoleId = roleId;
            DateUpdate = DateTime.UtcNow;
        }
    }
}