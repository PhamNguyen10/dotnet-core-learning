using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.Services.ViewModels;
using System.Collections.Generic;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorsService _authorsService { get; set; }

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add")]
        public ActionResult<Author> Add([FromBody] AuthorVM author)
        {
            _authorsService.Add(author);
            return Ok();
        }

        [HttpGet("get-all")]
        public ActionResult<List<Author>> GetAll()
        {
            var _reponse = _authorsService.GetAll();
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
        public ActionResult<Author> GetById(int id)
        {
            var _reponse = _authorsService.GetById(id);
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
        public ActionResult<Author> EditById(int id, [FromBody] AuthorVM author)
        {
            var _reponse = _authorsService.UpdateById(id, author);
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
        public ActionResult<Author> DeleteById(int id)
        {
            _authorsService.DeleteById(id);
            return Ok();
        }
    }
}
