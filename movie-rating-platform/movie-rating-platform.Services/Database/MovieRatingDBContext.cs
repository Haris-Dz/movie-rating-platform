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
                new Movie { MovieId = 1, Title = "The Shawshank Redemption", CoverImage = "/images/movie1.jpg", ShortDescription = "Hope is a dangerous thing.", ReleaseDate = new DateTime(1994, 9, 22), MovieType = MovieTypeEnum.Movie, AverageRating = 4.0 },
                new Movie { MovieId = 2, Title = "The Godfather", CoverImage = "/images/movie2.jpg", ShortDescription = "An offer you can't refuse.", ReleaseDate = new DateTime(1972, 3, 24), MovieType = MovieTypeEnum.Movie, AverageRating = 3.5 },
                new Movie { MovieId = 3, Title = "The Dark Knight", CoverImage = "/images/movie3.jpg", ShortDescription = "Why so serious?", ReleaseDate = new DateTime(2008, 7, 18), MovieType = MovieTypeEnum.Movie, AverageRating = 4.5 },
                new Movie { MovieId = 4, Title = "Pulp Fiction", CoverImage = "/images/movie4.jpg", ShortDescription = "Multiple stories collide.", ReleaseDate = new DateTime(1994, 10, 14), MovieType = MovieTypeEnum.Movie, AverageRating = 2.5 },
                new Movie { MovieId = 5, Title = "Fight Club", CoverImage = "/images/movie5.jpg", ShortDescription = "First rule: don't talk about it.", ReleaseDate = new DateTime(1999, 10, 15), MovieType = MovieTypeEnum.Movie, AverageRating = 3.0 },
                new Movie { MovieId = 6, Title = "Inception", CoverImage = "/images/movie6.jpg", ShortDescription = "Dream within a dream.", ReleaseDate = new DateTime(2010, 7, 16), MovieType = MovieTypeEnum.Movie, AverageRating = 4.7 },
                new Movie { MovieId = 7, Title = "Forrest Gump", CoverImage = "/images/movie7.jpg", ShortDescription = "Life is like a box of chocolates.", ReleaseDate = new DateTime(1994, 7, 6), MovieType = MovieTypeEnum.Movie, AverageRating = 3.2 },
                new Movie { MovieId = 8, Title = "The Matrix", CoverImage = "/images/movie8.jpg", ShortDescription = "What is the Matrix?", ReleaseDate = new DateTime(1999, 3, 31), MovieType = MovieTypeEnum.Movie, AverageRating = 3.8 },
                new Movie { MovieId = 9, Title = "Interstellar", CoverImage = "/images/movie9.jpg", ShortDescription = "Love transcends time and space.", ReleaseDate = new DateTime(2014, 11, 7), MovieType = MovieTypeEnum.Movie, AverageRating = 4.3 },
                new Movie { MovieId = 10, Title = "Gladiator", CoverImage = "/images/movie10.jpg", ShortDescription = "Are you not entertained?", ReleaseDate = new DateTime(2000, 5, 5), MovieType = MovieTypeEnum.Movie, AverageRating = 4.1 },
                new Movie { MovieId = 11, Title = "The Prestige", CoverImage = "/images/movie11.jpg", ShortDescription = "Every magic trick has a cost.", ReleaseDate = new DateTime(2006, 10, 20), MovieType = MovieTypeEnum.Movie, AverageRating = 3.7 },
                new Movie { MovieId = 12, Title = "The Departed", CoverImage = "/images/movie12.jpg", ShortDescription = "Cops and moles collide.", ReleaseDate = new DateTime(2006, 10, 6), MovieType = MovieTypeEnum.Movie, AverageRating = 3.9 },
                new Movie { MovieId = 13, Title = "Whiplash", CoverImage = "/images/movie13.jpg", ShortDescription = "Not quite my tempo.", ReleaseDate = new DateTime(2014, 10, 10), MovieType = MovieTypeEnum.Movie, AverageRating = 4.2 },
                new Movie { MovieId = 14, Title = "Joker", CoverImage = "/images/movie14.jpg", ShortDescription = "Put on a happy face.", ReleaseDate = new DateTime(2019, 10, 4), MovieType = MovieTypeEnum.Movie, AverageRating = 2.9 },
                new Movie { MovieId = 15, Title = "Django Unchained", CoverImage = "/images/movie15.jpg", ShortDescription = "Life, liberty, and revenge.", ReleaseDate = new DateTime(2012, 12, 25), MovieType = MovieTypeEnum.Movie, AverageRating = 3.6 },
                new Movie { MovieId = 16, Title = "Breaking Bad", CoverImage = "/images/tvshow1.jpg", ShortDescription = "Say my name.", ReleaseDate = new DateTime(2008, 1, 20), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.0 },
                new Movie { MovieId = 17, Title = "Stranger Things", CoverImage = "/images/tvshow2.jpg", ShortDescription = "Upside Down awaits.", ReleaseDate = new DateTime(2016, 7, 15), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.3 },
                new Movie { MovieId = 18, Title = "Game of Thrones", CoverImage = "/images/tvshow3.jpg", ShortDescription = "Winter is coming.", ReleaseDate = new DateTime(2011, 4, 17), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.5 },
                new Movie { MovieId = 19, Title = "The Office", CoverImage = "/images/tvshow4.jpg", ShortDescription = "World's best boss.", ReleaseDate = new DateTime(2005, 3, 24), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.6 },
                new Movie { MovieId = 20, Title = "Friends", CoverImage = "/images/tvshow5.jpg", ShortDescription = "I'll be there for you.", ReleaseDate = new DateTime(1994, 9, 22), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.7 },
                new Movie { MovieId = 21, Title = "The Crown", CoverImage = "/images/tvshow6.jpg", ShortDescription = "Inside royal life.", ReleaseDate = new DateTime(2016, 11, 4), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.8 },
                new Movie { MovieId = 22, Title = "The Mandalorian", CoverImage = "/images/tvshow7.jpg", ShortDescription = "This is the way.", ReleaseDate = new DateTime(2019, 11, 12), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.0 },
                new Movie { MovieId = 23, Title = "The Witcher", CoverImage = "/images/tvshow8.jpg", ShortDescription = "Toss a coin to your Witcher.", ReleaseDate = new DateTime(2019, 12, 20), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.9 },
                new Movie { MovieId = 24, Title = "Peaky Blinders", CoverImage = "/images/tvshow9.jpg", ShortDescription = "By order of the Peaky Blinders.", ReleaseDate = new DateTime(2013, 9, 12), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.4 },
                new Movie { MovieId = 25, Title = "The Boys", CoverImage = "/images/tvshow10.jpg", ShortDescription = "Superheroes gone bad.", ReleaseDate = new DateTime(2019, 7, 26), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.8 },
                new Movie { MovieId = 26, Title = "The Queen's Gambit", CoverImage = "/images/tvshow11.jpg", ShortDescription = "Chess prodigy rises.", ReleaseDate = new DateTime(2020, 10, 23), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.7 },
                new Movie { MovieId = 27, Title = "The Last of Us", CoverImage = "/images/tvshow12.jpg", ShortDescription = "Survive and protect.", ReleaseDate = new DateTime(2023, 1, 15), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.3 },
                new Movie { MovieId = 28, Title = "Better Call Saul", CoverImage = "/images/tvshow13.jpg", ShortDescription = "Legal trouble ahead.", ReleaseDate = new DateTime(2015, 2, 8), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.5 },
                new Movie { MovieId = 29, Title = "House of the Dragon", CoverImage = "/images/tvshow14.jpg", ShortDescription = "Fire and blood.", ReleaseDate = new DateTime(2022, 8, 21), MovieType = MovieTypeEnum.TVShow, AverageRating = 4.1 },
                new Movie { MovieId = 30, Title = "Loki", CoverImage = "/images/tvshow15.jpg", ShortDescription = "God of Mischief returns.", ReleaseDate = new DateTime(2021, 6, 9), MovieType = MovieTypeEnum.TVShow, AverageRating = 3.9 }
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
