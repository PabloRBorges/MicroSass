using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSass.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public User(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }
    }
}
