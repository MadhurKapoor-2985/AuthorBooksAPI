using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBooksAPI.Dtos
{
    public class BookDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public DateTime? DatePublished { get; set; }
        public int AuthorId { get; set; }
    }
}
