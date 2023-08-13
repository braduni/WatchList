using WatchList.Models.Domain;
using WatchList.Models.Dtos;

namespace WatchList.Services.Repository
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<IEnumerable<MovieDto>> GetMoviesByGenresAsync(IEnumerable<string> genres);
    }
}