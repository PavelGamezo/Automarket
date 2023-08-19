using Automarket.Shared.Abstractions.Exceptions;

namespace Automarket.Domain.AccountAd.Exceptions
{
    public class EmptyCarModelException : AutomarketException
    {
        public EmptyCarModelException() : base("Car model cannot be empty")
        {
        }
    }
}
