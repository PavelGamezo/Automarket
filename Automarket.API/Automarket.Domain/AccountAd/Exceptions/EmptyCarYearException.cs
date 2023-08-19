using Automarket.Shared.Abstractions.Exceptions;

namespace Automarket.Domain.AccountAd.Exceptions
{
    public class EmptyCarYearException : AutomarketException
    {
        public EmptyCarYearException() : base("Car year cannot be empty")
        {
        }
    }
}
