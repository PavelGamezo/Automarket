using Automarket.Domain.AccountAd.Entities;

namespace Automarket.Domain.AccountAd.Events
{
    public class AdCompletedEvent : IDomainEvent
    {
        public AdCompletedEvent(Ad ad)
        {
            Ad = ad;
        }

        public Ad Ad { get; }
    }
}
