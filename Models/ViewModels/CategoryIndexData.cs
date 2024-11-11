namespace Sabau_Denis_lab2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IList<Category> Categories { get; set; } 
        public IEnumerable<Book> Books { get; set; }
    }
}