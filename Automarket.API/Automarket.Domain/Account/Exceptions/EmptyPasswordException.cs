using Automarket.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Account.Exceptions
{
    public class EmptyPasswordException : AutomarketException
    {
        public EmptyPasswordException() : base("Login is required and cannot be empty")
        {
        }
    }
}
