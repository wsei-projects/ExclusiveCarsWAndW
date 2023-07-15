using CarsAPI.Models.Dto;

namespace CarsAPI.IntegrationTests.Helpers;

public partial class ApiHelper
{
    public async Task<HttpResponseMessage> Login(LoginDto loginDto)
    {
        return await Client.PostAsync("/api/account/login", Serialize(loginDto));
    }

    public async Task<string> GetUserToken()
    {
        var loginDto = new LoginDto
        {
            Email = "user@test.com",
            Password = "user123!"
        };
        var loginResponse = await Login(loginDto);
        var loginResultDto = await Deserialize<LoginResultDto>(loginResponse);

        return loginResultDto.Token;
    }

    public async Task<string> GetAdminToken()
    {
        var loginDto = new LoginDto
        {
            Email = "admin@test.com",
            Password = "admin123!"
        };
        var loginResponse = await Login(loginDto);
        var loginResultDto = await Deserialize<LoginResultDto>(loginResponse);

        return loginResultDto.Token;
    }
}