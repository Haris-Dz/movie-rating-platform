using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_rating_platform.Services.Database
{
    public partial class MovieRating : BaseEntity
    {
        [Key]
        public int MovieRatingId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public DateTime RatedAt { get; set; } = DateTime.Now;
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;
    }
}

