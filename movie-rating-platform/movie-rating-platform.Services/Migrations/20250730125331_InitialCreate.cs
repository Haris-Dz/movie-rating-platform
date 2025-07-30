using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace movie_rating_platform.Services.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieType = table.Column<int>(type: "int", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieRatings",
                columns: table => new
                {
                    MovieRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    RatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRatings", x => x.MovieRatingId);
                    table.ForeignKey(
                        name: "FK_MovieRatings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "DateOfBirth", "DeletionTime", "FirstName", "IsDeleted", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1943, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Robert", false, "De Niro" },
                    { 2, new DateTime(1937, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Morgan", false, "Freeman" },
                    { 3, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Scarlett", false, "Johansson" },
                    { 4, new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Leonardo", false, "DiCaprio" },
                    { 5, new DateTime(1981, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Natalie", false, "Portman" },
                    { 6, new DateTime(1956, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tom", false, "Hanks" },
                    { 7, new DateTime(1988, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emma", false, "Stone" },
                    { 8, new DateTime(1963, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brad", false, "Pitt" },
                    { 9, new DateTime(1982, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Anne", false, "Hathaway" },
                    { 10, new DateTime(1954, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Denzel", false, "Washington" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "AverageRating", "CoverImage", "DeletionTime", "IsDeleted", "MovieType", "ReleaseDate", "ShortDescription", "Title" },
                values: new object[,]
                {
                    { 1, 4.0, "/images/movie1.jpg", null, false, 0, new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hope is a dangerous thing.", "The Shawshank Redemption" },
                    { 2, 3.5, "/images/movie2.jpg", null, false, 0, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "An offer you can't refuse.", "The Godfather" },
                    { 3, 4.5, "/images/movie3.jpg", null, false, 0, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Why so serious?", "The Dark Knight" },
                    { 4, 2.5, "/images/movie4.jpg", null, false, 0, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Multiple stories collide.", "Pulp Fiction" },
                    { 5, 3.0, "/images/movie5.jpg", null, false, 0, new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "First rule: don't talk about it.", "Fight Club" },
                    { 6, 4.7000000000000002, "/images/movie6.jpg", null, false, 0, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dream within a dream.", "Inception" },
                    { 7, 3.2000000000000002, "/images/movie7.jpg", null, false, 0, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Life is like a box of chocolates.", "Forrest Gump" },
                    { 8, 3.7999999999999998, "/images/movie8.jpg", null, false, 0, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "What is the Matrix?", "The Matrix" },
                    { 9, 4.2999999999999998, "/images/movie9.jpg", null, false, 0, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Love transcends time and space.", "Interstellar" },
                    { 10, 4.0999999999999996, "/images/movie10.jpg", null, false, 0, new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Are you not entertained?", "Gladiator" },
                    { 11, 3.7000000000000002, "/images/movie11.jpg", null, false, 0, new DateTime(2006, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Every magic trick has a cost.", "The Prestige" },
                    { 12, 3.8999999999999999, "/images/movie12.jpg", null, false, 0, new DateTime(2006, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cops and moles collide.", "The Departed" },
                    { 13, 4.2000000000000002, "/images/movie13.jpg", null, false, 0, new DateTime(2014, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not quite my tempo.", "Whiplash" },
                    { 14, 2.8999999999999999, "/images/movie14.jpg", null, false, 0, new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Put on a happy face.", "Joker" },
                    { 15, 3.6000000000000001, "/images/movie15.jpg", null, false, 0, new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Life, liberty, and revenge.", "Django Unchained" },
                    { 16, 4.0, "/images/tvshow1.jpg", null, false, 1, new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Say my name.", "Breaking Bad" },
                    { 17, 3.2999999999999998, "/images/tvshow2.jpg", null, false, 1, new DateTime(2016, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upside Down awaits.", "Stranger Things" },
                    { 18, 4.5, "/images/tvshow3.jpg", null, false, 1, new DateTime(2011, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winter is coming.", "Game of Thrones" },
                    { 19, 3.6000000000000001, "/images/tvshow4.jpg", null, false, 1, new DateTime(2005, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "World's best boss.", "The Office" },
                    { 20, 3.7000000000000002, "/images/tvshow5.jpg", null, false, 1, new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "I'll be there for you.", "Friends" },
                    { 21, 4.7999999999999998, "/images/tvshow6.jpg", null, false, 1, new DateTime(2016, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inside royal life.", "The Crown" },
                    { 22, 4.0, "/images/tvshow7.jpg", null, false, 1, new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the way.", "The Mandalorian" },
                    { 23, 3.8999999999999999, "/images/tvshow8.jpg", null, false, 1, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toss a coin to your Witcher.", "The Witcher" },
                    { 24, 4.4000000000000004, "/images/tvshow9.jpg", null, false, 1, new DateTime(2013, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "By order of the Peaky Blinders.", "Peaky Blinders" },
                    { 25, 3.7999999999999998, "/images/tvshow10.jpg", null, false, 1, new DateTime(2019, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Superheroes gone bad.", "The Boys" },
                    { 26, 3.7000000000000002, "/images/tvshow11.jpg", null, false, 1, new DateTime(2020, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chess prodigy rises.", "The Queen's Gambit" },
                    { 27, 4.2999999999999998, "/images/tvshow12.jpg", null, false, 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Survive and protect.", "The Last of Us" },
                    { 28, 3.5, "/images/tvshow13.jpg", null, false, 1, new DateTime(2015, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legal trouble ahead.", "Better Call Saul" },
                    { 29, 4.0999999999999996, "/images/tvshow14.jpg", null, false, 1, new DateTime(2022, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fire and blood.", "House of the Dragon" },
                    { 30, 3.8999999999999999, "/images/tvshow15.jpg", null, false, 1, new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "God of Mischief returns.", "Loki" }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 4, 4 },
                    { 5, 4 },
                    { 5, 5 },
                    { 6, 5 },
                    { 6, 6 },
                    { 7, 6 },
                    { 7, 7 },
                    { 8, 7 },
                    { 8, 8 },
                    { 9, 8 },
                    { 9, 9 },
                    { 10, 9 },
                    { 1, 10 },
                    { 10, 10 },
                    { 1, 11 },
                    { 3, 11 },
                    { 2, 12 },
                    { 4, 12 },
                    { 5, 13 },
                    { 7, 13 },
                    { 6, 14 },
                    { 8, 14 },
                    { 9, 15 },
                    { 10, 15 },
                    { 1, 16 },
                    { 4, 16 },
                    { 2, 17 },
                    { 5, 17 },
                    { 3, 18 },
                    { 6, 18 },
                    { 4, 19 },
                    { 7, 19 },
                    { 5, 20 },
                    { 8, 20 },
                    { 6, 21 },
                    { 9, 21 },
                    { 7, 22 },
                    { 10, 22 },
                    { 1, 23 },
                    { 8, 23 },
                    { 2, 24 },
                    { 9, 24 },
                    { 3, 25 },
                    { 10, 25 },
                    { 1, 26 },
                    { 4, 26 },
                    { 2, 27 },
                    { 5, 27 },
                    { 3, 28 },
                    { 6, 28 },
                    { 4, 29 },
                    { 7, 29 },
                    { 5, 30 },
                    { 8, 30 }
                });

            migrationBuilder.InsertData(
                table: "MovieRatings",
                columns: new[] { "MovieRatingId", "DeletionTime", "IsDeleted", "MovieId", "RatedAt", "Rating" },
                values: new object[,]
                {
                    { 1, null, false, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 2, null, false, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 3, null, false, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, null, false, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, null, false, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 6, null, false, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, null, false, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 8, null, false, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 9, null, false, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 10, null, false, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, null, false, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, null, false, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, null, false, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, null, false, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, null, false, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, null, false, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 17, null, false, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 18, null, false, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 19, null, false, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, null, false, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, null, false, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 22, null, false, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 23, null, false, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 24, null, false, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 25, null, false, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 26, null, false, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 27, null, false, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 28, null, false, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 29, null, false, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 30, null, false, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 31, null, false, 16, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 32, null, false, 16, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 33, null, false, 16, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 34, null, false, 17, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 35, null, false, 17, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 36, null, false, 17, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 37, null, false, 18, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 38, null, false, 18, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 39, null, false, 18, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 40, null, false, 19, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 41, null, false, 19, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 42, null, false, 19, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 43, null, false, 20, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 44, null, false, 20, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 45, null, false, 20, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 46, null, false, 21, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 47, null, false, 21, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 48, null, false, 21, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 49, null, false, 22, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 50, null, false, 22, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 51, null, false, 22, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 52, null, false, 23, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 53, null, false, 23, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 54, null, false, 23, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 55, null, false, 24, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 56, null, false, 24, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 57, null, false, 24, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 58, null, false, 25, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 59, null, false, 25, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 60, null, false, 25, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 61, null, false, 26, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 62, null, false, 26, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 63, null, false, 26, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 64, null, false, 27, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 65, null, false, 27, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 66, null, false, 27, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 67, null, false, 28, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 68, null, false, 28, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 69, null, false, 28, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 70, null, false, 29, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 71, null, false, 29, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 72, null, false, 29, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 73, null, false, 30, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 74, null, false, 30, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 75, null, false, 30, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRatings_MovieId",
                table: "MovieRatings",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieRatings");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
