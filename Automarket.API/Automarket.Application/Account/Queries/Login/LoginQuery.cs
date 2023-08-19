using Automarket.Application.Common.Queries;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Application.Authentication.Queries.Login
{
    public record class LoginQuery(string Login, string Password, string FullName, string Email) : IQuery<Result<string>>
    {
    }
}
