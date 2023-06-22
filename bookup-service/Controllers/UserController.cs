using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    [HttpPost(Name ="SignUp")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public ActionResult<string> SignUp([FromBody] User user)
    {
        UserService.CreateUser(user);
        return "Successfully created";
    }
}

