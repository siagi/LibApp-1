using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BooksController(IBookRepository booksRepository, IMapper mapper)
        {
            _bookRepository = booksRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = _bookRepository.GetBooks();
            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }
        [HttpGet("{id}", Name ="GetBookById")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookDto>(book));
        }
        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBook(int id)
        {
            try
            {
                _bookRepository.DeleteBook(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new BadHttpRequestException(e.Message, (int)HttpStatusCode.BadRequest);
            }
        }

    }
}
