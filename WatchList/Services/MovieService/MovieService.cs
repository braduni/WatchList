namespace WatchList.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _context;
        public MovieService(DataContext context)
        {
            _context = context;       
        }
        public async Task<List<Movie>> AddMovie(Movie request)
        {
            _context.Movies.Add(request);
            await _context.SaveChangesAsync();
            return await _context.Movies.ToListAsync();
        }

        public async Task<List<Movie>?> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) { return null; }
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return await _context.Movies.ToListAsync();
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies;
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) { return null; }
            return movie;
        }

        public async Task<List<Movie>?> UpdateMovie(int id, Movie request)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) { return null; }

            movie.Title = request.Title;
            movie.Genre = request.Genre;
            movie.Director = request.Director;
            
            await _context.SaveChangesAsync();
            return await _context.Movies.ToListAsync();     
        }
    }
}
