using System;
using System.Collections.Generic;
using BookstoresManagerApi.Models;

namespace BookstoresManagerApi.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book? GetById(Guid id);
        void Add(Book book);
        void Update(Book book);
        bool Delete(Guid id);

        // verifica duplicidade; excludeId quando atualizar para ignorar o mesmo registro
        bool ExistsByTitleAndAuthor(string title, string author, Guid? excludeId = null);
    }
}