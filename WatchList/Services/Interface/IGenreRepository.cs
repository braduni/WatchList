namespace WatchList.Services.Repository
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> GetGenreByIdAsync(int id);
    }
}