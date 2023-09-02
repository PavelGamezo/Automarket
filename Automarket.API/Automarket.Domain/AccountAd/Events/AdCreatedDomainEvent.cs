using Automarket.Domain.AccountAd.Entities;

namespace Automarket.Domain.AccountAd.Events
{
    public sealed class AdCreatedDomainEvent : IDomainEvent
    {
        public AdCreatedDomainEvent(Ad ad)
        {
            Ad = ad;
        }

        public Ad Ad { get; set; }
    }
}
