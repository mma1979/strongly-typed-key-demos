using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using StronglyTypedKeyDemo3.Data;
using StronglyTypedKeyDemo3.Entities;
using StronglyTypedKeyDemo3.Models;

namespace StronglyTypedKeyDemo3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LiberaryController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public LiberaryController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("authors")]
    public IEnumerable<AuthorReadModel> Get()
    {
        var result = _context.Authors.Include(a => a.Books).ToList();
        return _mapper.Map<List<AuthorReadModel>>(result);
    }

    [HttpGet("books")]
    public IEnumerable<BookReadModel> GetBooks()
    {
        var result = _context.Books.Include(b => b.Author).ToList();
        return _mapper.Map<List<BookReadModel>>(result);
    }

    [HttpPost("authors")]
    public void Post(AuthorModifyModel model)
    {
        var author = new Author(model);
        _context.Authors.Add(author);
        _context.SaveChanges();
    }

    [HttpPost("books")]
    public void Post(BookModifyModel model)
    {
        var book = new Book(model);
        _context.Books.Add(book);
        _context.SaveChanges();
    }
}
