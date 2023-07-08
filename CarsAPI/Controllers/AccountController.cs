﻿using CarsAPI.Models.Dto;
using CarsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarsAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("session")]
        public ActionResult Get()
        {
            var token = HttpContext.Request.Headers["Authorization"];
            var result = _accountService.GetLoggedUser(token);
            string json = JsonSerializer.Serialize(result);
            return Ok(json);

        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);

            var response = new { message = "Registration successful!" };
            string json = JsonSerializer.Serialize(response);
            return Ok(json);
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            var result = _accountService.GenerateJwtAndGetUser(dto);
            string json = JsonSerializer.Serialize(result);

            return Ok(json);
        }
    }
}
