using SafestBankServer.Application;
using SafestBankServer.Infrastructure;
using SafestBankServer.Web.Configuration;
using SafestBankServer.Web.Configuration.CookieAuth;
using System.Security.Claims;

namespace SafestBankServer.Web;
public static class Program {

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();

        builder.Services.AddMemoryCache();

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(configuration);
        builder.Services.AddWeb();

        builder.Services.AddCookieAuth();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //TODO - LEPSZE CORSY
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("https://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            });
        });

        var app = builder.Build();

        app.UseExceptionHandler(_ => { });

        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        //app.UseSession();

        app.MapControllers();

        app.Run();
    }

    private static void AddCookieAuth(this IServiceCollection services)
    {
        var cookieAuthOptions = services.BuildServiceProvider().GetRequiredService<CookieAuthOptions>();

        services.AddAuthentication("Session")
            .AddCookie("Session", opt =>
            {
                opt.Cookie.Name = ".TheSafestBank.Session";
                opt.Cookie.Domain = "localhost";
                opt.Cookie.Path = "/";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.IsEssential = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                opt.LoginPath = "/api/auth/login";
                opt.ExpireTimeSpan = cookieAuthOptions.CookieExpirationTime;
                opt.EventsType = typeof(CustomCookieAuthenticationEvents);
            });
        services.AddScoped<CustomCookieAuthenticationEvents>();

        services.AddAuthorization(builder =>
        {
            builder.AddPolicy("SessionPolicy", policy =>
            {
                policy.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("Session")
                    .RequireClaim(ClaimTypes.Sid);
            });
        });
    }

}