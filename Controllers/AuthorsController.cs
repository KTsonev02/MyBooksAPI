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
    

    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("AddAuthor")]
        [Authorize]
        public IActionResult AddBook([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("AuthorWithBooks/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var response = _authorsService.GetAuthorWithBooks(id);
            return Ok(response);
        }

    }
}
