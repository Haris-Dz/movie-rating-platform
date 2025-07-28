using System;
using System.Collections.Generic;
using System.Text;

namespace movie_rating_platform.Model.SearchObjects
{
    public class MovieSearchRequest: BaseSearchObject
    {
        public MovieTypeEnum? MovieTypeSearch { get; set; }
        public string? SearchKeyWord { get; set; }
    }
}
