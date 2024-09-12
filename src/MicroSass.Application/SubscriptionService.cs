using MicroSass.Domain.Entities;
using MicroSass.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSass.Application
{
    public class SubscriptionService
    {
        private readonly IRepository<Subscription> _subscriptionRepository;

        public SubscriptionService(IRepository<Subscription> subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public void CreateSubscription(Guid userId, DateTime startDate, DateTime endDate)
        {
            var subscription = new Subscription(userId, startDate, endDate);
            _subscriptionRepository.Add(subscription);
                       
        }

        public Subscription GetSubscription(Guid id)
        {
            return _subscriptionRepository.GetById(id);
        }
    }
}
