﻿using System;
using System.Collections.Generic;
using System.Text;

namespace movie_rating_platform.Model.SearchObjects
{
    public class BaseSearchObject
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? SortDirection { get; set; }
    }
}
