using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using movie_rating_platform.Model.DTOs;
using movie_rating_platform.Model.Requests;
using movie_rating_platform.Model.SearchObjects;
using movie_rating_platform.Services.BaseServices;

namespace movie_rating_platform.Services
{
    public interface IActorService : ICRUDService<ActorDTO, ActorSearchObject, ActorInsertRequest, ActorUpdateRequest>
    {
    }
}
