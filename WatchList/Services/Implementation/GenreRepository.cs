using WatchList.Models.Domain;
using WatchList.Models.Dtos;
using WatchList.Services.Repository;

namespace WatchList.Services.Implementation
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DataContext dataContext) 
            : base(dataContext)
        {
        }

        public async Task<IEnumerable<GenreDto>> GetAllAsync()
        {
            var genres = await FindAll()
                .Select(genre => new GenreDto
                {
                    Id = genre.Id,
                    Name = genre.Name,
                })
                .ToListAsync();

            return genres;
        }

        public async Task<Genre?> GetGenreByIdAsync(int id)
        {
            return await FindByCondition(genre => genre.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}