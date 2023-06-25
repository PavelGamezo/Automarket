using Automarket.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Exceptions
{
    public class EmptyCarYearException : AutomarketException
    {
        public EmptyCarYearException() : base("Car year cannot be empty")
        {
        }
    }
}
