using System.ComponentModel.DataAnnotations;

namespace LAB5AFront.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
