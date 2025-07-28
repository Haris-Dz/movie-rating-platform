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
    public class MovieRatingService : BaseCRUDService<MovieRatingDTO, MovieRatingSearchObject, MovieRating, MovieRatingInsertRequest, MovieRatingUpdateRequest>, IMovieRatingService
    {
        public MovieRatingService(MovieRatingDBContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override IQueryable<MovieRating> AddFilter(MovieRatingSearchObject searchObject, IQueryable<MovieRating> query)
        {
            query = query.Where(x => !x.IsDeleted);
            return query;
        }
        public override void BeforeInsert(MovieRatingInsertRequest request, MovieRating entity)
        {
                entity.RatedAt = DateTime.Now;
        }
        public override void AfterInsert(MovieRatingInsertRequest request, MovieRating entity)
        {
            var movie = Context.Movies.Include(m => m.MovieRatings)
                .FirstOrDefault(m => m.MovieId == entity.MovieId);
            if (movie != null)
            {
                movie.AverageRating = movie.MovieRatings
                    .Where(r => !r.IsDeleted)
                    .Average(r => (double?)r.Rating);

                Context.SaveChanges();
            }
        }
        }
}
