//using Microsoft.Extensions.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieApp.DAL.Repositories.Interfaces;
using MovieApp.DomainModels;
using MovieApp.Helpers.Interfaces;
using MovieApp.InterfaceModels;
using MovieApp.Mappers;
using MovieApp.Services.Interfaces;
using MovieApp.Utilities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<UserDto> _userRepository;
        private readonly JwtConfig _jwtConfig;
        private readonly IStringHasher _passwordHasher;
        public UserService(IUserRepository<UserDto> userRepository, IOptions<JwtConfig> jwtConfig,
                           IStringHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtConfig = jwtConfig.Value;
            _passwordHasher = passwordHasher;
        }
        public void Register(Register model)
        {
            if (!model.Password.Equals(model.ConfirmPassword))
            {
                throw new Exception("Passwords don't match");
            }
            if (ValidateUsername(model.Username))
            {
                throw new Exception("Username already exists");
            }

            UserDto user = new UserDto()
            {
                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = _passwordHasher.HashGenerator(model.Password),
            };
            _userRepository.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            List<User> result = new List<User>();

            foreach (var user in users)
            {
                //User obj = new User()
                //{
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Username = user.Username,
                //    FavoriteGenre = user.FavoriteGenre,
                //    Movies = user.Movies
                //};
                //result.Add(obj);
                result.Add(UserMapper.ToUser(user));
            }
            return result;
        }

        public bool ValidateUsername(string username)
        {
            return _userRepository.GetAll().Any(x => x.Username == username);
        }



        public string GenerateJwtToken(UserDto model)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptior = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Name, $"{model.FirstName} {model.LastName}"),
                        new Claim(JwtRegisteredClaimNames.NameId, model.Id.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }

        public User Authenticate(Login model)
        {
            var password = _passwordHasher.HashGenerator(model.Password);
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Username == model.Username && x.Password == password);
            if (user == null)
            {
                throw new Exception("Something happend");
            };

            string token = GenerateJwtToken(user);

            return new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Token = token,
            };
        }
    }
}
