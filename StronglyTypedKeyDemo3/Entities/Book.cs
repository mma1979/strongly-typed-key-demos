using StronglyTypedKeyDemo3.Models;

namespace StronglyTypedKeyDemo3.Entities;

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

    private Book()
    {
}
    public Book(BookModifyModel model)
    {
        Title = model.Title;
        AuthorId = new AuthorId(model.AuthorId!.Value);
    }
    public Book Update(BookModifyModel model)
    {
        Title = model.Title;
        AuthorId = new AuthorId(model.AuthorId!.Value);
        return this;
    }
}
public  record  BookId(Guid Value)
{
    public static BookId New(Guid value) => new BookId(value);
}

