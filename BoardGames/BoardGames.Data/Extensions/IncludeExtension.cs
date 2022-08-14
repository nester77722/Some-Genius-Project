using BoardGames.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BoardGames.Data.Extensions
{
    public static class IncludeExtension
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
