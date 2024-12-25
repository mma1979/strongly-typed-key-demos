namespace StronglyTypedKeyDemo.Models;

public class Book
{
    public BookId Id { get; set; }
    public string Title { get; set; }
    public virtual Author? Author { get; set; }
    public AuthorId? AuthorId { get; set; }
}
public  record  BookId(int Value):StronglyTypedId(Value)
{
    public static BookId New(int value) => new BookId(value);
}