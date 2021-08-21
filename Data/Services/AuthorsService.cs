using my_books.Data.Models;
using my_books.Data.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        internal void Add(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        internal object GetAll() => _context.Authors.ToList();

        internal object GetById(int id) => _context.Authors.FirstOrDefault(a => a.Id == id);

        internal object UpdateById(int id, AuthorVM author)
        {
            var _author = _context.Authors.FirstOrDefault(a => a.Id == id);
            if (_author != null)
            {
                _author.FullName = author.FullName;

                _context.SaveChanges();
            }

            return _author;
        }

        internal void DeleteById(int id)
        {
            var _author = _context.Authors.FirstOrDefault(a => a.Id == id);
            if (_author != null)
            {
                _context.Authors.Remove(_author);
                _context.SaveChanges();
            }
        }
    }
}
