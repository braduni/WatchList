using WatchList.Models.Domain;
using WatchList.Models.Dtos;

namespace WatchList.Services.Repository
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<IEnumerable<GenreDto>> GetAllAsync();
        Task<Genre?> GetGenreByIdAsync(int id);

        Task<Genre?> GetGenreByNameAsync(string name);
    }
}