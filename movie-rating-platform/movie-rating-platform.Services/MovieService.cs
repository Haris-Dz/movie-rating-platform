using System;
using System.Collections.Generic;
using System.Linq;
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
    public class MovieService : BaseCRUDService<MovieDTO, MovieSearchRequest, Movie, MovieInsertRequest, MovieUpdateRequest>, IMovieService
    {
        public MovieService(MovieRatingDBContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override IQueryable<Movie> AddFilter(MovieSearchRequest searchObject, IQueryable<Movie> query)
        {
            if (searchObject.MovieTypeSearch.HasValue)
            {
                query = query.Where(x=>x.MovieType == searchObject.MovieTypeSearch);
            }
            query = query.Where(x => !x.IsDeleted);
            query = query.Include(x => x.MovieActors).ThenInclude(ma => ma.Actor).Include(x => x.MovieRatings);
            return query;
        }
        public override void BeforeInsert(MovieInsertRequest request, Movie entity)
        {
            entity.AverageRating = 1;
            if (request.ActorIds != null && request.ActorIds.Any())
            {
                entity.MovieActors = request.ActorIds
                    .Select(actorId => new MovieActor { ActorId = actorId })
                    .ToList();
            }
        }
    }
}
