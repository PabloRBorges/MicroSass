using MicroSass.Domain.Entities;
using MicroSass.Domain.Interfaces;

namespace MicroSass.Infrastructure.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly List<User> _users = new List<User>();

        public void Add(User entity)
        {
            _users.Add(entity);
        }

        public void Delete(Guid id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user != null) _users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(Guid id)
        {
            return _users.Find(u => u.Id == id);
        }

        public void Update(User entity)
        {
            var index = _users.FindIndex(u => u.Id == entity.Id);
            if (index != -1) _users[index] = entity;
        }
    }
}
