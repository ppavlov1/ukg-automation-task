using Bogus;

namespace AutomationTests.Models
{
    public class User
    {
        public string Name { get; set; }

        public static User BuildMock()
        {
            return new Faker<User>()
                .RuleFor(u => u.Name, f => f.Person.FullName)
                .Generate();
        }
    }
}