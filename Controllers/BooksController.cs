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
            _booksService.Add(book);
            return Ok();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var reponses = _booksService.GetAll();
            return Ok(reponses);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var reponses = _booksService.GetById(id);
            return Ok(reponses);
        }

        [HttpPut("edit/{id}")]
        public IActionResult EditById(int id, [FromBody] BookVM book)
        {
            var reponses = _booksService.UpdateById(id, book);
            return Ok(reponses);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            _booksService.DeleteById(id);
            return Ok();
        }
    }
}