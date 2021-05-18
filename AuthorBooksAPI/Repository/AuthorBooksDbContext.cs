using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorBooksAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace AuthorBooksAPI.Repository
{
    public class AuthorBooksDbContext: DbContext
    {
        public AuthorBooksDbContext(DbContextOptions<AuthorBooksDbContext> opt) : base(opt)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
