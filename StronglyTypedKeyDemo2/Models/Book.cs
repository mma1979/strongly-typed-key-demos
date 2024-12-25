
using System.ComponentModel.DataAnnotations.Schema;

namespace StronglyTypedKeyDemo2.Models;

public class Book: IAuditEntity
{
    public BookId? Id { get; set; }
    public string Title { get; set; }
    public virtual Author? Author { get; set; }
    public AuthorId? AuthorId { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool? IsDeleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
}
public  record  BookId(Guid Value)
{
    public static BookId New(Guid value) => new BookId(value);
}

public record BookModel
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public int? AuthorId { get; set; }
    public AuthorModel? Author { get; set; }
}