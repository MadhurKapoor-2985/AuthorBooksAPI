using AuthorBooksAPI.Dtos;
using AuthorBooksAPI.Model;
using AuthorBooksAPI.Repository;
using AutoMapper;
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
        private readonly IAuthorBooksRepository _repository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorBooksRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _repository.GetAllAuthors();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authors));
        }

        public IActionResult AddAuthor(AuthorCreateDto authorCreateDto)
        {
            var author = _mapper.Map<Author>(authorCreateDto);
            _repository.AddAuthor(author);
            _repository.SaveChanges();

            var authorDto = _mapper.Map<AuthorDto>(author);

            return CreatedAtRoute(nameof(GetAuthorById), new { authorId = authorDto.Id }, authorDto);
        }

        [HttpGet("{authorId}", Name ="GetAuthorById")]
        public IActionResult GetAuthorById(int authorId)
        {
            var author = _repository.GetAuthorById(authorId);

            if(author == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(author));
        }
    }
}
