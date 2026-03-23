using Microsoft.EntityFrameworkCore;
using CodVeda_FullStack_Intern.Models;

namespace CodVeda_FullStack_Intern.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FullName = "System Admin",
                Email = "admin@gmail.com",
                Password = "&0137Admin"
            });

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Adventures of Sherlock Holmes",
                    Publisher = "George Newnes",
                    PublishDate = "1892",
                    Summary = "A collection of twelve short stories featuring the legendary detective Sherlock Holmes and his companion Dr. Watson.",
                    ReadUrl = "https://www.gutenberg.org/files/1661/1661-h/1661-h.htm"
                },
                new Book
                {
                    Id = 2,
                    Title = "Alice's Adventures in Wonderland",
                    Publisher = "Macmillan",
                    PublishDate = "1865",
                    Summary = "A young girl named Alice falls through a rabbit hole into a fantasy world populated by peculiar, anthropomorphic creatures.",
                    ReadUrl = "https://www.gutenberg.org/files/11/11-h/11-h.htm"
                },
                new Book
                {
                    Id = 3,
                    Title = "The Great Gatsby",
                    Publisher = "Charles Scribner's Sons",
                    PublishDate = "1925",
                    Summary = "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan in the Roaring Twenties.",
                    ReadUrl = "https://www.gutenberg.org/cache/epub/64317/pg64317-images.html"
                }
            );
        }
    }
}