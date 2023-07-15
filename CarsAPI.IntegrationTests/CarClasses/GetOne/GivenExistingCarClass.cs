using CarsAPI.IntegrationTests.Helpers;
using CarsAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CarsAPI.IntegrationTests.CarClasses.GetOne;

[Collection("Integration tests")]
public class GivenExistingCarClass : IClassFixture<TestFixture>
{
    private readonly TestFixture _fixture;

    public GivenExistingCarClass(TestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ThenResponseIsOKAndCarClassIsReturned()
    {
        const int id = 2;
        var response = await _fixture.ApiClient.GetCarClass(id);
        var carClass = await ApiHelper.Deserialize<CarClassDto>(response);
        var dbCarClass = await _fixture.DbContext.CarClasses.FirstAsync(x => x.Id == id);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(carClass);
        Assert.Equal(dbCarClass.Id, carClass.Id);
        Assert.Equal(dbCarClass.Name, carClass.Name);
    }
}