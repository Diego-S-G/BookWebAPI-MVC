using BookWeb.Application.Interfaces;
using BookWeb.Domain.Dtos;
using BookWeb.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService service)
        {
            _bookService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var entities = await _bookService.GetListAsync();

            if (entities == null)
            {
                return BadRequest();
            }

            return Ok(entities.Select(x => new { x.Id, x.Name, x.Author, x.Publisher }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetCompleteAsync(int id)
        {
            var entity = await _bookService.GetCompleteAsync(id);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Book { Id = entity.Id, Name = entity.Name, Author = entity.Author, Publisher = entity.Publisher });
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostAsync(BookInsertDto bookDto)
        {
            var book = new Book
            {
                Name = bookDto.Name,
                Author = bookDto.Author,
                Publisher = bookDto.Publisher
            };

            var entity = await _bookService.CreateAsync(book);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Book { Id = entity.Id, Name = entity.Name, Author = entity.Author, Publisher = entity.Publisher });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Book book)
        {
            var entity = await _bookService.UpdateAsync(book.Id, book);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Book { Id = entity.Id, Name = entity.Name, Author = entity.Author, Publisher = entity.Publisher });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _bookService.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}