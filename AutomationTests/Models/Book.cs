using Bogus;
using System.Collections.Generic;

namespace AutomationTests.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Quontity { get; set; }

        public static Book BuildMock()
        {
            return new Faker<Book>()
                .RuleFor(b => b.Name, f => f.Lorem.Sentence(3))
                .RuleFor(b => b.Author, f => f.Name.FullName())
                .RuleFor(b => b.Genre, f => f.Commerce.Categories(1)[0])
                .RuleFor(b => b.Quontity, f => f.Random.Int(1, 50))
                .Generate();
        }
    }
}
