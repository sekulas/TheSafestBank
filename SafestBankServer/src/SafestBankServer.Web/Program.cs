using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using SafestBankServer.Application;
using SafestBankServer.Infrastructure;
using SafestBankServer.Web.Configuration;

namespace SafestBankServer.Web;
public static class Program {

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();

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

        services.AddAuthentication()
            .AddCookie("Session", opt =>
            {
                opt.Cookie.Name = ".TheSafestBank.Session";
                opt.Cookie.Domain = "localhost";
                opt.Cookie.Path = "/";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.IsEssential = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(1);
            });

        //options.Cookie.HttpOnly = true;
        //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        //options.Cookie.SameSite = SameSiteMode.Strict;
        //options.Cookie.MaxAge = TimeSpan.FromDays(1); // Adjust as needed
        //options.LoginPath = "/api/auth/login"; // Specify your login endpoint

        //services.AddAuthorization(options =>
        //{
        //    options.AddPolicy("SessionPolicy", policy =>
        //    {
        //        policy.RequireAuthenticatedUser();
        //    });
        //});

        //services.ConfigureApplicationCookie(options =>
        //{
        //    options.Cookie.Name = ".TheSafestBank.Session";
        //    options.Cookie.HttpOnly = true;
        //    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
        //    options.LoginPath = "api/auth/login";
        //    //options.AccessDeniedPath = "/auth/access-denied";
        //    //options.SlidingExpiration = true;
        //});

        //services.AddSession(options =>
        //{
        //    options.Cookie.Name = ".TheSafestBank.Session";
        //    options.IdleTimeout = TimeSpan.FromMinutes(5);
        //    options.Cookie.HttpOnly = true;
        //    options.Cookie.IsEssential = true;
        //});

    }

}