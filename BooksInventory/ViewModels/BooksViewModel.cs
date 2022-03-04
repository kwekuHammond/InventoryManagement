using BooksInventory.Models;

namespace BooksInventory.ViewModels
{
    public class BooksViewModel
    {
        public IEnumerable<BookType> BookDetails { get; set; }
        public string BookName { get; set; }
    }
}
