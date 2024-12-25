

using StronglyTypedKeyDemo3.Models;

namespace StronglyTypedKeyDemo3.Entities;

public class Author : IAuditEntity
{
    public AuthorId? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<Book>? Books { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool? IsDeleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }

    private Author()
    {
        Books = [];
    }

    public Author(AuthorModifyModel model)
    {

        FirstName = model.FirstName!;
        LastName = model.LastName!;

    }

    public Author Update(AuthorModifyModel model)
    {
        Id = new AuthorId(model.Id!.Value);
        FirstName = model.FirstName!;
        LastName = model.LastName!;

        return this;
    }
}
public  record  AuthorId(int Value)
{
    public static AuthorId New(int value) => new AuthorId(value);
}
