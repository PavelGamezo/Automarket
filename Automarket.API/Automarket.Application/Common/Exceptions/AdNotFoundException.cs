using Automarket.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Common.Exceptions
{
    public class AdNotFoundException : AutomarketException
    {
        public AdNotFoundException() : base("Entity \"Ad\" wasn't found")
        {
        }
    }
}
