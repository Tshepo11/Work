using System.Collections.Generic;

namespace StudentManagement.Domain.Shared
{
    public interface IPagedList<T>
    {
        int PageIndex { get; }

        int TotalCount { get; }

        int TotalPages { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }

        List<T> Items { get; set; }
        IPagedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize);
    }
}
