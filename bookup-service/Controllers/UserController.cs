using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookup_service.Interfaces;
using bookup_service.Models;
using bookup_service.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bookup_service.Controllers;

[Route("api/V1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IUserRepository userRepository;

    public UserController (IUserRepository userRepository, ApplicationDbContext applicationDbContext)
    {
        this.userRepository = userRepository;
    }

    [HttpPost(Name ="SignUp")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public ActionResult<string> SignUp([FromBody] User user)
    {
        userRepository.CreateUser(user);
        return Ok("Successfully created");
    }
}

