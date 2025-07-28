using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_rating_platform.Services.Database
{
    public partial class Actor: BaseEntity
    {
        [Key]
        public int ActorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
