using Microsoft.AspNetCore.Mvc;
using WatchList.Models.Domain;
using WatchList.Models.Dtos;
using WatchList.Services.Repository;

namespace WatchList.Services.Implementation
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await FindAll()
                .Include(movie => movie.Genres)
                .ToListAsync();

            if (!movies.Any())
            { 
                return Enumerable.Empty<MovieDto>(); 
            }

            return movies.Select(movie => new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                Genres = movie.Genres.Select(g => g.Name).ToList() ?? new List<string>()
            });
        }

        public async Task<IEnumerable<MovieDtoWithoutGenres>> GetMoviesByGenresAsync([FromQuery] IEnumerable<string> genres) 
        {
            var movies = await FindAll()
               .Where(movie => movie.Genres.Any(g => genres.Contains(g.Name)))
               .Select(movie => new MovieDtoWithoutGenres
               {
                   Id = movie.Id,
                   Title = movie.Title,
                   Director = movie.Director
               })
               .ToListAsync();

            return movies;
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            var movie = await FindByCondition(movie => movie.Id.Equals(id))
                .Include(movie => movie.Genres)
                .SingleOrDefaultAsync();

            return movie;
        }

        public async Task<Movie?> GetMovieByTitleAsync(string name)
        {
            return await FindByCondition(movie => movie.Title.Equals(name)).FirstOrDefaultAsync();
        }
    }
}