using BookstoresManagerApi.Communication.Requests;
using BookstoresManagerApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace BookstoresManagerApi.Controllers
{
    public class BookController : BookstoreManagerBaseController
    {
        private static readonly ConcurrentDictionary<Guid, Book> _store = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_store.Values);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id inválido.");

            if (!_store.TryGetValue(id, out var book)) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBookRequest request)
        {
            // [ApiController] na base já faz validação do ModelState
            if (_store.Values.Any(b =>
                string.Equals(b.Title?.Trim(), request.Title?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(b.Author?.Trim(), request.Author?.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                return Conflict("Um livro com o mesmo título e autor já existe.");
            }

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

            _store[book.Id] = book;
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateBookRequest request)
        {
            if (id == Guid.Empty) return BadRequest("Id inválido.");
            if (!_store.TryGetValue(id, out var existing)) return NotFound();

            if (_store.Values.Any(b =>
                b.Id != id &&
                string.Equals(b.Title?.Trim(), request.Title?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(b.Author?.Trim(), request.Author?.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                return Conflict("Outro livro com o mesmo título e autor já existe.");
            }

            existing.Title = request.Title;
            existing.Author = request.Author;
            existing.Genre = request.Genre;
            existing.Price = request.Price;
            existing.Stock = request.Stock;
            existing.UpdatedAt = DateTimeOffset.UtcNow;

            _store[id] = existing;
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id inválido.");
            if (!_store.TryRemove(id, out _)) return NotFound();
            return NoContent();
        }
    }
}