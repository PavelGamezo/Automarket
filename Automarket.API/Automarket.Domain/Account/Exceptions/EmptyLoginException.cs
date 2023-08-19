using Automarket.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Account.Exceptions
{
    public class EmptyLoginException : AutomarketException
    {
        public EmptyLoginException() : base("Login is required and cannot be empty")
        {
        }
    }
}
