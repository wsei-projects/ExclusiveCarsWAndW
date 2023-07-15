using CarsAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CarsAPI.IntegrationTests.Comments.Create;

[Collection("Integration tests")]
public class GivenValidCommentByAdmin : IClassFixture<TestFixture>
{
    private readonly TestFixture _fixture;

    public GivenValidCommentByAdmin(TestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ThenResponseIsCreatedAndCommentIsAddedToDatabase()
    {
        var commentDto = new CommentDto
        {
            Id = 43,
            PostID = 2,
            UserComment = "test comment",
            UserId = 1
        };

        var userToken = await _fixture.ApiClient.GetAdminToken();
        var response = await _fixture.ApiClient.CreateComment(commentDto, userToken);
        var dbComment = await _fixture.DbContext.Comment.FirstOrDefaultAsync(x => x.Id == commentDto.Id);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(dbComment);
        Assert.Equal(commentDto.Id, dbComment.Id);
        Assert.Equal(commentDto.PostID, dbComment.PostID);
        Assert.Equal(commentDto.UserComment, dbComment.UserComment);
        Assert.Equal(commentDto.UserId, dbComment.UserId);
    }
}