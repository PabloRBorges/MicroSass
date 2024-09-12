namespace MicroSass.Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Subscription(Guid userId, DateTime startDate, DateTime endDate)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
