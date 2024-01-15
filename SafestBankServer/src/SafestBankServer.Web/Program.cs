using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using SafestBankServer.Application;
using SafestBankServer.Infrastructure;
using SafestBankServer.Web.Configuration;
using SafestBankServer.Web.Configuration.CookieAuth;
using SafestBankServer.Web.Configuration.Session;

namespace SafestBankServer.Web;
public static class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.RemoveServerHeader();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
            .Build();

        builder.Services.AddMemoryCache();

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(configuration);
        builder.Services.AddWeb();

        builder.Services.AddCookieAuth();

        builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                var builtInFactory = options.InvalidModelStateResponseFactory;

                options.InvalidModelStateResponseFactory = context =>
                {
                    //TODO - CHANGE MESSAGE, ADD LOGGING i usun ten interpolated string
                    context.ModelState.Values.SelectMany(v => v.Errors).ToList().ForEach(e => Console.WriteLine(e.ErrorMessage));
                    var result = new BadRequestObjectResult(new { message = "Bad request before even getting to the controller." });
                    return result;
                };
            });

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

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        if (app.Environment.IsDevelopment())
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
        var sessionConfiguration = services.BuildServiceProvider().GetRequiredService<SessionConfiguration>();

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
                opt.ExpireTimeSpan = sessionConfiguration.SessionExpirationTime;
                opt.EventsType = typeof(SessionAuthenticationEvent);
            });
        services.AddScoped<SessionAuthenticationEvent>();

        services.AddAuthorization(builder =>
        {
            builder.AddPolicy("SessionPolicy", policy =>
            {
                policy.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("Session")
                    .RequireClaim("id");
            });

            builder.DefaultPolicy = builder.GetPolicy("SessionPolicy")!;
        });
    }

    private static void RemoveServerHeader(this WebApplicationBuilder builder)
    {
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.AddServerHeader = false;
        });
    }

}