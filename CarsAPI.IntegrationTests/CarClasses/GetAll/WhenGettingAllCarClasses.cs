using CarsAPI.IntegrationTests.Helpers;
using CarsAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CarsAPI.IntegrationTests.CarClasses.GetAll;

[Collection("Integration tests")]
public class WhenGettingAllCarClasses : IClassFixture<TestFixture>
{
    private readonly TestFixture _fixture;

    public WhenGettingAllCarClasses(TestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ThenResponseIsOKAndAllCarClassesAreReturned()
    {
        var response = await _fixture.ApiClient.GetAllCarClasses();
        var results = await ApiHelper.Deserialize<List<CarClassDto>>(response);
        var dbCarClasses = await _fixture.DbContext.CarClasses.ToListAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(results);
        Assert.Equal(dbCarClasses.Count, results.Count);

        foreach (var result in results)
        {
            var dbCarClass = dbCarClasses.Find(x => x.Id == result.Id);
            Assert.NotNull(dbCarClass);
            Assert.Equal(dbCarClass.Name, result.Name);
        }
    }
}