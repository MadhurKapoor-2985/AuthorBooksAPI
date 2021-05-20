using AuthorBooksAPI.Dtos;
using AuthorBooksAPI.Model;
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
        public IActionResult GetBooksForAuthor(int authorId)
        {
            if(_repository.GetAuthorById(authorId) == null)
            {
                return NotFound();
            }

            var books = _repository.GetAllBooks(authorId);

            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        [HttpGet("{bookId}", Name ="GetBookById")]
        public IActionResult GetBookById(int authorId, int bookId)
        {
            if (_repository.GetAuthorById(authorId) == null)
            {
                return NotFound();
            }

            var book = _repository.GetBookById(authorId, bookId);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }

        public IActionResult AddBookByAuthor(int authorId, BookCreateDto bookCreateDto)
        {
            if(_repository.GetAuthorById(authorId) == null)
            {
                return NotFound();
            }

            var book = _mapper.Map<Book>(bookCreateDto);

            _repository.AddBookByAuthor(authorId, book);
            _repository.SaveChanges();

            var bookDto = _mapper.Map<BookDto>(book);

            return CreatedAtRoute(nameof(GetBookById), new { authorId = bookDto.AuthorId, bookId = bookDto.Id }, bookDto);
        }
    }
}
