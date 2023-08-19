using Automarket.Shared.Abstractions.Exceptions;

namespace Automarket.Domain.AccountAd.Exceptions
{
    public class EmptyCarBodyException : AutomarketException
    {
        public EmptyCarBodyException() : base("Car body cannot be empty")
        {
        }
    }
}
