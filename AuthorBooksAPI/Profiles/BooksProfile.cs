using AuthorBooksAPI.Dtos;
using AuthorBooksAPI.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBooksAPI.Profiles
{
    public class BooksProfile: Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookCreateDto, Book>();
        }
    }
}
