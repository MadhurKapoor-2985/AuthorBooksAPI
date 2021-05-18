using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBooksAPI.Model
{
    public class Author
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(6)]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public ICollection<Book> Books { get; set; }


    }
}
