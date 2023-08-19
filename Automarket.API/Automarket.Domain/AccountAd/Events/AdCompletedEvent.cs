using Automarket.Domain.AccountAd.Entities;
using Automarket.Shared.Abstractions.Domain;

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
