using AuthorBooksAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBooksAPI.Repository
{
    public interface IAuthorRepository
    {
        bool SaveChanges();
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int authorId);

       
    }
}
