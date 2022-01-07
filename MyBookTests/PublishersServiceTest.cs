using Microsoft.EntityFrameworkCore;
using MyBook.Data;
using MyBook.Data.Models;
using MyBook.Data.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace MyBookTests
{
    public class PublishersServiceTest
    {
        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "mybooksapidb")
            .Options;

        AppDbContext context;

        PublishersService publishersService;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();

            publishersService = new PublishersService(context);
        }


        [Test]
        public void GetAllPublishers_WithNoSortBy_WithNoSearchString_WithNoPageNumber()
        {
            var result = publishersService.GetAllPublishers("", "", null);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.AreEqual(result.Count, 3);
        }

       

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }
        private void SeedDatabase()
        {  
            var publishers = new List<Publisher>
            {
                new Publisher()
                {
                    Id = 1111,
                    Name = "Per 1111"
                },
                new Publisher()
                {
                    Id = 2222,
                    Name = "Per 2222"
                },
                new Publisher()
                {
                    Id = 3333,
                    Name = "Per 3300"
                },
            };
            context.Publishers.AddRange(publishers);

            var author = new List<Author>
            {
                new Author()
                {
                    Id = 1100,
                    FullName = "Per 1100"
                },
                new Author()
                {
                    Id = 2200,
                    FullName = "Per 2200"
                },
                new Author()
                {
                    Id = 3300,
                    FullName = "Per 3300"
                },
            };
            context.Authors.AddRange(author);

            var book = new List<Book>
            {
                new Book()
                {
                    Id = 1100,
                    Title = "Per 1001"
                },
                new Book()
                {
                    Id = 2200,
                    Title = "Per 2002"
                },
                new Book()
                {
                    Id = 3300,
                    Title = "Per 3003"
                },
            };
            context.Books.AddRange(book);

            context.SaveChanges();

        }
    }
}