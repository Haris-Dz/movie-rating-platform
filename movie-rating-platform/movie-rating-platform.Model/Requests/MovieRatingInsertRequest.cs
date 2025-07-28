using System;
using System.Collections.Generic;
using System.Text;

namespace movie_rating_platform.Model.Requests
{
    public class MovieRatingInsertRequest
    {
        public int Rating { get; set; }
        public int MovieId { get; set; }
    }
}
