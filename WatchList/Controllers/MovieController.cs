using Microsoft.AspNetCore.Mvc;
using WatchList.Models.Domain;
using WatchList.Models.Dtos;
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
                var movies = await _unitOfWork.MovieRepository.GetAllMoviesAsync();
                return Ok(movies);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            try
            {
                var result = await _unitOfWork.MovieRepository.GetMovieByIdAsync(id);

                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    var movie = new MovieDto 
                    {
                        Id = result.Id,
                        Title = result.Title,
                        Director = result.Director,
                        Genres = result.Genres?.Select(g => g.Name).ToList() ?? new List<string>()
                    };   
                    
                    return Ok(movie);
                }
                
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieDto request)
        {
            try 
            {
                if (!ModelState.IsValid) 
                {
                    return BadRequest(ModelState);
                }

                var movie = new Movie
                {
                    Title = request.Title,
                    Director = request.Director,
                    Genres = _unitOfWork.GenreRepository
                    .FindByCondition(g => request.Genres.Contains(g.Name))
                    .ToList()
                };
          
                _unitOfWork.MovieRepository.Create(movie);
                await _unitOfWork.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }          
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] AddMovieDto request)
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var movieToUpdate = await _unitOfWork.MovieRepository.GetMovieByIdAsync(id);

                if (movieToUpdate == null)
                {
                    return NotFound();
                }

                movieToUpdate.Title = request.Title;
                movieToUpdate.Director = request.Director;

                var genreToUpdate = _unitOfWork.GenreRepository
                    .FindByCondition(g => request.Genres.Contains(g.Name))
                    .ToList();

                movieToUpdate.Genres = genreToUpdate;

                _unitOfWork.MovieRepository.Update(movieToUpdate);
                await _unitOfWork.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
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
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("by-genres")]
        public async Task<IActionResult> GetMoviesByGenres([FromQuery] IEnumerable<string> genres)
        {
            if (genres == null || !genres.Any())
            {
                return BadRequest("At least one genre must be provided.");
            }
            
            try
            {
                var moviesByGenres = await _unitOfWork.MovieRepository.GetMoviesByGenresAsync(genres);
                return Ok(moviesByGenres);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }   
        }
    }
}