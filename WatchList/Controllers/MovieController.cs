using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WatchList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Movie>>> UpdateMovie(int id, Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
