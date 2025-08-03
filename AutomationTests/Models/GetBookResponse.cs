
namespace AutomationTests.Models
{
    public class GetBookResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime DateTaken { get; set; }
        public BookResponse Book { get; set; }
        public object? User { get; set; }
    }
}
