using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.BLL.Interfaces;
using MovieApp.BLL.DTO;
using MovieApp.DAL.Interfaces;
using MovieApp.DAL.Entities;

namespace MovieApp.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _unitOfWork.Movies.GetAllAsync();
            return movies.Select(movie => new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Director = movie.Director,
                Year = movie.ReleaseDate.Year,
                Description = movie.Description
            });
        }

        public async Task<MovieDto> GetMovieByIdAsync(int id)
        {
            var movie = await _unitOfWork.Movies.GetByIdAsync(id);
            if (movie == null)
                return null;

            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Director = movie.Director,
                Year = movie.ReleaseDate.Year,
                Description = movie.Description
            };
        }

        public async Task AddMovieAsync(MovieDto movieDto)
        {
            var movie = new Movie
            {
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                Director = movieDto.Director,
                ReleaseDate = new DateTime(movieDto.Year, 1, 1),
                Description = movieDto.Description
            };

            await _unitOfWork.Movies.AddAsync(movie);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateMovieAsync(MovieDto movieDto)
        {
            var movie = await _unitOfWork.Movies.GetByIdAsync(movieDto.Id);
            if (movie != null)
            {
                movie.Title = movieDto.Title;
                movie.Genre = movieDto.Genre;
                movie.Director = movieDto.Director;
                movie.ReleaseDate = new DateTime(movieDto.Year, 1, 1);
                movie.Description = movieDto.Description;

                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task DeleteMovieAsync(int id)
        {
            await _unitOfWork.Movies.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}