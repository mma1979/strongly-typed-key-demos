
using System.ComponentModel.DataAnnotations.Schema;

namespace StronglyTypedKeyDemo2.Models;

public class Author : IAuditEntity
{
    public AuthorId? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual List<Book>? Books { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool? IsDeleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
}
public  record  AuthorId(int Value)
{
    public static AuthorId New(int value) => new AuthorId(value);
}

public record AuthorModel
{
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<BookModel>? Books { get; set; }
}