using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueryLib.Demo.Data;
using QueryLib.Demo.Models;
using QueryLib.Demo.QueryServices;

namespace QueryLib.Demo;

/// <summary>
/// Startup
/// </summary>
public class Startup(IConfiguration configuration)
{
    /// <summary>
    /// IConfiguration
    /// </summary>
    protected readonly IConfiguration Configuration = configuration;
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddSwaggerGen();

        services
            .AddScoped<IDataProvider, DataProvider>()
            .AddScoped<IQueries, Queries>();
        
        services.AddDbContext<DataContext>(options =>
        {
            options.UseInMemoryDatabase("Memory");
        });
    }

    public static void Configure(IApplicationBuilder app)
    {
        app.UseSwagger();
         
        app.UseSwaggerUI();
        
        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        AddData(app);
    }

    private static void AddData(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.GetRequiredService<DataContext>();
        var personSet = context.Set<Person>();
        personSet.Add(new Person(1, "Первый"));
        personSet.Add(new Person(2, "Второй"));
        personSet.Add(new Person(3, "Третий"));
        
        var vehicleSet = context.Set<Vehicle>();
        vehicleSet.Add(new Vehicle(1, "Saleen"));
        vehicleSet.Add(new Vehicle(2, "CiZetta V16T"));
        vehicleSet.Add(new Vehicle(3, "McLaren F1"));

        context.SaveChanges();
    }
}