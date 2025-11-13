using System;
using BookstoresManagerApi.Models;
using BookstoresManagerApi.Requests;
using BookstoresManagerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoresManagerApi.Controllers
{
    public class BookController : BookstoreManagerBaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid id.");

            var book = await _bookService.GetByIdAsync(id);
            if (book is null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create([FromBody] CreateBookRequest request)
        {
            // [ApiController] + ModelState => automatic 400 for invalid request
            if (await _bookService.ExistsByTitleAndAuthorAsync(request.Title, request.Author))
                return Conflict("Book with same title and author already exists.");

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Author = request.Author,
                Genre = request.Genre,
                Price = request.Price,
                Stock = request.Stock
            };

            await _bookService.AddAsync(book);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }
    }
}