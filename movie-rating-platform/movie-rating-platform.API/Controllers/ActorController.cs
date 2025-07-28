using Microsoft.AspNetCore.Authorization;
using movie_rating_platform.API.Controllers.BaseControllers;
using movie_rating_platform.Model.DTOs;
using movie_rating_platform.Model.Requests;
using movie_rating_platform.Model.SearchObjects;
using movie_rating_platform.Services;

namespace movie_rating_platform.API.Controllers
{
    public class ActorController : BaseCRUDController<ActorDTO, ActorSearchObject, ActorInsertRequest, ActorUpdateRequest>
    {

        public ActorController(IActorService service) : base(service)
        {

        }
    }
}
