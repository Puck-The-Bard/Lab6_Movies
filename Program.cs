using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


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
                // add fox as a studio with ovies attached and save changes
                db.Add(Fox);
                db.SaveChanges();


                //Adding universal pictures to database with no movies
                Studio Universal = new Studio
                {
                    Name = "Universal Pictures",
                    Movies = new List<Movie>
                    {

                    }
                };
                db.Add(Universal);
                db.SaveChanges();
            }

            //Adding Jurassic park to Universal Pictures list
            using(var db = new MovieDbContext())
            {
                
                Movie Jurassic = new Movie{Title = "Jurassic Park", Genre = "Action"};
                //adding it to Universals list
                Studio UniversalUpdate = db.Studios.Include(b => b.Movies).Where(b => b.StudioID == 2).First();
                UniversalUpdate.Movies.Add(Jurassic);
                db.SaveChanges();
            }

            //Moving apollo 13 from Fox to Universal
            using(var db = new MovieDbContext())
            {
                //select movie
                Movie apolloMove = db.Movies.Where(b => b.Title == "Apollo 13").First();
                //move to Universal
                apolloMove.Studio = db.Studios.Where(p => p.StudioID == 2).First();
                db.SaveChanges();
            }

            //Remove Deadpool
            using(var db = new MovieDbContext())
            {
                Movie DeleteDeadpool = db.Movies.Where(b => b.Title == "Deadpool").First();
                db.Remove(DeleteDeadpool);
                db.SaveChanges();
            }


            //List studios and movies
            using (var db = new MovieDbContext())
            {
                var StudiosWithMovies = db.Studios.Include(b => b.Movies);
                foreach(var s in StudiosWithMovies)
                {
                    Console.WriteLine(s);
                    foreach(var m in s.Movies)
                    {
                        Console.WriteLine("\t - " + m);
                    }

                }
            }
        }
    }
}
