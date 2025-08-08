using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Genre { get; set; }

        public string ISBN { get; set; }

        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }

        // Foreign Key for Category
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        //public Category Category { get; set; }
        public string CategoryName { get; set; }

        // Navigation property for Borrowing Records
        public ICollection<BorrowingRecords> borrowRecord { get; set; }
    }
}
