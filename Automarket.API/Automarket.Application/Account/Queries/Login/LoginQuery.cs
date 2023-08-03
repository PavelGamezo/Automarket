using Automarket.Application.Common.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Authentication.Queries.Login
{
    public record class LoginQuery(string Email) : IQuery<string>
    {
    }
}
