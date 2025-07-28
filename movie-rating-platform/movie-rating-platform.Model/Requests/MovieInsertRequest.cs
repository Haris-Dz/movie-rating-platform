using System;
using System.Collections.Generic;
using System.Text;
using movie_rating_platform.Model.DTOs;

namespace movie_rating_platform.Model.Requests
{
    public class MovieInsertRequest
    {
        public string Title { get; set; } = null!;

        public string CoverImage { get; set; } = null!;

        public string? ShortDescription { get; set; }

        public DateTime ReleaseDate { get; set; }

        public MovieTypeEnum MovieType { get; set; }

        public List<int> ActorIds { get; set; } = new List<int>();
    }
}
