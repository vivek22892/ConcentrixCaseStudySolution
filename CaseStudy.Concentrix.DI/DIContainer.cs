using CaseStudy.Concentrix.Abstraction.Interface;
using CaseStudy.Concentrix.Application;
using CaseStudy.Concentrix.Application.Mapper;
using CaseStudy.Concentrix_Infrastrucure;
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
            services.AddAutoMapper(typeof(CaseStudyProfile).Assembly);
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromMinutes(30));

            return services;
        }

    }
}
