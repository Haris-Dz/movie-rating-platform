using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_rating_platform.Services.Database
{
    public partial class MovieActor
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
        public int ActorId { get; set; }
        public Actor Actor { get; set; } = null!;
    }
}
