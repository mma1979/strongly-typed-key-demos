using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using StronglyTypedKeyDemo2.Data;
using StronglyTypedKeyDemo2.Models;

namespace StronglyTypedKeyDemo2.Controllers
{
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
        public IEnumerable<AuthorModel> Get()
        {
            var result = _context.Authors.Include(a => a.Books).ToList();
            return _mapper.Map<List<AuthorModel>>(result);
        }

        [HttpGet("books")]
        public IEnumerable<BookModel> GetBooks()
        {
            var result = _context.Books.Include(b => b.Author).ToList();
            return _mapper.Map<List<BookModel>>(result);
        }

        [HttpPost("authors")]
        public void Post(AuthorModel author)
        {
            var record = _mapper.Map<Author>(author);
            _context.Authors.Add(record);
            _context.SaveChanges();
        }

        [HttpPost("books")]
        public void Post(BookModel book)
        {
            var record = _mapper.Map<Book>(book);
            _context.Books.Add(record);
            _context.SaveChanges();
        }
    }
}
