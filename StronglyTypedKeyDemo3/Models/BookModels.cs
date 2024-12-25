namespace StronglyTypedKeyDemo3.Models;

public class BookReadModel
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public int? AuthorId { get; set; }
    public AuthorReadModel? Author { get; set; }
}

public class BookModifyModel
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public int? AuthorId { get; set; }
    public AuthorModifyModel? Author { get; set; }
}
