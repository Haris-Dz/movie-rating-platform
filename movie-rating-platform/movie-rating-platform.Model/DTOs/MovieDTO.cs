using System;
using System.Collections.Generic;
using System.Text;

namespace movie_rating_platform.Model.DTOs
{
    public class MovieDTO
    {
        public int MovieId { get; set; }

        public string Title { get; set; } = null!;

        public string CoverImage { get; set; } = null!;

        public string? ShortDescription { get; set; }

        public DateTime ReleaseDate { get; set; }

        public MovieTypeEnum MovieType { get; set; }
        public double? AverageRating { get; set; }
        public List<ActorDTO> Actors { get; set; } = new List<ActorDTO>();
        public List<MovieRatingDTO> MovieRatings { get; set; } = new List<MovieRatingDTO>();

    }
}
