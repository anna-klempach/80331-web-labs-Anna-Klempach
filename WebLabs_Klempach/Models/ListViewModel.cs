using System;
using System.Collections.Generic;
using System.Linq;

namespace WebLabs_Klempach.Models
{
    public class ListViewModel<T>: List<T> where T: class
    {
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }

        private ListViewModel(IEnumerable<T> itemsList, int currentPage, int numberOfPages): base (itemsList)
        {
            CurrentPage = currentPage;
            NumberOfPages = numberOfPages;
        }

        public static ListViewModel<T> GetModel(IEnumerable<T> itemsList, int currentPage, int itemsQuantity)
        {
            var items = itemsList
                .Skip((currentPage - 1) * itemsQuantity)
                .Take(itemsQuantity)
                .ToList();
            var numberOfPages = (int)Math.Ceiling((double)itemsList.Count() / itemsQuantity);
            return new ListViewModel<T>(items, currentPage, numberOfPages);
        }
            
    }
}
