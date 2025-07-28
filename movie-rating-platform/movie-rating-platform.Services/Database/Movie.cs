using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using movie_rating_platform.Model;

namespace movie_rating_platform.Services.Database
{
    public partial class Movie: BaseEntity
    {
        [Key]
        public int MovieId { get; set; }

        public string Title { get; set; } = null!;

        public string CoverImage { get; set; } = null!;

        public string? ShortDescription { get; set; }

        public DateTime ReleaseDate { get; set; }

        public MovieTypeEnum MovieType { get; set; }

        public double? AverageRating { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public ICollection<MovieRating> MovieRatings { get; set; } = new List<MovieRating>();
    }
}
