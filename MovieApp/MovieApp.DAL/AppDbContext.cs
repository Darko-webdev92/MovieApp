using Microsoft.EntityFrameworkCore;
using MovieApp.DomainModels;
using MovieApp.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DAL
{
    public class AppDbContext : DbContext
    {
        private readonly IStringHasher _hasher;

        public AppDbContext(DbContextOptions options, IStringHasher hasher) : base(options)
        {
            _hasher = hasher;
        }

        public DbSet<MovieDto> Movies { get; set; }
        public DbSet<UserDto> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //configure relations
            modelBuilder.Entity<MovieDto>()
                .HasOne(n => n.User)
                .WithMany(u => u.Movies)
                .HasForeignKey(n => n.UserId);


            modelBuilder.Entity<MovieDto>()
                .HasData(new MovieDto
                {
                    Id = 1,
                    Year = 2010,
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                    Genre = 1,
                    Title = "Inception",
                    UserId = 1,

                },
             new MovieDto
             {
                 Id = 2,
                 Year = 2012,
                 Description = "Eight years after the Joker's reign of anarchy, Batman, with the help of the enigmatic Catwoman, is forced from his exile to save Gotham City from the brutal guerrilla terrorist Bane.",
                 Genre = 1,
                 Title = "The Dark Knight Rises",
                 UserId = 1,

             },
             new MovieDto
             {
                 Id = 3,
                 Year = 2009,
                 Description = "Three buddies wake up from a bachelor party in Las Vegas, with no memory of the previous night and the bachelor missing. They make their way around the city in order to find their friend before his wedding.",
                 Genre = 2,
                 Title = "The Hangover",
                 UserId = 1,

             },
             new MovieDto
             {
                 Id = 4,
                 Year = 2011,
                 Description = "Two years after the bachelor party in Las Vegas, Phil, Stu, Alan, and Doug jet to Thailand for Stu's wedding. Stu's plan for a subdued pre-wedding brunch, however, goes seriously awry.",
                 Genre = 2,
                 Title = "The Hangover Part II",
                 UserId = 1,

             },
             new MovieDto
             {
                 Id = 5,
                 Year = 1995,
                 Description = "A sole survivor tells of the twisty events leading up to a horrific gun battle on a boat, which began when five criminals met at a seemingly random police lineup.",
                 Genre = 3,
                 Title = "The Usual Suspects",
                  UserId = 1,

             },
             new MovieDto
             {
                 Id = 6,
                 Year = 1996,
                 Description = "An altar boy is accused of murdering a priest, and the truth is buried several layers deep.",
                 Genre = 3,
                 Title = "Primal Fear",
                  UserId = 1,

             },
             new MovieDto
             {
                 Id = 7,
                 Year = 1997,
                 Description = "After a wealthy San Francisco banker is given an opportunity to participate in a mysterious game, his life is turned upside down as he begins to question if it might really be a concealed conspiracy to destroy him.",
                 Genre = 4,
                 Title = "The Game",
                  UserId = 1,

             },
              new MovieDto
              {
                  Id = 8,
                  Year = 1995,
                  Description = "Two detectives, a rookie and a veteran, hunt a serial killer who uses the seven deadly sins as his motives.",
                  Genre = 4,
                  Title = "Se7en",
                  UserId = 1,
              },
              new MovieDto
              {
                  Id = 9,
                  Year = 1994,
                  Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                  Genre = 4,
                  Title = "Pulp Fiction",
                  UserId = 1,
              });



            modelBuilder.Entity<UserDto>()
                .HasData(new UserDto
                {
                    Id = 1,
                    FavoriteGenre = 2,
                    FirstName = "Darko",
                    LastName = "Angelovski",
                    Password = _hasher.HashGenerator("12345"),
                    Username = "dare1992",
                });

        }

    }
}
