using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public DateTime ReservationDate { get; set; } 
        public DateTime? ExpiryDate { get; set; }
        public bool IsNotified { get; set; } 
        public bool IsCompleted { get; set; }  // True when book borrowed
    }
}
