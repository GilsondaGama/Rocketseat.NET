using BookstoresManagerApi.Models;

namespace BookstoresManagerApi.Services
{
    public class InMemoryBookService : IBookService
    {
        private readonly List<Book> _books = new();

        public Task AddAsync(Book book)
        {
            if (book.Id == Guid.Empty)
                book.Id = Guid.NewGuid();

            _books.Add(book);
            return Task.CompletedTask;
        }

        public Task<Book?> GetByIdAsync(Guid id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(book);
        }

        public Task<bool> ExistsByTitleAndAuthorAsync(string title, string author)
        {
            var exists = _books.Any(b =>
                string.Equals(b.Title?.Trim(), title?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(b.Author?.Trim(), author?.Trim(), StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(exists);
        }

        public Task<IEnumerable<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByTitleAndAuthorAsync(string title, string author, Guid? excludeId = null)
        {
            throw new NotImplementedException();
        }
    }
}