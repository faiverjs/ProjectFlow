using System;
using System.Collections.Generic;

namespace ProjectFlow.Domain.Entities
{
    public class State
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // 🔥 Relación: un estado tiene muchos issues
        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        private State() { }

        public State(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}