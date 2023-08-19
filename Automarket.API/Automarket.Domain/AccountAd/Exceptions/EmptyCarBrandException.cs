using Automarket.Shared.Abstractions.Exceptions;

namespace Automarket.Domain.AccountAd.Exceptions
{
    public class EmptyCarBrandException : AutomarketException
    {
        public EmptyCarBrandException() : base("Car brand cannot be empty")
        {
        }
    }
}
