using Automarket.Domain.Entities;
using Automarket.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Events
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
