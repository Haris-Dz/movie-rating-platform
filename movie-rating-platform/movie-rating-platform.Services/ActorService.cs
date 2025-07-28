using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using movie_rating_platform.Model.DTOs;
using movie_rating_platform.Model.Requests;
using movie_rating_platform.Model.SearchObjects;
using movie_rating_platform.Services.BaseServices;
using movie_rating_platform.Services.Database;

namespace movie_rating_platform.Services
{
    public class ActorService : BaseCRUDService<ActorDTO, ActorSearchObject, Actor, ActorInsertRequest, ActorUpdateRequest>, IActorService
    {
        public ActorService(MovieRatingDBContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override IQueryable<Actor> AddFilter(ActorSearchObject searchObject, IQueryable<Actor> query)
        {
            query = query.Where(x => !x.IsDeleted);
            return query;
        }
    }
}
