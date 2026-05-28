using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Domain.Entities
{
   
        public class Role
        {
            public Guid Id { get;  set; }
            public string Name { get;  set; }

            // 🔥 Relación con User
            public ICollection<User> Users { get;  set; } = new List<User>();

            private Role() { }

            public Role(Guid id, string name)
            {
                Id = id;
                Name = name;
            }

            public void UpdateName(string name)
            {
                Name = name;
            }
        }
    
}
