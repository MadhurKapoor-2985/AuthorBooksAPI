using AuthorBooksAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBooksAPI.Repository
{
    public interface IAuthorBooksRepository
    {
        bool SaveChanges();
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int authorId);

        void AddBookByAuthor(int authorId, Book book);

        IEnumerable<Book> GetAllBooks(int authorId);

        Book GetBookById(int authorId, int bookId);

        void AddAuthor(Author author);

       
    }
}
