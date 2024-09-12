using MicroSass.Domain.Entities;
using MicroSass.Domain.Interfaces;
using MicroSass.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MicroSass.Infrastructure.Repositories
{
    public class SubscriptionRepository : IRepository<Subscription>
    {
        private readonly AppDbContext _context;

        public SubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Subscription entity)
        {
            _context.Subscriptions.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var subscription = _context.Subscriptions.Find(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Subscription> GetAll()
        {
            return _context.Subscriptions.Include(s => s.UserId).ToList();
        }

        public Subscription GetById(Guid id)
        {
            return _context.Subscriptions.Find(id);
        }

        public void Update(Subscription entity)
        {
            _context.Subscriptions.Update(entity);
            _context.SaveChanges();
        }
    }
}
