using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Domain.Shared
{
    public class PagedList<T> : IPagedList<T>
    {
        public PagedList()
        {
        }

        public PagedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            TotalCount = count;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
        }

        public int TotalCount { get; }
        public int PageIndex { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public List<T> Items { get; set; }

        public IPagedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageIndex, pageSize);
        }
    }
}