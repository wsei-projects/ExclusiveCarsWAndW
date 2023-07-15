namespace CarsAPI.IntegrationTests.Helpers;

public partial class ApiHelper
{
    public async Task<HttpResponseMessage> GetAllCarClasses()
    {
        return await Client.GetAsync("/api/carclasses");
    }

    public async Task<HttpResponseMessage> GetCarClass(int id)
    {
        return await Client.GetAsync($"/api/carclasses/{id}");
    }
}