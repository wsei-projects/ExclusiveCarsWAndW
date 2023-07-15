using CarsAPI.Data;
using CarsAPI.IntegrationTests.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI.IntegrationTests;

public class TestFixture : IDisposable
{
    public CarsWebApplicationFactory WebApp { get; }
    public ApiHelper ApiClient { get; }
    public AppDbContext DbContext { get; }

    public TestFixture()
    {
        WebApp = new();
        var client = WebApp.CreateClient();
        ApiClient = new(client);
        DbContext = WebApp.DbContext;
        //ObaMockServer = ObaServiceWireMockServer.Start(8087);
        ResetDatabase();
    }

    private void ResetDatabase()
    {
        DbContext.Database.EnsureDeleted();
        if (DbContext.Database.IsRelational())
        {
            DbContext.Database.CloseConnection();
        }

        DbContext.ChangeTracker.Clear();

        if (DbContext.Database.IsRelational())
        {
            DbContext.Database.OpenConnection();
        }

        DbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        WebApp.Dispose();
    }
}