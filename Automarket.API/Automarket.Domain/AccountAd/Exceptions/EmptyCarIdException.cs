using Automarket.Shared.Abstractions.Exceptions;

namespace Automarket.Domain.AccountAd.Exceptions
{
    public class EmptyCarIdException : AutomarketException
    {
        public EmptyCarIdException() : base("Car ID cannot be empty")
        {
        }
    }
}
