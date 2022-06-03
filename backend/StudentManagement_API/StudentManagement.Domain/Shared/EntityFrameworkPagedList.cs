using System.Linq;
using System.Threading.Tasks;
using StudentManagement.Domain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Domain.Shared
{
    public static class EntityFrameworkPagedList
    {
        public static async Task<IPagedList<T>> ToListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, count, pageIndex, pageSize);
        }
    }
}