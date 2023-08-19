using Automarket.Shared.Abstractions.Exceptions;

namespace Automarket.Application.Common.Exceptions
{
    internal class AccountNotFoundException : AutomarketException
    {
        public AccountNotFoundException() : base("Entity \"Account\" wasn't found")
        {
        }
    }
}
