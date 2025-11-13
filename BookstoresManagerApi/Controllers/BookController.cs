using BookstoresManagerApi.Communication.Requests;
using BookstoresManagerApi.Models;
using BookstoresManagerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookstoresManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : BookstoreManagerBaseController
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var all = await _bookService.GetAllAsync();
                return Ok(all); // 200
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAll failed.");
                return Problem(detail: "Erro inesperado no servidor.", statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid id."); // 400

            try
            {
                var book = await _bookService.GetByIdAsync(id);
                if (book is null)
                    return NotFound(); // 404

                return Ok(book); // 200
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetById failed for id {Id}.", id);
                return Problem(detail: "Erro inesperado no servidor.", statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateBookRequest request)
        {
            // [ApiController] => automatic 400 for invalid ModelState
            try
            {
                if (await _bookService.ExistsByTitleAndAuthorAsync(request.Title, request.Author))
                    return Conflict("A book with the same title and author already exists."); // 409

                var book = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    Author = request.Author,
                    Genre = request.Genre,
                    Price = request.Price,
                    Stock = request.Stock,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                };

                await _bookService.AddAsync(book);
                return CreatedAtAction(nameof(GetById), new { id = book.Id }, book); // 201
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create failed for Title={Title}, Author={Author}.", request?.Title, request?.Author);
                return Problem(detail: "Erro inesperado no servidor.", statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBookRequest request)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid id."); // 400

            try
            {
                var existing = await _bookService.GetByIdAsync(id);
                if (existing is null)
                    return NotFound(); // 404

                if (await _bookService.ExistsByTitleAndAuthorAsync(request.Title, request.Author, excludeId: id))
                    return Conflict("Another book with the same title and author already exists."); // 409

                existing.Title = request.Title;
                existing.Author = request.Author;
                existing.Genre = request.Genre;
                existing.Price = request.Price;
                existing.Stock = request.Stock;
                existing.UpdatedAt = DateTimeOffset.UtcNow;

                await _bookService.UpdateAsync(existing);
                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update failed for id {Id}.", id);
                return Problem(detail: "Erro inesperado no servidor.", statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid id."); // 400

            try
            {
                var deleted = await _bookService.DeleteAsync(id);
                if (!deleted)
                    return NotFound(); // 404

                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete failed for id {Id}.", id);
                return Problem(detail: "Erro inesperado no servidor.", statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}