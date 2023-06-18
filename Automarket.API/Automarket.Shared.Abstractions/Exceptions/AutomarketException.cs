using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Shared.Abstractions.Exceptions
{
    public class AutomarketException : Exception
    {
        public AutomarketException(string message) : base(message)
        {
        }
    }
}
