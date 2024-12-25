namespace StronglyTypedKeyDemo.Models;

public class Author
{
    public AuthorId Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual List<Book> Books { get; set; }
}
public  record  AuthorId(int Value):StronglyTypedId(Value)
{
    public static AuthorId New(int value) => new AuthorId(value);
}