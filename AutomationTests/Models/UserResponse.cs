

namespace AutomationTests.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetBook>? BooksTaken { get; set; }


    }
}