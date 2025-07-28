using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using movie_rating_platform.API.Controllers.BaseControllers;
using movie_rating_platform.Model;
using movie_rating_platform.Model.DTOs;
using movie_rating_platform.Model.Requests;
using movie_rating_platform.Model.SearchObjects;
using movie_rating_platform.Services;

namespace movie_rating_platform.API.Controllers
{
    public class MovieController : BaseCRUDController<MovieDTO, MovieSearchRequest, MovieInsertRequest, MovieUpdateRequest>
    {

        public MovieController(IMovieService service) : base(service)
        {

        }
        [HttpGet]
        [AllowAnonymous]
        public override PagedResult<MovieDTO> GetList([FromQuery] MovieSearchRequest searchObject)
        {
            return base.GetList(searchObject);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public override MovieDTO GetById(int id)
        {
            return base.GetById(id);
        }
    }
}
