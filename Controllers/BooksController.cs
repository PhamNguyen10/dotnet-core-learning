using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.Services.ViewModels;
using System.Collections.Generic;

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
        public ActionResult<Book> Add([FromBody] BookVM book)
        {
            _booksService.Add(book);
            return Ok();
        }

        [HttpGet("get-all")]
        public ActionResult<List<Book>> GetAll()
        {
            var _reponse = _booksService.GetAll();
            if (_reponse != null)
            {
                return _reponse;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("get/{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var _reponse = _booksService.GetById(id);
            if (_reponse != null)
            {
                return _reponse;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("edit/{id}")]
        public ActionResult<Book> EditById(int id, [FromBody] BookVM book)
        {
            var _reponse = _booksService.UpdateById(id, book);
            if (_reponse != null)
            {
                return _reponse;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<Book> DeleteById(int id)
        {
            _booksService.DeleteById(id);
            return Ok();
        }
    }
}