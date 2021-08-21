using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.Services.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublishersService _publishersService { get; set; }

        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }


        [HttpPost("add")]
        public IActionResult Add([FromBody] PublisherVM publisher)
        {
            _publishersService.Add(publisher);
            return Ok();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var reponses = _publishersService.GetAll();
            return Ok(reponses);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var reponses = _publishersService.GetById(id);
            return Ok(reponses);
        }

        [HttpPut("edit/{id}")]
        public IActionResult EditById(int id, [FromBody] PublisherVM publisher)
        {
            var reponses = _publishersService.UpdateById(id, publisher);
            return Ok(reponses);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            _publishersService.DeleteById(id);
            return Ok();
        }
    }
}
