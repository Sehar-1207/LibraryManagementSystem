namespace Application.Dtos.Books
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsNotified { get; set; }
        public bool IsCompleted { get; set; }
    }
}
