using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBook.Data.Services;
using MyBook.Data.ViewModels;

namespace MyBook.Controllers
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

        [HttpGet("get-all-books")]
        public IActionResult GetGetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            if (book is null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost("add-book-with-author")]
        public IActionResult AddBook(BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok("Create Successed");
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, BookVM book)
        {
            var updateBook = _booksService.UpdateBookById(id, book);
            return Ok(updateBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeDeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
