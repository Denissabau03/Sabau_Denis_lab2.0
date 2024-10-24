using Sabau_Denis_lab2.Models;

public class Author
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName { get { return $"{FirstName} {LastName}"; } }
    public ICollection<Book>? Books { get; set; }

   
}