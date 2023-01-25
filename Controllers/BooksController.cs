using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooksAPI.Data.ViewModels;
using MyBooksAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Controllers
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

        [HttpGet("AllBook")] //Authorize(Roles = "Admin")]
        
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("BookById/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("BookWithAuthors")]
        [Authorize]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpPut("UpdateBook/{id}")]
        [Authorize]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("DeleteBook/{id}")]
        [Authorize]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
    }
