using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using movie_rating_platform.Model;
using movie_rating_platform.Model.SearchObjects;
using movie_rating_platform.Services.Database;

namespace movie_rating_platform.Services.BaseServices
{
    public class BaseService<TModel, TSearch, TDbEntity> : IService<TModel, TSearch> where TSearch : BaseSearchObject where TDbEntity : class where TModel : class
    {
        public MovieRatingDBContext Context { get; }
        public IMapper Mapper { get; }

        public BaseService(MovieRatingDBContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public PagedResult<TModel> GetPaged(TSearch search)
        {
            List<TModel> result = new List<TModel>();
            var query = Context.Set<TDbEntity>().AsQueryable();
            query = AddFilter(search, query);

            int count = query.Count();

            if (!string.IsNullOrEmpty(search?.OrderBy) && !string.IsNullOrEmpty(search?.SortDirection))
            {
                query = ApplySorting(query, search.OrderBy, search.SortDirection);
            }
            else
            {
                var entityType = typeof(TDbEntity);
                var defaultSortProperty = entityType.GetProperty("MovieId") ?? entityType.GetProperty("Id");

                if (defaultSortProperty != null)
                {
                    query = query.OrderBy(e => EF.Property<object>(e, defaultSortProperty.Name));
                }
            }

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                int skip = (search.Page.Value - 1) * search.PageSize.Value;
                query = query.Skip(skip).Take(search.PageSize.Value);
            }

            var list = query.ToList();
            result = Mapper.Map<List<TModel>>(list);

            CustomMapPagedResponse(result);

            PagedResult<TModel> pagedResult = new PagedResult<TModel>();
            pagedResult.ResultList = result;
            pagedResult.Count = count;

            return pagedResult;
        }


        public virtual void CustomMapPagedResponse(List<TModel> result) { }

        public IQueryable<TDbEntity> ApplySorting(IQueryable<TDbEntity> query, string sortColumn, string sortDirection)
        {
            var entityType = typeof(TDbEntity);
            var property = entityType.GetProperty(sortColumn);
            if (property == null)
            {
                throw new Exception($"Sorting column '{sortColumn}' does not exist.");
            }
            var parameter = Expression.Parameter(entityType, "x");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            string methodName = "";

            var sortDirectionToLower = sortDirection.ToLower();

            methodName = sortDirectionToLower == "desc" || sortDirectionToLower == "descending" ? "OrderByDescending" :
                sortDirectionToLower == "asc" || sortDirectionToLower == "ascending" ? "OrderBy" : "";

            if (methodName == "")
            {
                return query;
            }

            var resultExpression = Expression.Call(typeof(Queryable), methodName,
                                                   new Type[] { entityType, property.PropertyType },
                                                   query.Expression, Expression.Quote(orderByExpression));

            return query.Provider.CreateQuery<TDbEntity>(resultExpression);
        }

        public virtual IQueryable<TDbEntity> AddFilter(TSearch search, IQueryable<TDbEntity> query)
        {
            return query;
        }
        public TModel GetById(int id)
        {
            var entity = Context.Set<TDbEntity>().Find(id);
            if (entity == null)
            {
                throw new Exception("Unable to find an object with the provided ID!");
            }

            var mappedObj = Mapper.Map<TModel>(entity);
            CustomMapResponse(mappedObj);
            return mappedObj;
        }

        public virtual void CustomMapResponse(TModel mappedObj) { }

    }
}
