using AuthorBooksAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBooksAPI.Repository
{
    public class AuthorBooksSqlRepository : IAuthorBooksRepository
    {
        private readonly AuthorBooksDbContext _context;

        public AuthorBooksSqlRepository(AuthorBooksDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
        }

        public void AddBookByAuthor(int authorId, Book book)
        {
            book.AuthorId = authorId;
            _context.Books.Add(book);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.Include("Books").ToList();
        }

        public IEnumerable<Book> GetAllBooks(int authorId)
        {
            return _context.Books.Where(x => x.AuthorId == authorId).ToList();
        }

        public Author GetAuthorById(int authorId)
        {
            return _context.Authors.FirstOrDefault(x => x.Id == authorId);
        }

        public Book GetBookById(int authorId, int bookId)
        {
            return _context.Books.FirstOrDefault(x => x.AuthorId == authorId && x.Id == bookId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }
    }
}
