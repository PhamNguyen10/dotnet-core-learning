using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.Services.ViewModels;

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
        public IActionResult Add([FromBody] AuthorVM author)
        {
            _authorsService.Add(author);
            return Ok();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var reponses = _authorsService.GetAll();
            return Ok(reponses);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var reponses = _authorsService.GetById(id);
            return Ok(reponses);
        }

        [HttpPut("edit/{id}")]
        public IActionResult EditById(int id, [FromBody] AuthorVM author)
        {
            var reponses = _authorsService.UpdateById(id, author);
            return Ok(reponses);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            _authorsService.DeleteById(id);
            return Ok();
        }
    }
}
