using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchList.Services.MovieService;

namespace WatchList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            return await _movieService.GetAllMovies();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetBookById(int id)
        {
            var result = await _movieService.GetMovieById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddMovie(Movie movie)
        {
            var result = await _movieService.AddMovie(movie);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Movie>>> UpdateMovie(int id, Movie movie)
        {
            var result = await _movieService.UpdateMovie(id, movie);
            return Ok(result);
        }

    }
}
