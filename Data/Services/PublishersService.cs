using my_books.Data.Models;
using my_books.Data.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        internal void Add(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        internal List<Publisher> GetAll() => _context.Publishers.ToList();

        internal Publisher GetById(int id) => _context.Publishers.FirstOrDefault(p => p.Id == id);

        internal Publisher UpdateById(int id, PublisherVM publisher)
        {
            var _publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
            if (_publisher != null)
            {
                _publisher.Name = publisher.Name;

                _context.SaveChanges();
            }

            return _publisher;
        }

        internal void DeleteById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
