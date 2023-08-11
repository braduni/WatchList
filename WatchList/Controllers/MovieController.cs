using Microsoft.AspNetCore.Mvc;
using WatchList.Services.Repository;

namespace WatchList.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MovieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                var movies = await _unitOfWork.MovieRepository.GetAllAsync();
                return Ok(movies);
                
            }catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            try
            {
                var movie = await _unitOfWork.MovieRepository.GetMovieByIdAsync(id);

                if (movie == null)
                {
                    return NotFound();
                }
                else 
                {
                    return Ok(movie);
                }
                
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie request)
        {
            try 
            {
                _unitOfWork.MovieRepository.Create(request);
                await _unitOfWork.SaveChangesAsync();
                return CreatedAtAction(nameof(GetMovieById), new { id = request.Id }, request);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }          
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie request)
        {
            try 
            {
                var movie = await _unitOfWork.MovieRepository.GetMovieByIdAsync(id);

                if (movie == null)
                {
                    return NotFound();
                }

                movie.Title = request.Title;
                movie.Director = request.Director;
                movie.Genres = request.Genres;

                _unitOfWork.MovieRepository.Update(movie);
                await _unitOfWork.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMovie(int id)
        {
            try
            {
                var movie = await _unitOfWork.MovieRepository.GetMovieByIdAsync(id);

                if (movie == null)
                {
                    return NotFound();
                }

                _unitOfWork.MovieRepository.Delete(movie);
                await _unitOfWork.SaveChangesAsync();     
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}