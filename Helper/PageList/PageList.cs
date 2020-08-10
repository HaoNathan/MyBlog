using System;
using System.Collections.Generic;
using System.Linq;

namespace Helper.PageList
{
    public class PageList<T> : List<T>
    {

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;

        public bool HasNext => CurrentPage < TotalPages;

        public PageList(List<T> items, int pageSize, int pageNum, int count)
        {
            CurrentPage = pageNum;

            TotalPages = (int) Math.Ceiling(count / (double) pageSize);

            AddRange(items);

            PageSize = pageSize;

            TotalCount = count;
        }

        public static  PageList<T> Create(IEnumerable<T> source, int pageNum, int pageSize)
        {
            var enumerable = source.ToList();

            var count =  enumerable.Count();

            var items =  enumerable.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();

            return new PageList<T>(items, pageSize, pageNum, count);
        }
    }
}
