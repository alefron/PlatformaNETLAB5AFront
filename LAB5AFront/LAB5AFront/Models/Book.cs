using System.ComponentModel.DataAnnotations;

namespace LAB5AFront.Models
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public eBookGenre BookGenre { get; set; }

        public int? pagesCount { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
