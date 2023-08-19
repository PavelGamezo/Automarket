using Automarket.Application.Common.Authentications;
using Automarket.Domain.Common.Repositories;
using Automarket.Domain.Repositories;
using Automarket.Infrastructure.Authentication;
using Automarket.Infrastructure.EF.Contexts;
using Automarket.Infrastructure.EF.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Automarket.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration, 
            string connectionString)
        {
            services.AddAuthentication(configuration);
            services.AddScoped<IAdRepository, AdRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }

        public static IServiceCollection AddAuthentication(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            var JwtSettings = new JwtSettings();
            configuration.Bind("JwtSettings", JwtSettings);

            services.AddSingleton(Options.Create(JwtSettings));

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           // Adding Jwt Bearer
           .AddJwtBearer(options => {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidAudience = JwtSettings.ValidAudience,
                   ValidIssuer = JwtSettings.ValidIssuer,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret))
               };
           });

            return services;
        }
    }
}
