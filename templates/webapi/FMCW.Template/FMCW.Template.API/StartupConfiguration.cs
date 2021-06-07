using FMCW.Template.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FMCW.Template.API
{
    public static class StartupConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services,
                IConfiguration configuration,
                string groupName)
        {
            var openApiInfo = new OpenApiInfo();
            configuration.GetSection("Application").Bind(openApiInfo);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(groupName, openApiInfo);
            });
            return services;
        }

        public static IServiceCollection ConfigureJwt(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddConfig<JwtConfiguration>(configuration, "Jwt");
            services.AddTransient<IJwtManager, JwtManager>();
            return services;
        }
        

        public static IServiceCollection AddConfig<T>(
                    this IServiceCollection services,
                    IConfiguration configuration, string sectionName = "") where T : class, new()
        {
            var config = string.IsNullOrEmpty(sectionName) ? configuration : configuration.GetSection(sectionName);
            var t = new T();
            config.Bind(t);
            services.AddSingleton(t);
            return services;
        }
    }
}
