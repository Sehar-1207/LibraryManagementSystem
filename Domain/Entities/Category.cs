using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 

        // Navigation property for Books
        public ICollection<Book> Books { get; set; }
    }
}
