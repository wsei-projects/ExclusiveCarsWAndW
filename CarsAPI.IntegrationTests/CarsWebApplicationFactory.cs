using CarsAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarsAPI.IntegrationTests;

public class CarsWebApplicationFactory : WebApplicationFactory<Program>
{
    public AppDbContext DbContext { get; set; } = null!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //Setup the content root and configuration to be the same as the API project
        var projectDir = GetProjectPath("", typeof(Program).GetTypeInfo().Assembly);

        builder
            .UseContentRoot(projectDir)
            .ConfigureAppConfiguration((c, conf) =>
            {
                //conf.AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.Acceptance.json"), optional: false, reloadOnChange: true);
            })
            .ConfigureServices(services =>
            {
                ConfigureSqlProvider(services);
            });
    }

    private void ConfigureSqlProvider(IServiceCollection services)
    {
        var descriptor = services.Single(
            d => d.ServiceType ==
                 typeof(DbContextOptions<AppDbContext>));

        services.Remove(descriptor);

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseInMemoryDatabase("InMemoryDb");
        });

        var sp = services.BuildServiceProvider();
        DbContext = sp.GetService<AppDbContext>()!;
    }

    private static string GetProjectPath(string projectRelativePath, Assembly startupAssembly)
    {
        // Get name of the target project which we want to test
        var projectName = startupAssembly.GetName().Name;

        // Get currently executing test project path
        var applicationBasePath = System.AppContext.BaseDirectory;

        // Find the path to the target project
        var directoryInfo = new DirectoryInfo(applicationBasePath);
        do
        {
            directoryInfo = directoryInfo.Parent;

            var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo!.FullName, projectRelativePath));
            if (projectDirectoryInfo.Exists)
            {
                var projectFileInfo = new FileInfo(Path.Combine(projectDirectoryInfo.FullName,
                    projectName!,
                    $"{projectName}.csproj"));

                if (projectFileInfo.Exists)
                {
                    return Path.Combine(projectDirectoryInfo.FullName, projectName!);
                }
            }
        } while (directoryInfo.Parent != null);

        throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
    }
}