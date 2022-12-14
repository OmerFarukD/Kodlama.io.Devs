using System.Reflection;
using Core.Application.Pipelines.Validation;
using Devs.Application.Features.Auths.Rules;
using Devs.Application.Features.Frameworks.Rules;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Services.AuthServices;
using Devs.Application.Services.UserServices;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Devs.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<LanguageBusinessRules>();
            services.AddScoped<FrameworkBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<IAuthService,AuthManager>();
            services.AddScoped<IUserService, UserManager>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
