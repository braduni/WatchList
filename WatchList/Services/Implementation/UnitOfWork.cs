using WatchList.Services.Repository;

namespace WatchList.Services.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext dataContext)
        {
            _context = dataContext;
            MovieRepository = new MovieRepository(_context);
            GenreRepository = new GenreRepository(_context);
        }

        public IMovieRepository MovieRepository { get; private set; }
        public IGenreRepository GenreRepository { get; private set; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}