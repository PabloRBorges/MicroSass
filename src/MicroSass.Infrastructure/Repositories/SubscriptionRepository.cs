using MicroSass.Domain.Entities;
using MicroSass.Domain.Interfaces;

namespace MicroSass.Infrastructure.Repositories
{
    public class SubscriptionRepository : IRepository<Subscription>
    {
        private readonly List<Subscription> _subscriptions = new List<Subscription>();

        public void Add(Subscription entity)
        {
             _subscriptions.Add(entity);
        }

        public void Delete(Guid id)
        {
            var subscription = _subscriptions.Find(s => s.Id == id);
            if (subscription != null) _subscriptions.Remove(subscription);
        }

        public IEnumerable<Subscription> GetAll()
        {
            return _subscriptions;
        }

        public Subscription GetById(Guid id)
        {
            var result = _subscriptions.Find(s => s.Id == id);

            if (result != null)
                return result;

            return null;
        }

        public void Update(Subscription entity)
        {
            var index = _subscriptions.FindIndex(s => s.Id == entity.Id);
            if (index != -1) _subscriptions[index] = entity;
        }
    }
}
