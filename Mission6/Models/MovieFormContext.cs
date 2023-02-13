using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Mission6.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)
        {
            //leave blank for now
        }
        public DbSet<MovieFormResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieFormResponse>().HasData(
                // add 3 entries into the database
                new MovieFormResponse
                {
                    ApplicationID = 1,
                    Category = "Action, Adventure, Drama",
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Year = "2001",
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Nobody",
                    Notes = "Great movie!"
                },
                new MovieFormResponse
                {
                    ApplicationID = 2,
                    Category = "Action, Adventure, Drama",
                    Title = "The Lord of the Rings: The Two Towers",
                    Year = "2002",
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Nobody",
                    Notes = "Has some great action scenes!"
                },
                new MovieFormResponse
                {
                    ApplicationID = 3,
                    Category = "Action, Adventure, Drama",
                    Title = "The Lord of the Rings: The Return of the Ring",
                    Year = "2003",
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Nobody",
                    Notes = "Words cannot describe how great this movie is!"
                }

                );
        }
    }
}

