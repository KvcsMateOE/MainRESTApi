using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCZ6Y1_HFT_2022231.Models;

namespace WCZ6Y1_HFT_2022231.Repository
{
   public class PublisherDbContext : DbContext
    {

        public PublisherDbContext()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {
                object p = optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("PublisherDatabase");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                modelBuilder.Entity<Book>()
                    .HasMany(m => m.Authors)
                    .WithMany(a => a.Books)
                    .UsingEntity(ma => ma.ToTable("BookAuthor"));

                modelBuilder.Entity<Book>()
                    .HasMany(m => m.Publishers)

                    .WithMany(a => a.Books)

                    .UsingEntity(ma => ma.ToTable("BookPublisher")
                    );

                Author a1 = new Author() { AuthorId = 1, BirthYear = 1986, Gender = 0, HomeCountry = "Hungary", Name = "Nagy Elemér" };
                Author a2 = new Author() { AuthorId = 2, BirthYear = 1940, Gender = 1, HomeCountry = "Germany", Name = "Hans Landa" };
                Author a3 = new Author() { AuthorId = 3, BirthYear = 1944, Gender = 1, HomeCountry = "Argentina", Name = "Joaquin Messi" };
                Author a4 = new Author() { AuthorId = 4, BirthYear = 1990, Gender = 0, HomeCountry = "France", Name = "Zinedine Zadan" };
                Author a5 = new Author() { AuthorId = 5, BirthYear = 1880, Gender = 0, HomeCountry = "Denmark", Name = "Christian Meriksen" };
                Author a6 = new Author() { AuthorId = 6, BirthYear = 1455, Gender = 0, HomeCountry = "Hungary", Name = "Kiss Elemér" };
                Author a7 = new Author() { AuthorId = 7, BirthYear = 1912, Gender = 1, HomeCountry = "Hungary", Name = "Lapos Elemér" };
                Author a8 = new Author() { AuthorId = 8, BirthYear = 1945, Gender = 0, HomeCountry = "Scotland", Name = "Scott McTominuy" };
                Author a9 = new Author() { AuthorId = 9, BirthYear = 1968, Gender = 1, HomeCountry = "China", Name = "Xiam-ping" };
                Author a10 = new Author() { AuthorId = 10, BirthYear = 2000, Gender = 0, HomeCountry = "Hungary", Name = "Kovács Máté" };

                Book b1 = new Book() { BookId = 1, Translator = "Károli Gáspár", Genre = "Action", Title = "Transformers", Rating = 4.5, ReleaseYear = 2007 };
                Book b2 = new Book() { BookId = 2, Translator = "Nemes-Kiss Ágnes", Genre = "Fantasy", Title = "Koromfeketécske", Rating = 4.5, ReleaseYear = 2000 };
                Book b3 = new Book() { BookId = 3, Translator = "Weöres Nándor", Genre = "Horror", Title = "Hári Pooter", Rating = 3.7, ReleaseYear = 2002 };
                Book b4 = new Book() { BookId = 4, Translator = "None", Genre = "Action", Title = "Tüskevár", Rating = 5.0, ReleaseYear = 1960 };
                Book b5 = new Book() { BookId = 5, Translator = "Kosztolányi Rezső", Genre = "Action", Title = "Trónok békéje", Rating = 4.55, ReleaseYear = 2009 };
                Book b6 = new Book() { BookId = 6, Translator = "Hadházi László", Genre = "Thriller", Title = "Bosszútállók", Rating = 4.5, ReleaseYear = 2011 };
                Book b7 = new Book() { BookId = 7, Translator = "Kőhalmi Zoltán", Genre = "Action", Title = "Legyek ura", Rating = 2.5, ReleaseYear = 2020 };
                Book b8 = new Book() { BookId = 8, Translator = "Kovács András Péter", Genre = "Fantasy", Title = "Lecsó", Rating = 1.5, ReleaseYear = 2001 };
                Book b9 = new Book() { BookId = 9, Translator = "Kiss Ádám", Genre = "Horror", Title = "Az", Rating = 0.5, ReleaseYear = 1943 };
                Book b10 = new Book() { BookId = 10, Translator = "Ráskó Eszter", Genre = "Drama", Title = "Holnapután", Rating = 3.5, ReleaseYear = 1956 };

                Publisher p1 = new Publisher() { PublisherId = 1, Address = "1062 Budapest Váci út 1", PublisherName = "WestEnd Book", NumberOfContacts = 1000, PrintingCapacity = 100, PublishingPrice = 3000 };
                Publisher p2 = new Publisher() { PublisherId = 2, Address = "1062 Budapest Váci út 2", PublisherName = "Aréna Book", NumberOfContacts = 2000, PrintingCapacity = 200, PublishingPrice = 3500 };
                Publisher p3 = new Publisher() { PublisherId = 3, Address = "1062 Budapest Váci út 3", PublisherName = "Libri", NumberOfContacts = 3000, PrintingCapacity = 300, PublishingPrice = 4000 };
                Publisher p4 = new Publisher() { PublisherId = 4, Address = "1062 Budapest Váci út 4", PublisherName = "Aba könykiadó", NumberOfContacts = 4000, PrintingCapacity = 400, PublishingPrice = 4500 };
                Publisher p5 = new Publisher() { PublisherId = 5, Address = "1062 Budapest Váci út 5", PublisherName = "Líra", NumberOfContacts = 5000, PrintingCapacity = 500, PublishingPrice = 5000 };
                Publisher p6 = new Publisher() { PublisherId = 6, Address = "1062 Budapest Váci út 6", PublisherName = "Bookline", NumberOfContacts = 6000, PrintingCapacity = 600, PublishingPrice = 5500 };
                Publisher p7 = new Publisher() { PublisherId = 7, Address = "1062 Budapest Váci út 7", PublisherName = "Alexandria kiadó", NumberOfContacts = 7000, PrintingCapacity = 700, PublishingPrice = 6000 };
                Publisher p8 = new Publisher() { PublisherId = 8, Address = "1062 Budapest Váci út 8", PublisherName = "Bába kiadó", NumberOfContacts = 8000, PrintingCapacity = 800, PublishingPrice = 6500 };
                Publisher p9 = new Publisher() { PublisherId = 9, Address = "1062 Budapest Váci út 9", PublisherName = "Balassi kiadó", NumberOfContacts = 9000, PrintingCapacity = 900, PublishingPrice = 7000 };
                Publisher p10 = new Publisher() { PublisherId = 10, Address = "1062 Budapest Váci út 10", PublisherName = "Mozaik kiadó", NumberOfContacts = 10000, PrintingCapacity = 1000, PublishingPrice = 7500 };

                modelBuilder.Entity<Author>().HasData(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
                modelBuilder.Entity<Book>().HasData(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10);
                modelBuilder.Entity<Publisher>().HasData(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            }
        }
    }
}
