using BookstoresManagerApi.Models;

namespace BookstoresManagerApi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(Guid id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task<bool> DeleteAsync(Guid id);

        // check duplicates; excludeId when updating to ignore the same record
        Task<bool> ExistsByTitleAndAuthorAsync(string title, string author, Guid? excludeId = null);
    }
}