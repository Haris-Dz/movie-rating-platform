using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movie_rating_platform.Model;

namespace movie_rating_platform.Services.Database
{
    public partial class MovieRatingDBContext : DbContext
    {
        public MovieRatingDBContext() { }

        public MovieRatingDBContext(DbContextOptions<MovieRatingDBContext> options) : base(options) { }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieActor> MovieActors { get; set; }
        public virtual DbSet<MovieRating> MovieRatings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId);

            modelBuilder.Entity<Actor>().HasData(
                new Actor { ActorId = 1, FirstName = "Robert", LastName = "De Niro", DateOfBirth = new DateTime(1943, 8, 17) },
                new Actor { ActorId = 2, FirstName = "Morgan", LastName = "Freeman", DateOfBirth = new DateTime(1937, 6, 1) },
                new Actor { ActorId = 3, FirstName = "Scarlett", LastName = "Johansson", DateOfBirth = new DateTime(1984, 11, 22) },
                new Actor { ActorId = 4, FirstName = "Leonardo", LastName = "DiCaprio", DateOfBirth = new DateTime(1974, 11, 11) },
                new Actor { ActorId = 5, FirstName = "Natalie", LastName = "Portman", DateOfBirth = new DateTime(1981, 6, 9) },
                new Actor { ActorId = 6, FirstName = "Tom", LastName = "Hanks", DateOfBirth = new DateTime(1956, 7, 9) },
                new Actor { ActorId = 7, FirstName = "Emma", LastName = "Stone", DateOfBirth = new DateTime(1988, 11, 6) },
                new Actor { ActorId = 8, FirstName = "Brad", LastName = "Pitt", DateOfBirth = new DateTime(1963, 12, 18) },
                new Actor { ActorId = 9, FirstName = "Anne", LastName = "Hathaway", DateOfBirth = new DateTime(1982, 11, 12) },
                new Actor { ActorId = 10, FirstName = "Denzel", LastName = "Washington", DateOfBirth = new DateTime(1954, 12, 28) }
            );
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Title = "Movie 1", CoverImage = "/images/movie.jpg", ShortDescription = "Description 1", ReleaseDate = new DateTime(2001, 1, 1), MovieType = MovieTypeEnum.Movie, AverageRating = 4.0 },
                new Movie { MovieId = 2, Title = "Movie 2", CoverImage = "/images/movie.jpg", ShortDescription = "Description 2", ReleaseDate = new DateTime(2002, 2, 2), MovieType = MovieTypeEnum.Movie, AverageRating = 3.5 },
                new Movie { MovieId = 3, Title = "Movie 3", CoverImage = "/images/movie.jpg", ShortDescription = "Description 3", ReleaseDate = new DateTime(2003, 3, 3), MovieType = MovieTypeEnum.Movie, AverageRating = 4.5 },
                new Movie { MovieId = 4, Title = "Movie 4", CoverImage = "/images/movie.jpg", ShortDescription = "Description 4", ReleaseDate = new DateTime(2004, 4, 4), MovieType = MovieTypeEnum.Movie, AverageRating = 2.5 },
                new Movie { MovieId = 5, Title = "Movie 5", CoverImage = "/images/movie.jpg", ShortDescription = "Description 5", ReleaseDate = new DateTime(2005, 5, 5), MovieType = MovieTypeEnum.Movie, AverageRating = 3.0 },
                new Movie { MovieId = 6, Title = "Movie 6", CoverImage = "/images/movie.jpg", ShortDescription = "Description 6", ReleaseDate = new DateTime(2006, 6, 6), MovieType = MovieTypeEnum.Movie, AverageRating = 4.7 },
                new Movie { MovieId = 7, Title = "Movie 7", CoverImage = "/images/movie.jpg", ShortDescription = "Description 7", ReleaseDate = new DateTime(2007, 7, 7), MovieType = MovieTypeEnum.Movie, AverageRating = 3.2 },
                new Movie { MovieId = 8, Title = "Movie 8", CoverImage = "/images/movie.jpg", ShortDescription = "Description 8", ReleaseDate = new DateTime(2008, 8, 8), MovieType = MovieTypeEnum.Movie, AverageRating = 3.8 },
                new Movie { MovieId = 9, Title = "Movie 9", CoverImage = "/images/movie.jpg", ShortDescription = "Description 9", ReleaseDate = new DateTime(2009, 9, 9), MovieType = MovieTypeEnum.Movie, AverageRating = 4.3 },
                new Movie { MovieId = 10, Title = "Movie 10", CoverImage = "/images/movie.jpg", ShortDescription = "Description 10", ReleaseDate = new DateTime(2010, 10, 10), MovieType = MovieTypeEnum.Movie, AverageRating = 4.1 },
                new Movie { MovieId = 11, Title = "Movie 11", CoverImage = "/images/movie.jpg", ShortDescription = "Description 11", ReleaseDate = new DateTime(2011, 11, 11), MovieType = MovieTypeEnum.Movie, AverageRating = 3.7 },
                new Movie { MovieId = 12, Title = "Movie 12", CoverImage = "/images/movie.jpg", ShortDescription = "Description 12", ReleaseDate = new DateTime(2012, 12, 12), MovieType = MovieTypeEnum.Movie, AverageRating = 3.9 },
                new Movie { MovieId = 13, Title = "Movie 13", CoverImage = "/images/movie.jpg", ShortDescription = "Description 13", ReleaseDate = new DateTime(2013, 1, 13), MovieType = MovieTypeEnum.Movie, AverageRating = 4.2 },
                new Movie { MovieId = 14, Title = "Movie 14", CoverImage = "/images/movie.jpg", ShortDescription = "Description 14", ReleaseDate = new DateTime(2014, 2, 14), MovieType = MovieTypeEnum.Movie, AverageRating = 2.9 },
                new Movie { MovieId = 15, Title = "Movie 15", CoverImage = "/images/movie.jpg", ShortDescription = "Description 15", ReleaseDate = new DateTime(2015, 3, 15), MovieType = MovieTypeEnum.Movie, AverageRating = 3.6 },
                new Movie { MovieId = 16, Title = "TV Show 1", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 1", ReleaseDate = new DateTime(2016, 4, 1), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.0 },
                new Movie { MovieId = 17, Title = "TV Show 2", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 2", ReleaseDate = new DateTime(2017, 5, 2), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.3 },
                new Movie { MovieId = 18, Title = "TV Show 3", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 3", ReleaseDate = new DateTime(2018, 6, 3), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.5 },
                new Movie { MovieId = 19, Title = "TV Show 4", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 4", ReleaseDate = new DateTime(2019, 7, 4), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.6 },
                new Movie { MovieId = 20, Title = "TV Show 5", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 5", ReleaseDate = new DateTime(2020, 8, 5), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.7 },
                new Movie { MovieId = 21, Title = "TV Show 6", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 6", ReleaseDate = new DateTime(2021, 9, 6), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.8 },
                new Movie { MovieId = 22, Title = "TV Show 7", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 7", ReleaseDate = new DateTime(2022, 10, 7), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.0 },
                new Movie { MovieId = 23, Title = "TV Show 8", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 8", ReleaseDate = new DateTime(2023, 11, 8), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.9 },
                new Movie { MovieId = 24, Title = "TV Show 9", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 9", ReleaseDate = new DateTime(2024, 12, 9), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.4 },
                new Movie { MovieId = 25, Title = "TV Show 10", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 10", ReleaseDate = new DateTime(2025, 1, 10), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.8 },
                new Movie { MovieId = 26, Title = "TV Show 11", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 11", ReleaseDate = new DateTime(2026, 2, 11), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.7 },
                new Movie { MovieId = 27, Title = "TV Show 12", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 12", ReleaseDate = new DateTime(2027, 3, 12), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.3 },
                new Movie { MovieId = 28, Title = "TV Show 13", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 13", ReleaseDate = new DateTime(2028, 4, 13), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.5 },
                new Movie { MovieId = 29, Title = "TV Show 14", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 14", ReleaseDate = new DateTime(2029, 5, 14), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.1 },
                new Movie { MovieId = 30, Title = "TV Show 15", CoverImage = "/images/tvshow.jpg", ShortDescription = "Description 15", ReleaseDate = new DateTime(2030, 6, 15), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.9 }
            );
            modelBuilder.Entity<MovieActor>().HasData(
                new MovieActor { MovieId = 1, ActorId = 1 },
                new MovieActor { MovieId = 1, ActorId = 2 },
                new MovieActor { MovieId = 2, ActorId = 2 },
                new MovieActor { MovieId = 2, ActorId = 3 },
                new MovieActor { MovieId = 3, ActorId = 3 },
                new MovieActor { MovieId = 3, ActorId = 4 },
                new MovieActor { MovieId = 4, ActorId = 4 },
                new MovieActor { MovieId = 4, ActorId = 5 },
                new MovieActor { MovieId = 5, ActorId = 5 },
                new MovieActor { MovieId = 5, ActorId = 6 },
                new MovieActor { MovieId = 6, ActorId = 6 },
                new MovieActor { MovieId = 6, ActorId = 7 },
                new MovieActor { MovieId = 7, ActorId = 7 },
                new MovieActor { MovieId = 7, ActorId = 8 },
                new MovieActor { MovieId = 8, ActorId = 8 },
                new MovieActor { MovieId = 8, ActorId = 9 },
                new MovieActor { MovieId = 9, ActorId = 9 },
                new MovieActor { MovieId = 9, ActorId = 10 },
                new MovieActor { MovieId = 10, ActorId = 10 },
                new MovieActor { MovieId = 10, ActorId = 1 },
                new MovieActor { MovieId = 11, ActorId = 1 },
                new MovieActor { MovieId = 11, ActorId = 3 },
                new MovieActor { MovieId = 12, ActorId = 2 },
                new MovieActor { MovieId = 12, ActorId = 4 },
                new MovieActor { MovieId = 13, ActorId = 5 },
                new MovieActor { MovieId = 13, ActorId = 7 },
                new MovieActor { MovieId = 14, ActorId = 6 },
                new MovieActor { MovieId = 14, ActorId = 8 },
                new MovieActor { MovieId = 15, ActorId = 9 },
                new MovieActor { MovieId = 15, ActorId = 10 },
                new MovieActor { MovieId = 16, ActorId = 1 },
                new MovieActor { MovieId = 16, ActorId = 4 },
                new MovieActor { MovieId = 17, ActorId = 2 },
                new MovieActor { MovieId = 17, ActorId = 5 },
                new MovieActor { MovieId = 18, ActorId = 3 },
                new MovieActor { MovieId = 18, ActorId = 6 },
                new MovieActor { MovieId = 19, ActorId = 4 },
                new MovieActor { MovieId = 19, ActorId = 7 },
                new MovieActor { MovieId = 20, ActorId = 5 },
                new MovieActor { MovieId = 20, ActorId = 8 },
                new MovieActor { MovieId = 21, ActorId = 6 },
                new MovieActor { MovieId = 21, ActorId = 9 },
                new MovieActor { MovieId = 22, ActorId = 7 },
                new MovieActor { MovieId = 22, ActorId = 10 },
                new MovieActor { MovieId = 23, ActorId = 8 },
                new MovieActor { MovieId = 23, ActorId = 1 },
                new MovieActor { MovieId = 24, ActorId = 9 },
                new MovieActor { MovieId = 24, ActorId = 2 },
                new MovieActor { MovieId = 25, ActorId = 10 },
                new MovieActor { MovieId = 25, ActorId = 3 },
                new MovieActor { MovieId = 26, ActorId = 1 },
                new MovieActor { MovieId = 26, ActorId = 4 },
                new MovieActor { MovieId = 27, ActorId = 2 },
                new MovieActor { MovieId = 27, ActorId = 5 },
                new MovieActor { MovieId = 28, ActorId = 3 },
                new MovieActor { MovieId = 28, ActorId = 6 },
                new MovieActor { MovieId = 29, ActorId = 4 },
                new MovieActor { MovieId = 29, ActorId = 7 },
                new MovieActor { MovieId = 30, ActorId = 5 },
                new MovieActor { MovieId = 30, ActorId = 8 }
            );
            modelBuilder.Entity<MovieRating>().HasData(
                new MovieRating { MovieRatingId = 1, MovieId = 1, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 2, MovieId = 1, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 3, MovieId = 1, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 4, MovieId = 2, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 5, MovieId = 2, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 6, MovieId = 2, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 7, MovieId = 3, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 8, MovieId = 3, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 9, MovieId = 3, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 10, MovieId = 4, Rating = 2, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 11, MovieId = 4, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 12, MovieId = 4, Rating = 2, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 13, MovieId = 5, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 14, MovieId = 5, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 15, MovieId = 5, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 16, MovieId = 6, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 17, MovieId = 6, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 18, MovieId = 6, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 19, MovieId = 7, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 20, MovieId = 7, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 21, MovieId = 7, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 22, MovieId = 8, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 23, MovieId = 8, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 24, MovieId = 8, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 25, MovieId = 9, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 26, MovieId = 9, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 27, MovieId = 9, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 28, MovieId = 10, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 29, MovieId = 10, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 30, MovieId = 10, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                //tvshows
                new MovieRating { MovieRatingId = 31, MovieId = 16, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 32, MovieId = 16, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 33, MovieId = 16, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 34, MovieId = 17, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 35, MovieId = 17, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 36, MovieId = 17, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 37, MovieId = 18, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 38, MovieId = 18, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 39, MovieId = 18, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 40, MovieId = 19, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 41, MovieId = 19, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 42, MovieId = 19, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 43, MovieId = 20, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 44, MovieId = 20, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 45, MovieId = 20, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 46, MovieId = 21, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 47, MovieId = 21, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 48, MovieId = 21, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 49, MovieId = 22, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 50, MovieId = 22, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 51, MovieId = 22, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 52, MovieId = 23, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 53, MovieId = 23, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 54, MovieId = 23, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 55, MovieId = 24, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 56, MovieId = 24, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 57, MovieId = 24, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 58, MovieId = 25, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 59, MovieId = 25, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 60, MovieId = 25, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 61, MovieId = 26, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 62, MovieId = 26, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 63, MovieId = 26, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 64, MovieId = 27, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 65, MovieId = 27, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 66, MovieId = 27, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 67, MovieId = 28, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 68, MovieId = 28, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 69, MovieId = 28, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 70, MovieId = 29, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 71, MovieId = 29, Rating = 5, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 72, MovieId = 29, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 73, MovieId = 30, Rating = 3, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 74, MovieId = 30, Rating = 4, RatedAt = new DateTime(2025, 1, 1) },
                new MovieRating { MovieRatingId = 75, MovieId = 30, Rating = 5, RatedAt = new DateTime(2025, 1, 1) }
            );



        }

    }
}
