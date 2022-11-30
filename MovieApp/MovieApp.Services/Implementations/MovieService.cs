using MovieApp.DAL.Repositories.Interfaces;
using MovieApp.DomainModels;
using MovieApp.InterfaceModels;
using MovieApp.InterfaceModels.Enums;
using MovieApp.Mappers;
using MovieApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementations
{
    public class MovieService : IMovieService
    {

        private readonly IMovieRepository<MovieDto> _movieRepository;

        public MovieService(IMovieRepository<MovieDto> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public void Create(Movie movie, int userId)
        {
            if(movie != null)
            {
                MovieDto model = new MovieDto
                {
                    Title = movie.Title,
                    Description = movie.Description,
                    Genre = (int)movie.Genre,
                    Year = movie.Year,
                    UserId = userId
                };
                _movieRepository.Create(model);
            }
        }

        public List<Movie> GetAll()
        {
            var moviesDto = _movieRepository.GetAll();
            var movies = new List<Movie>();

            foreach (var movie in moviesDto)
            {
                movies.Add(MovieMapper.ToMovie(movie));
            }

            return movies;
        }

        public List<Movie> GetByGenre(int genre)
        {
            var moviesDto = _movieRepository.GetByGanre(genre);
            var movies = new List<Movie>();

            foreach (var movie in moviesDto)
            {
                movies.Add(MovieMapper.ToMovie(movie));
            }

            return movies;

        }

        public Movie GetById(int id)
        {
          var movie = _movieRepository.GetById(id);
            return new Movie()
            {
                Title = movie.Title,
                Year = movie.Year,
                Description = movie.Description,
                Genre = (Genre)movie.Genre
            };
        }

        public List<Movie> GetByUserId(int userId)
        {
            var moviesByUserId = _movieRepository.GetByUserId(userId);
            List<Movie> movies = new List<Movie>();
            foreach (var movie in moviesByUserId)
            {
                movies.Add(MovieMapper.ToMovie(movie));
            }

            return movies;

        }
    }
}
