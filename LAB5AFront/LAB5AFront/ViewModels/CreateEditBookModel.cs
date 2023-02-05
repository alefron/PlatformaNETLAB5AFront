using LAB5AFront.Controllers;
using LAB5AFront.Models;

namespace LAB5AFront.ViewModels
{
    public class CreateEditBookModel
    {
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public List<Author> AllAuthors { get; set; }
    }
}
