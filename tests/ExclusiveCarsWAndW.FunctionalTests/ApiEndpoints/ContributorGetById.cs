﻿using Ardalis.HttpClientTestExtensions;
using ExclusiveCarsWAndW.Web;
using ExclusiveCarsWAndW.Web.Endpoints.ContributorEndpoints;
using Xunit;

namespace ExclusiveCarsWAndW.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorGetById : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  public ContributorGetById(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedContributorGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<ContributorRecord>(GetContributorByIdRequest.BuildRoute(1));

    Assert.Equal(1, result.Id);
    Assert.Equal(SeedData.Contributor1.Name, result.Name);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId0()
  {
    string route = GetContributorByIdRequest.BuildRoute(0);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}