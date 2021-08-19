using my_books.Data.Models;
using my_books.Data.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };

            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        public List<Book> GetAll() => _context.Books.ToList();
        public Book GetById(int bookId) => _context.Books.FirstOrDefault(b => b.Id == bookId);
        public Book UpdateById(int bookId, BookVM bookVM)
        {
            var _book =  _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (_book != null)
	        {
                _book.Title = bookVM.Title;
                _book.Description = bookVM.Description;
                _book.IsRead = bookVM.IsRead;
                _book.DateRead = bookVM.IsRead ? bookVM.DateRead.Value : null;
                _book.Rate = bookVM.IsRead ? bookVM.Rate.Value : null;
                _book.Genre = bookVM.Genre;
                _book.Author = bookVM.Author;
                _book.CoverUrl = bookVM.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }
    }
}
