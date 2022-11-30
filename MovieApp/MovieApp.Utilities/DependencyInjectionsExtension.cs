//using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.DAL.Repositories.Implementations;
using MovieApp.DAL.Repositories.Interfaces;
using MovieApp.DomainModels;
using MovieApp.Helpers;
using MovieApp.Helpers.Interfaces;
using MovieApp.Services.Implementations;
using MovieApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Utilities
{
    public static class DependencyInjectionsExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IStringHasher, StringHasher>();
            services.AddScoped<ILoggerService, LoggerService>();


            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            //services.AddScoped<IMovieRepository<MovieDto>, MovieStaticDbRepository>();
            services.AddScoped<IMovieRepository<MovieDto>, MovieEntityRepository>();
            //services.AddScoped<IUserRepository<UserDto>, UserStaticDbRepository>();
            services.AddScoped<IUserRepository<UserDto>, UserEntityRepository>();


            return services;
        }
    }
}
