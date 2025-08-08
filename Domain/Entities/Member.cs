using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }

        public ICollection<BorrowingRecords> borrowRecords { get; set; }
    }
}
