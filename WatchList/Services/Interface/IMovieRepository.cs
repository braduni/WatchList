using WatchList.Models.Domain;
using WatchList.Models.Dtos;

namespace WatchList.Services.Repository
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<IEnumerable<MovieDtoWithoutGenres>> GetMoviesByGenresAsync(IEnumerable<string> genres);
    }
}