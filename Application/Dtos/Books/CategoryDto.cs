using Domain.Entities;

namespace Application.Dtos.Books
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        // Navigation property for Books
        public ICollection<Book>? Books { get; set; } 

    }
}
