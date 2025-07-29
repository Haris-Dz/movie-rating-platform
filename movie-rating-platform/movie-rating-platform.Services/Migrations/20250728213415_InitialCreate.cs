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
                    { 1, 4.0, "/images/movie.jpg", null, false, 0, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 1", "Movie 1" },
                    { 2, 3.5, "/images/movie.jpg", null, false, 0, new DateTime(2002, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 2", "Movie 2" },
                    { 3, 4.5, "/images/movie.jpg", null, false, 0, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 3", "Movie 3" },
                    { 4, 2.5, "/images/movie.jpg", null, false, 0, new DateTime(2004, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 4", "Movie 4" },
                    { 5, 3.0, "/images/movie.jpg", null, false, 0, new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 5", "Movie 5" },
                    { 6, 4.7000000000000002, "/images/movie.jpg", null, false, 0, new DateTime(2006, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 6", "Movie 6" },
                    { 7, 3.2000000000000002, "/images/movie.jpg", null, false, 0, new DateTime(2007, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 7", "Movie 7" },
                    { 8, 3.7999999999999998, "/images/movie.jpg", null, false, 0, new DateTime(2008, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 8", "Movie 8" },
                    { 9, 4.2999999999999998, "/images/movie.jpg", null, false, 0, new DateTime(2009, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 9", "Movie 9" },
                    { 10, 4.0999999999999996, "/images/movie.jpg", null, false, 0, new DateTime(2010, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 10", "Movie 10" },
                    { 11, 3.7000000000000002, "/images/movie.jpg", null, false, 0, new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 11", "Movie 11" },
                    { 12, 3.8999999999999999, "/images/movie.jpg", null, false, 0, new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 12", "Movie 12" },
                    { 13, 4.2000000000000002, "/images/movie.jpg", null, false, 0, new DateTime(2013, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 13", "Movie 13" },
                    { 14, 2.8999999999999999, "/images/movie.jpg", null, false, 0, new DateTime(2014, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 14", "Movie 14" },
                    { 15, 3.6000000000000001, "/images/movie.jpg", null, false, 0, new DateTime(2015, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 15", "Movie 15" },
                    { 16, 4.0, "/images/tvshow.jpg", null, false, 1, new DateTime(2016, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 1", "TV Show 1" },
                    { 17, 3.2999999999999998, "/images/tvshow.jpg", null, false, 1, new DateTime(2017, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 2", "TV Show 2" },
                    { 18, 4.5, "/images/tvshow.jpg", null, false, 1, new DateTime(2018, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 3", "TV Show 3" },
                    { 19, 3.6000000000000001, "/images/tvshow.jpg", null, false, 1, new DateTime(2019, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 4", "TV Show 4" },
                    { 20, 3.7000000000000002, "/images/tvshow.jpg", null, false, 1, new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 5", "TV Show 5" },
                    { 21, 4.7999999999999998, "/images/tvshow.jpg", null, false, 1, new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 6", "TV Show 6" },
                    { 22, 4.0, "/images/tvshow.jpg", null, false, 1, new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 7", "TV Show 7" },
                    { 23, 3.8999999999999999, "/images/tvshow.jpg", null, false, 1, new DateTime(2023, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 8", "TV Show 8" },
                    { 24, 4.4000000000000004, "/images/tvshow.jpg", null, false, 1, new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 9", "TV Show 9" },
                    { 25, 3.7999999999999998, "/images/tvshow.jpg", null, false, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 10", "TV Show 10" },
                    { 26, 3.7000000000000002, "/images/tvshow.jpg", null, false, 1, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 11", "TV Show 11" },
                    { 27, 4.2999999999999998, "/images/tvshow.jpg", null, false, 1, new DateTime(2027, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 12", "TV Show 12" },
                    { 28, 3.5, "/images/tvshow.jpg", null, false, 1, new DateTime(2028, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 13", "TV Show 13" },
                    { 29, 4.0999999999999996, "/images/tvshow.jpg", null, false, 1, new DateTime(2029, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 14", "TV Show 14" },
                    { 30, 3.8999999999999999, "/images/tvshow.jpg", null, false, 1, new DateTime(2030, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 15", "TV Show 15" }
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
