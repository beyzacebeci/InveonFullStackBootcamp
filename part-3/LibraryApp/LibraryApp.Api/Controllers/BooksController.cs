using LibraryApp.Api.DTOs;
using LibraryApp.Api.Models;
using LibraryApp.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("WithPagination")]
        public async Task<IActionResult> GetWithPagination([FromQuery]BookParameters bookParameters)
        {
            var books = await _bookService.GetAllWithPaginationAsync(bookParameters);
            return Ok(books);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateDto createBookDto)
        {
            var createdBook = await _bookService.CreateAsync(createBookDto);

            return StatusCode(201, createdBook);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookDto bookDto)
        {
            var updatedBookDto = bookDto with { Id = id }; 

            var result = await _bookService.UpdateAsync(bookDto);

            if (result.ProblemDetails != null)
            {
                return BadRequest(result.ProblemDetails); 
            }

            return StatusCode(result.Status); 
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteAsync(id);

            if (result.ProblemDetails != null)
            {
                return NotFound(result.ProblemDetails); 
            }

            return StatusCode(result.Status);
        }

    }
}
