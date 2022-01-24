using DevIO.Business.Intefaces;
using DevIO.Business.Interfaces;
using DevIO.Business.Notificacoes;
using DevIO.Business.Services;
using DevIO.Data.Context;
using DevIO.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.App.Configurations
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();                      
            
            services.AddScoped<IIntegranteRepository, IntegranteRepository>();

            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<INotificador, Notificador>();
                        
            services.AddScoped<IIntegranteService, IntegranteService>();

            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<IPostService, PostService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUser, AspNetUser>();

            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
            //services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

        }
    }

    public static class MvcConfig
    {
        //public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        //{
        //    services.AddMvc(o =>
        //    {
        //        o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "O valor preenchido e invlido para esse campo.");
        //        o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "Este campo precisa ser preenchido.");
        //        o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "Este campo precisa ser preenchido");
        //        o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "E necessario que o body na requisicao nao esteja vazio.");
        //        o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor((x) => "O valor preenchido e invlido para esse campo");
        //        o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "O valor preenchido e invlido para esse campo");
        //        o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "O campo deve ser numerico");
        //        o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) => "O valor preenchido e invlido para esse campo");
        //        o.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x) => "O valor preenchido e invlido para esse campo");
        //        o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "O campo deve ser numerico");
        //        o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "Este campo precisa ser preenchido");
        //    })
        //      .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        //    return services;
        //}
    }

    public static class IdentityConfig
    {
        //public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.Configure<CookiePolicyOptions>(options =>
        //    {
        //        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        //        options.CheckConsentNeeded = context => true;
        //        options.MinimumSameSitePolicy = SameSiteMode.None;
        //    });

        //    //services.AddDbContext<ApplicationDbContext>(options =>
        //    //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnections")));

        //    //services.AddDefaultIdentity<IdentityUser>()
        //    //    .AddDefaultUI(Microsoft.AspNetCore.Identity.UI.UIFramework.Bootstrap4)
        //    //    .AddEntityFrameworkStores<ApplicationDbContext>();

        //    return services;
        //}
    }


}
