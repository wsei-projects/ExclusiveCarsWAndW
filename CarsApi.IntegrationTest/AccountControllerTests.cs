using Azure;
using CarsAPI.Controllers;
using CarsAPI.Models.Dto;
using CarsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;

namespace CarsApi.IntegrationTest
{
        public class AccountControllerTests
        {
            private readonly AccountController _controller;
            private readonly Mock<IAccountService> _accountServiceMock;

            public AccountControllerTests()
            {
                _accountServiceMock = new Mock<IAccountService>();
                _controller = new AccountController(_accountServiceMock.Object);
            }
            [Fact]
            public void RegisterUser_ReturnsOkResult()
            {
               
                var dto = new RegisterUserDto {Email = "test@test.com",
                Password = "password123",
                ConfirmPassword = "password123"};

                
                var result = _controller.RegisterUser(dto);

               
                var okResult = Assert.IsType<OkObjectResult>(result);
                var json = Assert.IsType<string>(okResult.Value);
                

                _accountServiceMock.Verify(s => s.RegisterUser(dto), Times.Once);
            }
    }
}
