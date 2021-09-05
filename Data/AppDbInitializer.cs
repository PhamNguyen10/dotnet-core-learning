using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Linq;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange
                    (
                        new Publisher() { Name = "Publisher 3" },
                        new Publisher() { Name = "Publisher 2" },
                        new Publisher() { Name = "Publisher 1" }                    
                    );

                    context.SaveChanges();
                }

                if (!context.Authors.Any())
                {
                    context.Authors.AddRange
                    (
                        new Author() { FullName = "Authors 3" },
                        new Author() { FullName = "Authors 2" },
                        new Author() { FullName = "Authors 1" }
                    );

                    context.SaveChanges();
                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange
                    (
                        new Book()
                        {
                            Title = "1st Book Title",
                            Description = "1st Book Title Description",
                            IsRead = true,
                            DateRead = DateTime.Now.AddDays(-10),
                            Rate = 4,
                            Genre = "Biography",
                            CoverUrl = "https://www.google.com.vn",
                            DateAdded = DateTime.Now.AddDays(-10),

                            //Navigation
                            PublisherId = 1
                        },
                        new Book()
                        {
                            Title = "2nd Book Title",
                            Description = "2nd Book Title Description",
                            IsRead = false,
                            DateRead = DateTime.Now.AddDays(-10),
                            Rate = 4,
                            Genre = "Biography",
                            CoverUrl = "https://www.google.com.vn",
                            DateAdded = DateTime.Now.AddDays(-10),

                            //Navigation
                            PublisherId = 1
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
