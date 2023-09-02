using Automarket.Domain.AccountAd.Entities;

namespace Automarket.Domain.AccountAd.Events
{
    public sealed class AdPlacedDomainEvent : IDomainEvent
    {
        public AdPlacedDomainEvent(Ad ad)
        {
            Ad = ad;
        }

        public Ad Ad { get; set; }
    }
}
