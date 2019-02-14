using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Movie_ZM
{
    public class MovieDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = MovieDb.db");
        }
        public DbSet<Movie> Movies {get; set;}
        public DbSet<Studio> Studios {get; set;}
    }

    public class Movie
    {
        public int MovieID {get; set;} //PK

        public string Title {get; set;}

        public string Genre {get; set;}

        public string studio {get; set;} //FK

        public Studio Studio {get; set;} //navigation property, every movie has 1 studio
    }

    public class Studio
    {
        public int StudioID {get; set;}

        public string Name {get; set;}

        public List<Movie> Movies {get; set;} // navigation property
    }
}