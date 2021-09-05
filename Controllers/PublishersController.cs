using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.Services.ViewModels;
using System.Collections.Generic;

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
        public ActionResult<Publisher> Add([FromBody] PublisherVM publisher)
        {
            _publishersService.Add(publisher);
            return Ok();
        }

        [HttpGet("get-all")]
        public ActionResult<List<Publisher>> GetAll()
        {
            var _reponse = _publishersService.GetAll();
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
        public ActionResult<Publisher> GetById(int id)
        {
            var _reponse = _publishersService.GetById(id);
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
        public ActionResult<Publisher> EditById(int id, [FromBody] PublisherVM publisher)
        {
            var _reponse = _publishersService.UpdateById(id, publisher);
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
        public ActionResult<Publisher> DeleteById(int id)
        {
            _publishersService.DeleteById(id);
            return Ok();
        }
    }
}
