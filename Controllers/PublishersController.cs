using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooksAPI.Data.ViewModels;
using MyBooksAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("AddPublisher")]
        [Authorize]
        public IActionResult AddBook([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("PublisherBooksWithAuthors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }


        [HttpDelete("DeletePublisher/{id}")]
        [Authorize]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publishersService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
