using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute
{
    public class PaginationList<T> : List<T>
    {
        public int CurrentPageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool IsPreviousPageAvailable => CurrentPageNumber > 1;
        public bool IsNextPageAvailable => CurrentPageNumber < TotalPages;

        public PaginationList(List<T> source, int currentPageNumber, int itemsAllowedOnPage)
        {
            CurrentPageNumber = currentPageNumber;
            TotalPages = (int)Math.Ceiling(source.Count / (double)itemsAllowedOnPage);
            var filteredItems = source.Skip((currentPageNumber - 1) * itemsAllowedOnPage).Take(itemsAllowedOnPage).ToList();
            this.AddRange(filteredItems);
        }
    }
}
