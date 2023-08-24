using Automarket.Domain.Account.Exceptions;

namespace Automarket.Domain.Account.ValueObjects
{
    public class Login : ValueObject
    {
        public string Value { get; set; }

        public Login(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyLoginException();
            }

            Value = value;
        }

        public static implicit operator Login(string login)
            => new(login);

        public static implicit operator string(Login login)
            => login.Value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
