using SafestBankServer.Application;
using SafestBankServer.Infrastructure;

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

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

}