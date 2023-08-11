using WatchList.Services.Repository;

namespace WatchList.Services.Implementation
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await FindAll().ToListAsync();
        }

        public Task<IEnumerable<Movie>> GetAllMoviesByGenreAsync(string genre)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await FindByCondition(movie => movie.Id.Equals(id)).FirstOrDefaultAsync();
        }

    }
}