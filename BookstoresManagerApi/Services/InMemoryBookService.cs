using System;
using System.Collections.Generic;
using System.Linq;
using BookstoresManagerApi.Models;

namespace BookstoresManagerApi.Services
{
    public class InMemoryBookService : IBookService
    {
        private readonly List<Book> _books = new();
        private readonly object _lock = new();

        public IEnumerable<Book> GetAll()
        {
            lock (_lock)
                return _books.Select(b => b).ToList();
        }

        public Book? GetById(Guid id)
        {
            lock (_lock)
                return _books.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Book book)
        {
            lock (_lock)
            {
                if (book.Id == Guid.Empty)
                    book.Id = Guid.NewGuid();

                var now = DateTimeOffset.UtcNow;
                book.CreatedAt = now;
                book.UpdatedAt = now;

                _books.Add(book);
            }
        }

        public void Update(Book book)
        {
            lock (_lock)
            {
                var existing = _books.FirstOrDefault(b => b.Id == book.Id);
                if (existing is null)
                    throw new KeyNotFoundException("Book not found.");

                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.Genre = book.Genre;
                existing.Price = book.Price;
                existing.Stock = book.Stock;
                existing.UpdatedAt = DateTimeOffset.UtcNow;
            }
        }

        public bool Delete(Guid id)
        {
            lock (_lock)
            {
                var existing = _books.FirstOrDefault(b => b.Id == id);
                if (existing is null)
                    return false;

                _books.Remove(existing);
                return true;
            }
        }

        public bool ExistsByTitleAndAuthor(string title, string author, Guid? excludeId = null)
        {
            lock (_lock)
            {
                return _books.Any(b =>
                    (!excludeId.HasValue || b.Id != excludeId.Value) &&
                    string.Equals(b.Title?.Trim(), title?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(b.Author?.Trim(), author?.Trim(), StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}