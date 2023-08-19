namespace Automarket.Application.Common.Authentications
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Domain.Account.Entities.Account account);
    }
}
