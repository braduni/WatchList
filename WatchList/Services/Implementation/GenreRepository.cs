using WatchList.Services.Repository;

namespace WatchList.Services.Implementation
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DataContext dataContext) 
            : base(dataContext)
        {
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await FindByCondition(genre => genre.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}