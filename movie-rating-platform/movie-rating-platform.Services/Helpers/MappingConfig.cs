using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using movie_rating_platform.Model.DTOs;
using movie_rating_platform.Model.Requests;
using movie_rating_platform.Services.Database;

public static class MappingConfig
{
    public static void RegisterMappings()
    {
        var config = TypeAdapterConfig.GlobalSettings;

        config.Default.IgnoreNullValues(true);

        config.NewConfig<Movie, MovieDTO>()
            .Map(dest => dest.Actors, src => src.MovieActors.Select(ma => ma.Actor).Adapt<List<ActorDTO>>())
            .Map(dest => dest.MovieRatings, src => src.MovieRatings.Adapt<List<MovieRatingDTO>>());

        config.NewConfig<MovieInsertRequest, Movie>();
        config.NewConfig<MovieUpdateRequest, Movie>();

        config.NewConfig<Actor, ActorDTO>();

        config.NewConfig<MovieRating, MovieRatingDTO>();
    }
}
