using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyBook.Data.Models;
using System.Linq;

namespace MyBook.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            { 
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Title",
                        Description = "1st Description",
                        IsRead = true,
                        DateRead = System.DateTime.Now.AddDays(-10),
                        Rating = 5,
                        Genre = "Comic",
                        Author = "Dan",
                        CoverUrl = "https://...",
                        DateAdded = System.DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2nd Title",
                        Description = "2nd Description",
                        IsRead = false,
                        Genre = "Novel",
                        Author = "Haley",
                        CoverUrl = "https://...",
                        DateAdded = System.DateTime.Now
                    },
                    new Book()
                    {
                        Title = "3rd Title",
                        Description = "3rd Description",
                        IsRead = true,
                        DateRead = System.DateTime.Now.AddDays(-12),
                        Rating = 8,
                        Genre = "Detective",
                        Author = "Selock",
                        CoverUrl = "https://...",
                        DateAdded = System.DateTime.Now
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
