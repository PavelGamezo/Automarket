using Automarket.Domain.Account.Exceptions;
using Automarket.Shared.Abstractions.Domain;

namespace Automarket.Domain.Account.ValueObjects
{
    public class Password : ValueObject
    {
        public string Value { get; set; }

        public Password(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyPasswordException();
            }

            Value = value;
        }

        public static implicit operator Password(string login)
            => new(login);

        public static implicit operator string(Password login)
            => login.Value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
