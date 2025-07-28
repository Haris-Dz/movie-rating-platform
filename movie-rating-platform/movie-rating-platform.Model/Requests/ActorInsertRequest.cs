using System;
using System.Collections.Generic;
using System.Text;

namespace movie_rating_platform.Model.Requests
{
    public class ActorInsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
