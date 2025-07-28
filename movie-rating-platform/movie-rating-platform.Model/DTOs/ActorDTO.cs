using System;
using System.Collections.Generic;
using System.Text;

namespace movie_rating_platform.Model.DTOs
{
    public class ActorDTO
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
