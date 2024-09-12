using MicroSass.Application;
using Microsoft.AspNetCore.Mvc;

namespace MicroSass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;

        public SubscriptionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public IActionResult CreateSubscription(Guid userId, DateTime startDate, DateTime endDate)
        {
            _subscriptionService.CreateSubscription(userId, startDate, endDate);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscription(Guid id)
        {
            var subscription = _subscriptionService.GetSubscription(id);
            if (subscription == null) return NotFound();
            return Ok(subscription);
        }
    }
}
