using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using movie_rating_platform.Model;
using movie_rating_platform.Model.SearchObjects;

namespace movie_rating_platform.Services.BaseServices
{
    public interface IService<TModel, TSearch> where TSearch : BaseSearchObject
    {
        public PagedResult<TModel> GetPaged(TSearch search);
        public TModel GetById(int id);
    }
}

