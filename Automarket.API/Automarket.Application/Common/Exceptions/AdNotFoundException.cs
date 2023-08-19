using Automarket.Shared.Abstractions.Exceptions;

namespace Automarket.Application.Common.Exceptions
{
    public class AdNotFoundException : AutomarketException
    {
        public AdNotFoundException() : base("Entity \"Ad\" wasn't found")
        {
        }
    }
}
