using AuthorBooksAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBooksAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = new List<Author> {
                new Author { FirstName = "Madhur", LastName = "Kapoor", DateOfBirth = Convert.ToDateTime("01/01/1985"), Gender = "M", Id = 1},
                new Author { FirstName = "S", LastName = "Kapoor", DateOfBirth = Convert.ToDateTime("06/06/1990"), Gender = "F", Id = 2},
            };

            return Ok(authors);
        }
    }
}
