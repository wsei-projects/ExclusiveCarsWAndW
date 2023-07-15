using System.Net;

namespace CarsAPI.IntegrationTests.CarClasses.GetOne;

[Collection("Integration tests")]
public class GivenNonexistentCarClass : IClassFixture<TestFixture>
{
    private readonly TestFixture _fixture;

    public GivenNonexistentCarClass(TestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ThenResponseIsNotFoundAndCarClassIsNotReturned()
    {
        const int id = 123;
        var response = await _fixture.ApiClient.GetCarClass(id);
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}