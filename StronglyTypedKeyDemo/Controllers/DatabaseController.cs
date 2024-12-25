using Microsoft.AspNetCore.Mvc;
using StronglyTypedKeyDemo.Data;
using StronglyTypedKeyDemo.Models;

namespace StronglyTypedKeyDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DatabaseController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DatabaseController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // GET: api/Database
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var authors = new List<Author>
        {
            new Author
            {
                Id = new AuthorId(1),
                FirstName ="Joydip",
                LastName ="Kanjilal",
                Books = new List<Book>()
                {
                    new Book {Id = new BookId(1), Title = "Mastering C# 8.0"},
                    new Book { Id = new BookId(2),Title = "Entity Framework Tutorial"},
                    new Book {Id = new BookId(3), Title = "ASP.NET 4.0 Programming"}
                }
            },
            new Author
            {
                Id = new AuthorId(2),
                FirstName ="Yashavanth",
                LastName ="Kanetkar",
                Books = new List<Book>()
                {
                    new Book { Id = new BookId(4),Title = "Let us C"},
                    new Book { Id = new BookId(5),Title = "Let us C++"},
                    new Book { Id = new BookId(6),Title = "Let us C#"}
                }
            }
        };
        _context.Authors.AddRange(authors);
        await _context.SaveChangesAsync();

        return Ok();
    }
}