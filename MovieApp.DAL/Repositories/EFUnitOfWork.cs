using MovieApp.DAL.Entities;
using MovieApp.DAL.Interfaces;
using System.Threading.Tasks;

public class UnitOfWork : IUnitOfWork
{
    private readonly MovieContext _context;

    public UnitOfWork(MovieContext context, IRepository<Movie> movieRepository)
    {
        _context = context;
        Movies = movieRepository;
    }

    public IRepository<Movie> Movies { get; private set; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}