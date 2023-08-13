using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WatchList.Models.Domain;
using WatchList.Models.Dtos;
using WatchList.Services.Repository;

namespace WatchList.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            try
            {
                var genres = await _unitOfWork.GenreRepository.GetAllAsync();
                return Ok(genres);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetGenreById(int id)
        {
            try
            {
                var result = await _unitOfWork.GenreRepository.GetGenreByIdAsync(id);

                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    var genre = new GenreDto
                    {
                        Id = result.Id,
                        Name = result.Name,
                    };

                    return Ok(genre);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] AddGenreDto request) 
        {
            try 
            {
                if (!ModelState.IsValid) 
                {
                    return BadRequest(ModelState);
                }
                var genre = new Genre
                {
                    Name = request.Name
                };

                _unitOfWork.GenreRepository.Create(genre);
                await _unitOfWork.SaveChangesAsync();

                return CreatedAtAction(nameof(GetGenreById), new { id = genre.Id }, genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] AddGenreDto request)
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var genreToUpdate = await _unitOfWork.GenreRepository.GetGenreByIdAsync(id);

                if (genreToUpdate == null)
                {
                    return NotFound();
                }

                genreToUpdate.Name = request.Name;
                
                _unitOfWork.GenreRepository.Update(genreToUpdate);
                await _unitOfWork.SaveChangesAsync();

                return NoContent();

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            try 
            {
                var genre = await _unitOfWork.GenreRepository.GetGenreByIdAsync(id);

                if (genre == null) 
                {
                    return NotFound();
                }

                _unitOfWork.GenreRepository.Delete(genre);
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