using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBook.Data.Services;
using MyBook.Data.ViewModels;

namespace MyBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor(AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("author-with-book-by-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var response = _authorService.GetAuthorWithBooks(id);
            return Ok(response);
        }

    }
}
