using Automarket.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Common.Exceptions
{
    internal class AccountNotFoundException : AutomarketException
    {
        public AccountNotFoundException() : base("Entity \"Account\" wasn't found")
        {
        }
    }
}
