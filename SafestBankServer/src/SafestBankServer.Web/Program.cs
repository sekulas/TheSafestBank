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

        builder.Services.AddControllers();

        //builder.Services.AddCookies();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //TODO - LEPSZE CORSY
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
            policy =>
            {
                policy.WithOrigins("http://localhost:3000")
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

        app.UseAuthorization();

        //app.UseSession();

        app.MapControllers();

        app.Run();
    }

    //private static void AddCookies(this IServiceCollection services)
    //{

    //    services.ConfigureApplicationCookie(options =>
    //    {
    //        options.Cookie.Name = ".TheSafestBank.Session";
    //        options.Cookie.HttpOnly = true;
    //        options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    //        options.LoginPath = "/auth/login";
    //        //options.AccessDeniedPath = "/auth/access-denied";
    //        //options.SlidingExpiration = true;
    //    });

    //    services.AddSession(options =>
    //    {
    //        options.IdleTimeout = TimeSpan.FromMinutes(5);
    //        options.Cookie.HttpOnly = true;
    //        options.Cookie.IsEssential = true;
    //    });

    //}

}