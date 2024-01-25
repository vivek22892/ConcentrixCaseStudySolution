using CaseStudy.Concentrix.Abstraction.Interface;
using CaseStudy.Concentrix.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace CaseStudy.Concentrix.DI
{
    public static class DIContainer
    {
        public static IServiceCollection AddCaseStudyDIContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromMinutes(30));
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddControllers().AddJsonOptions(op =>
            {
                op.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            return services;
        }

    }
}
