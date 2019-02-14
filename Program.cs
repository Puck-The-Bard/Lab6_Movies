using System;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;

namespace Movie_ZM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MovieDbContext())
            {
                //make sure that I am startin fresh each time
                db.Database.EnsureDeleted();
                //creating a new database if one does not exist
                db.Database.EnsureCreated();
            }

            //Add movies to the database
            using(var db = new MovieDbContext())
            {
                //add studio with movies
                Studio Fox = new Studio
                {
                    Name = "20th Century Fox",
                    Movies = new List<Movie>
                    {
                        new Movie { Title = "Avatar", Genre = "Action"},
                        new Movie { Title = "Deadpool", Genre = "Action"},
                        new Movie { Title = "Apollo 13", Genre = "Drama"},
                        new Movie { Title = "The Martian", Genre = "Sci-Fi"},
                    }
                };
                
            }
        }
    }
}
