using my_books.Data.Models;
using System;
using System.Collections.Generic;

namespace my_books.Data.Services.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverUrl { get; set; }

        //Navigation
        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
