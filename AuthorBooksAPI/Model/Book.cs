using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBooksAPI.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(400)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string ISBN { get; set; }
        [Required]
        [MaxLength(50)]
        public string Category { get; set; }
        public DateTime? DatePublished { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }


    }
}
