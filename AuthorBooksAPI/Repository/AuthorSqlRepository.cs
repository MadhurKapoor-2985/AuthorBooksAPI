using AuthorBooksAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBooksAPI.Repository
{
    public class AuthorSqlRepository : IAuthorRepository
    {
        private readonly AuthorBooksDbContext _context;

        public AuthorSqlRepository(AuthorBooksDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthorById(int authorId)
        {
            return _context.Authors.FirstOrDefault(x => x.Id == authorId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }
    }
}
