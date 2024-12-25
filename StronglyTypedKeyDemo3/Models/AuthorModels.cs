namespace StronglyTypedKeyDemo3.Models;

public class AuthorReadModel
{
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<BookReadModel>? Books { get; set; }
}

public class AuthorModifyModel
{
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<BookModifyModel>? Books { get; set; }
}

