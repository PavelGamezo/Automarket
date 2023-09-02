using Automarket.Domain.AccountAd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.AccountAd.Events
{
    public sealed class AdChangedDomainEvent : IDomainEvent
    {
        public AdChangedDomainEvent(Ad ad)
        {
            Ad = ad;
        }

        public Ad Ad { get; set; }
    }
}
