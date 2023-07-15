using CarsAPI.Models.Dto;
using System.Net.Http.Headers;

namespace CarsAPI.IntegrationTests.Helpers;

public partial class ApiHelper
{
    public async Task<HttpResponseMessage> CreateComment(CommentDto commentDto, string? jwtToken = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/api/comments")
        {
            Content = Serialize(commentDto)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        return await Client.SendAsync(request);
    }
}