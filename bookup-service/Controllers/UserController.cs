using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookup_service.Dto.Request;
using bookup_service.Interfaces;
using bookup_service.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookup_service.Controllers;

[Route("api/v1/user")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IUserService UserService;

    public UserController (IUserService UserService)
    {
        this.UserService = UserService;
    }

    [HttpPost]
    [Route("signup")]
    public bool SignUp([FromForm] User user)
    {
        return UserService.CreateUser(user);
    }

    [HttpPost]
    [Route("signin")]
    public ActionResult<string> SignIn([FromForm] UserLogInDto userLogInDto)
    {
        var authenticationResult = UserService.AuthenticateUser(userLogInDto);

        if (authenticationResult.Item1)
        {
            return Ok(new { jwtToken = authenticationResult.Item2 });
        }
        else
        {
            return Unauthorized(authenticationResult.Item2);
        }
    }
}

