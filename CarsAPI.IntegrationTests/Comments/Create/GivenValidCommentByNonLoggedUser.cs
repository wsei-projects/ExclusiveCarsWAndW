using CarsAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CarsAPI.IntegrationTests.Comments.Create;

[Collection("Integration tests")]
public class GivenValidCommentByNonLoggedUser : IClassFixture<TestFixture>
{
    private readonly TestFixture _fixture;

    public GivenValidCommentByNonLoggedUser(TestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ThenResponseIsUnauthorizedAndCommentIsNotAddedToDatabase()
    {
        var commentDto = new CommentDto
        {
            Id = 43,
            PostID = 2,
            UserComment = "test comment",
            UserId = 1
        };

        var response = await _fixture.ApiClient.CreateComment(commentDto);
        var dbComment = await _fixture.DbContext.Comment.FirstOrDefaultAsync(x => x.Id == commentDto.Id);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Null(dbComment);
    }
}