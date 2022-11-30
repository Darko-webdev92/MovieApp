using MovieApp.DomainModels;
using MovieApp.InterfaceModels;
using MovieApp.InterfaceModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Mappers
{
    public static class MovieMapper
    {
        public static Movie ToMovie(MovieDto movie)
        {
            return new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Year = movie.Year,
                Genre = (Genre)movie.Genre,
                Description = movie.Description,
                 //UserId = movie.UserId,
            };            
        }

        public static MovieDto ToMovieDto(Movie movie)
        {
            return new MovieDto()
            {
                Title = movie.Title,
                Year = movie.Year,
                Genre = (int)movie.Genre,
                Description = movie.Description,

            };
        }
    }
}
