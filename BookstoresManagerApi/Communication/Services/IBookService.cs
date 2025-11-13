using BookstoresManagerApi.Models;

namespace BookstoresManagerApi.Services
{
    public interface IBookService
    {
        Task<bool> ExistsByTitleAndAuthorAsync(string title, string author);
        Task AddAsync(Book book);
        Task<Book?> GetByIdAsync(Guid id);
    }
}