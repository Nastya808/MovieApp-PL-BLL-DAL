using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.BLL.DTO;

namespace MovieApp.BLL.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto> GetMovieByIdAsync(int id);
        Task AddMovieAsync(MovieDto movieDto);
        Task UpdateMovieAsync(MovieDto movieDto);
        Task DeleteMovieAsync(int id);
    }
}