using MicroSass.Domain.Entities;
using MicroSass.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSass.Application
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void RegisterUser(string name, string email)
        {
            var user = new User(name, email);
            _userRepository.Add(user);
        }

        public void UpdateUserEmail(Guid id, string newEmail)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                user.UpdateEmail(newEmail);
                _userRepository.Update(user);
            }
        }
    }
}
