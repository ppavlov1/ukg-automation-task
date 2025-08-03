using AutomationTests.Models;

public class BookResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Quontity { get; set; }
    public List<GetBook>? BooksTaken { get; set; }
}