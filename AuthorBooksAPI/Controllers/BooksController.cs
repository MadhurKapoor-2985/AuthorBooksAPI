using AuthorBooksAPI.Dtos;
using AuthorBooksAPI.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBooksAPI.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/books")]
    public class BooksController : ControllerBase
    {
        private readonly IAuthorBooksRepository _repository;
        private readonly IMapper _mapper;

        public BooksController(IAuthorBooksRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks(int authorId)
        {
            var books = _repository.GetAllBooks(authorId);

            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        [HttpGet("{bookId}")]
        public IActionResult GetBookById(int authorId, int bookId)
        {
            var book = _repository.GetBookById(authorId, bookId);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }
    }
}
