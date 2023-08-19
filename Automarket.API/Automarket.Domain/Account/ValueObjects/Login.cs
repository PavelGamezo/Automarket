using Automarket.Domain.Account.Exceptions;
using Automarket.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
