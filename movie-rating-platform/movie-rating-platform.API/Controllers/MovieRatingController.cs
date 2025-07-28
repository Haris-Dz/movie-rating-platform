using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using movie_rating_platform.API.Controllers.BaseControllers;
using movie_rating_platform.Model.DTOs;
using movie_rating_platform.Model.Requests;
using movie_rating_platform.Model.SearchObjects;
using movie_rating_platform.Services;

namespace movie_rating_platform.API.Controllers
{
    
    public class MovieRatingController : BaseCRUDController<MovieRatingDTO, MovieRatingSearchObject, MovieRatingInsertRequest, MovieRatingUpdateRequest>
    {
        public MovieRatingController(IMovieRatingService service) : base(service)
        {

        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public override  MovieRatingDTO Insert(MovieRatingInsertRequest request)
        {
            return _service.Insert(request);
        }
    }
}
