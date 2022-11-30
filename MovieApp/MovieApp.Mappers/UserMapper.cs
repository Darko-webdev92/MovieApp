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
    public static class UserMapper
    {
        public static User ToUser(UserDto model)
        {
            return new User { 
                FirstName = model.FirstName, 
                LastName = model.LastName,
                FavoriteGenre = (Genre)model.FavoriteGenre,
                Username = model.Username,
                Movies = model.Movies.Select(movie => MovieMapper.ToMovie(movie)).ToList(),
            };
        }
    }
}
