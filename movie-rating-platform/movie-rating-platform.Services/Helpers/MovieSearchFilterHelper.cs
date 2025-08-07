using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using movie_rating_platform.Services.Database;

public static class MovieSearchFilterHelper
{
    public static Expression<Func<Movie, bool>> GetFilter(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            keyword = "";

        keyword = keyword.ToLowerInvariant().Trim();

        var atLeastStars = Regex.Match(keyword, @"at\s+least\s+(\d+)\s+stars?");
        if (atLeastStars.Success && int.TryParse(atLeastStars.Groups[1].Value, out int minStars))
        {
            return m => m.AverageRating >= minStars;
        }

        var exactStars = Regex.Match(keyword, @"^(\d+)\s+stars?$");
        if (exactStars.Success && int.TryParse(exactStars.Groups[1].Value, out int exactStarValue))
        {
            return m => m.AverageRating.HasValue && Math.Floor(m.AverageRating.Value) == exactStarValue;
        }

        var filters = new List<Expression<Func<Movie, bool>>>();

        var beforeYear = Regex.Match(keyword, @"before\s+(\d{4})");
        if (beforeYear.Success && int.TryParse(beforeYear.Groups[1].Value, out int beforeYearVal))
        {
            filters.Add(m => m.ReleaseDate.Year < beforeYearVal);
        }

        var afterYear = Regex.Match(keyword, @"after\s+(\d{4})");
        if (afterYear.Success && int.TryParse(afterYear.Groups[1].Value, out int afterYearVal))
        {
            filters.Add(m => m.ReleaseDate.Year > afterYearVal);
        }

        var olderThanYears = Regex.Match(keyword, @"older\s+than\s+(\d+)\s+years?");
        if (olderThanYears.Success && int.TryParse(olderThanYears.Groups[1].Value, out int yearsOld))
        {
            var thresholdDate = DateTime.UtcNow.AddYears(-yearsOld);
            filters.Add(m => m.ReleaseDate < thresholdDate);
        }

        if (!filters.Any())
        {
            var terms = keyword
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.ToLower())
                .ToList();

            filters.Add(m =>
                terms.All(term =>
                    m.Title.ToLower().Contains(term) ||
                    m.ShortDescription.ToLower().Contains(term) ||
                    m.MovieActors.Any(ma =>
                        (ma.Actor.FirstName.ToLower() + " " + ma.Actor.LastName.ToLower()).Contains(term) ||
                        ma.Actor.FirstName.ToLower().Contains(term) ||
                        ma.Actor.LastName.ToLower().Contains(term)
                    )
                )
            );
        }

        var finalFilter = filters[0];
        for (int i = 1; i < filters.Count; i++)
        {
            finalFilter = AndAlso(finalFilter, filters[i]);
        }

        return finalFilter;
    }

    private static Expression<Func<Movie, bool>> AndAlso(Expression<Func<Movie, bool>> expr1, Expression<Func<Movie, bool>> expr2)
    {
        var parameter = Expression.Parameter(typeof(Movie));

        var combined = Expression.AndAlso(
            Expression.Invoke(expr1, parameter),
            Expression.Invoke(expr2, parameter)
        );

        return Expression.Lambda<Func<Movie, bool>>(combined, parameter);
    }
}
