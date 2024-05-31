using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServiceExtension {

    /// <summary>
    /// Adds application services to the specified IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    public static void AddApplicationService(this IServiceCollection services) {

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();

        //AutoMapper register
        //services.AddAutoMapper(typeof(UserProfile));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Register FluentValidation
        services.AddValidatorsFromAssemblyContaining<UserModelValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginModelValidator>();

        //FluentValidation
        services.AddTransient<IValidator<UserRequestModel>, UserModelValidator>();
        services.AddTransient<IValidator<LoginModel>, LoginModelValidator>();
        services.AddTransient<IValidator<RegisterModel>, RegisterModelValidator>();

        // FluentValidation MVC integration
        services.AddFluentValidationAutoValidation();
        //services.AddFluentValidationClientsideAdapters();
    }
}