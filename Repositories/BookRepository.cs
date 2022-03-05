using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
           _context.Books.Add(book);
        }

        public void DeleteBook(int bookId)
        {
           _context.Books.Remove(GetBookById(bookId));
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.Include(b => b.Genre);
        }

        public void UpdateBook(Book book)
        {
            throw new System.NotImplementedException();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
