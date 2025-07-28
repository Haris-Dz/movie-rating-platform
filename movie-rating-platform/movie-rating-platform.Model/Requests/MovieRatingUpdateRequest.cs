using System;
using System.Collections.Generic;
using System.Text;

namespace movie_rating_platform.Model.Requests
{
    public class MovieRatingUpdateRequest
    {
        public int? Rating { get; set; }

        public DateTime? RatedAt { get; set; }
    }
}
