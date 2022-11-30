using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieApp.InterfaceModels;
using MovieApp.Services.Interfaces;
using MovieApp.Utilities;

namespace MovieApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] Register model)
         {

            _userService.Register(model);
                return Ok();
        }

        [HttpGet("AllUsers")]
        public IActionResult AllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] Login model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);

        }

    }
}
