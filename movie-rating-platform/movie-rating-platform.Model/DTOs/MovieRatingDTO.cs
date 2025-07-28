using System;
using System.Collections.Generic;
using System.Text;

namespace movie_rating_platform.Model.DTOs
{
    public class MovieRatingDTO
    {
        public int MovieRatingId { get; set; }
        public int Rating { get; set; }
        public DateTime RatedAt { get; set; }
        public int MovieId { get; set; }
    }
}
