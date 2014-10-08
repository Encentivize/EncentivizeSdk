using System.Collections.Generic;

namespace Entelect.Encentivize.Sdk
{
    public class PagedResult<T>
    {
        public PagedResult()
        {
            Data = new List<T>();
        }

        public PagedResult(PagedResult<object> result)
            : this(result.FirstItem, result.HasNextPage, result.HasPreviousPage, result.LastItem, new List<T>(), result.PageNumber, result.PageSize, result.TotalItems, result.TotalPages)
        {
        }

        public PagedResult(int firstItem, bool hasNextPage, bool hasPreviousPage, int lastItem, List<T> data, int pageNumber, int pageSize, int totalItems, int totalPages)
        {
            FirstItem = firstItem;
            HasNextPage = hasNextPage;
            HasPreviousPage = hasPreviousPage;
            LastItem = lastItem;
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }

        public List<T> Data { get; set; }
        public int FirstItem { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int LastItem { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
