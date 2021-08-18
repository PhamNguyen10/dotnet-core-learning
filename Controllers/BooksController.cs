using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.Services.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var allBooks = _booksService.GetAll();
            return Ok(allBooks);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var getBookById = _booksService.GetById(id);
            return Ok(getBookById);
        }
    }
}