using System;
using System.Collections.Generic;

namespace ProjectFlow.Domain.Entities
{
    public class Priority
    {
        public Guid Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }

        //   una prioridad tiene muchos issues
        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        private Priority() { }
    }
}