using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.InterfaceModels;
using MovieApp.Services.Interfaces;
using System.Security.Claims;

namespace MovieApp.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ILoggerService _logger;
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService, ILoggerService logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpPost("CreateMovie")]
        public IActionResult Create([FromBody] Movie model)
        {
            int userId = GetAuthorizedUserId();
            _logger.LogInfo("Create end point");
            _movieService.Create(model, userId);
            return Ok("Succesfully create movie");
        }

        [HttpGet("Movies")]
        public IActionResult GetAll()
        {
            _logger.LogInfo("GetAll end point");
            return Ok(_movieService.GetAll());
        }

        [HttpGet("MovieByGenre/{genre}")]
        public IActionResult GetByGenre([FromRoute] int genre)
        {
            return Ok(_movieService.GetByGenre(genre));
        }
        [HttpGet("MovieById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_movieService.GetById(id));
        }

        [HttpGet("GetAllByUser")]
        public IActionResult GetAllByUser()
        {
            int userId = GetAuthorizedUserId();
            //var response = _movieService.GetAll();
            //var response1 = response.Where(movie => movie.UserId == userId).ToList();
            
            return Ok(_movieService.GetByUserId(userId));
        }

        private int GetAuthorizedUserId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                string name = User.FindFirst(ClaimTypes.Name)?.Value;
                throw new Exception($"Name identifier claim does not exist! {userId} {name}");
            }
            return userId;
        }
    }
}
