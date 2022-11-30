using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WCZ6Y1_HFT_2022231.Logic;
using WCZ6Y1_HFT_2022231.Models;
using WCZ6Y1_HFT_2022231.Repository;

namespace WCZ6Y1_HFT_2022231.Test
{
    [TestFixture]
    public class LogicTester
    {

        Mock<IRepository<Author>> mockAuthorRepo;
        Mock<IRepository<Publisher>> mockPublisherRepo;
        Mock<IRepository<Book>> mockBookRepo;

        IMainLogic logic;
        ISideLogic isl;

        [SetUp]
        public void Setup()
        {
            mockAuthorRepo = new Mock<IRepository<Author>>(MockBehavior.Loose);
            mockPublisherRepo = new Mock<IRepository<Publisher>>(MockBehavior.Loose);
            mockBookRepo = new Mock<IRepository<Book>>(MockBehavior.Loose);

            var testAuthors = new List<Author>()
            {
                new Author() { AuthorId = 1, BirthYear = 1986, Gender = 0, HomeCountry = "Hungary", Name = "Nagy Elemér" },
            new Author() { AuthorId = 2, BirthYear = 1940, Gender = 1, HomeCountry = "Germany", Name = "Hans Landa" },
            new Author() { AuthorId = 3, BirthYear = 1944, Gender = 1, HomeCountry = "Argentina", Name = "Joaquin Messi" },
            new Author() { AuthorId = 4, BirthYear = 1990, Gender = 0, HomeCountry = "France", Name = "Zinedine Zadan" },
            new Author() { AuthorId = 5, BirthYear = 1880, Gender = 0, HomeCountry = "Denmark", Name = "Christian Meriksen" },
            new Author() { AuthorId = 6, BirthYear = 1455, Gender = 0, HomeCountry = "Hungary", Name = "Kiss Elemér" },
            new Author() { AuthorId = 7, BirthYear = 1912, Gender = 1, HomeCountry = "Hungary", Name = "Lapos Elemér" },
            new Author() { AuthorId = 8, BirthYear = 1945, Gender = 0, HomeCountry = "Scotland", Name = "Scott McTominuy" },
            new Author() { AuthorId = 9, BirthYear = 1968, Gender = 1, HomeCountry = "China", Name = "Xiam-ping" },
            new Author() { AuthorId = 10, BirthYear = 2000, Gender = 0, HomeCountry = "Hungary", Name = "Kovács Máté" },
        }.AsQueryable();

            var testBooks = new List<Book>()
            {
            new Book() { BookId = 1, Translator = "Károli Gáspár", Genre = "Action", Title = "Transformers", Rating = 4.5, ReleaseYear = 2007 },
            new Book() { BookId = 2, Translator = "Nemes-Kiss Ágnes", Genre = "Fantasy", Title = "Koromfeketécske", Rating = 4.5, ReleaseYear = 2000 },
            new Book() { BookId = 3, Translator = "Weöres Nándor", Genre = "Horror", Title = "Hári Pooter", Rating = 3.7, ReleaseYear = 2002 },
            new Book() { BookId = 4, Translator = "None", Genre = "Action", Title = "Tüskevár", Rating = 5.0, ReleaseYear = 1960 },
            new Book() { BookId = 5, Translator = "Kosztolányi Rezső", Genre = "Action", Title = "Trónok békéje", Rating = 4.55, ReleaseYear = 2009 },
            new Book() { BookId = 6, Translator = "Hadházi László", Genre = "Thriller", Title = "Bosszútállók", Rating = 4.5, ReleaseYear = 2011 },
            new Book() { BookId = 7, Translator = "Kőhalmi Zoltán", Genre = "Action", Title = "Legyek ura", Rating = 2.5, ReleaseYear = 2020 },
            new Book() { BookId = 8, Translator = "Kovács András Péter", Genre = "Fantasy", Title = "Lecsó", Rating = 1.5, ReleaseYear = 2001 },
            new Book() { BookId = 9, Translator = "Kiss Ádám", Genre = "Horror", Title = "Az", Rating = 0.5, ReleaseYear = 1943 },
            new Book() { BookId = 10, Translator = "Ráskó Eszter", Genre = "Drama", Title = "Holnapután", Rating = 3.5, ReleaseYear = 1956 },
        }.AsQueryable();

            var testPublishers = new List<Publisher>()
            {
            new Publisher() { PublisherId = 1, Address = "1062 Budapest Váci út 1", PublisherName = "WestEnd Book", NumberOfContacts=1000,PrintingCapacity=100,PublishingPrice=3000 },
            new Publisher() { PublisherId = 2, Address = "1062 Budapest Váci út 2", PublisherName = "Aréna Book", NumberOfContacts = 2000, PrintingCapacity = 200, PublishingPrice = 3500 },
            new Publisher() { PublisherId = 3, Address = "1062 Budapest Váci út 3", PublisherName = "Libri", NumberOfContacts = 3000, PrintingCapacity = 300, PublishingPrice = 4000 },
            new Publisher() { PublisherId = 4, Address = "1062 Budapest Váci út 4", PublisherName = "Aba könykiadó", NumberOfContacts = 4000, PrintingCapacity = 400, PublishingPrice = 4500 },
            new Publisher() { PublisherId = 5, Address = "1062 Budapest Váci út 5", PublisherName = "Líra", NumberOfContacts = 5000, PrintingCapacity = 500, PublishingPrice = 5000 },
            new Publisher() { PublisherId = 6, Address = "1062 Budapest Váci út 6", PublisherName = "Bookline", NumberOfContacts = 6000, PrintingCapacity = 600, PublishingPrice = 5500 },
            new Publisher() { PublisherId = 7, Address = "1062 Budapest Váci út 7", PublisherName = "Alexandria kiadó", NumberOfContacts = 7000, PrintingCapacity = 700, PublishingPrice = 6000 },
            new Publisher() { PublisherId = 8, Address = "1062 Budapest Váci út 8", PublisherName = "Bába kiadó", NumberOfContacts = 8000, PrintingCapacity = 800, PublishingPrice = 6500 },
            new Publisher() { PublisherId = 9, Address = "1062 Budapest Váci út 9", PublisherName = "Balassi kiadó", NumberOfContacts = 9000, PrintingCapacity = 900, PublishingPrice = 7000 },
            new Publisher() { PublisherId = 10, Address = "1062 Budapest Váci út 10", PublisherName = "Mozaik kiadó", NumberOfContacts = 10000, PrintingCapacity = 1000, PublishingPrice = 7500 },
        }.AsQueryable();

            mockAuthorRepo.Setup(m => m.ReadAll()).Returns(testAuthors);
            mockBookRepo.Setup(m => m.ReadAll()).Returns(testBooks);
            mockPublisherRepo.Setup(m => m.ReadAll()).Returns(testPublishers);

            mockAuthorRepo.Setup(m => m.ReadOne(It.IsAny<int>())).Returns((int i) => testAuthors.Where(x => x.AuthorId.Equals(i)).FirstOrDefault());
            mockBookRepo.Setup(m => m.ReadOne(It.IsAny<int>())).Returns((int i) => testBooks.Where(x => x.BookId.Equals(i)).FirstOrDefault());
            mockPublisherRepo.Setup(m => m.ReadOne(It.IsAny<int>())).Returns((int i) => testPublishers.Where(x => x.PublisherId.Equals(i)).FirstOrDefault());

            logic = new MainLogic(mockAuthorRepo.Object, mockPublisherRepo.Object, mockBookRepo.Object);
            isl = new SideLogic(mockAuthorRepo.Object, mockPublisherRepo.Object, mockBookRepo.Object);
        }
        [Test]
        public void CreateNonExistingAuthor()
        {
            Author test = new Author() { AuthorId = 11, BirthYear = 2000, Gender = 1, HomeCountry = "Usa", Name = "John Wick" };
            logic.CreateAuthor(test);
            mockAuthorRepo.Verify(m => m.Create(It.IsAny<Author>()), Times.Once);
        }
        [Test]
        public void GetAllPublishers()
        {
            int count = logic.ReadAllPublisher().Count();
            Assert.That(count, Is.EqualTo(10));
            mockPublisherRepo.Verify(m => m.ReadAll(), Times.Once);
        }

        [Test]
        public void DeleteNullBook()
        {
            Assert.Throws<InvalidOperationException>(() => logic.DeleteBook(100));
            mockBookRepo.Verify(m => m.Remove(It.IsAny<Book>()), Times.Never);
        }

        [Test]
        public void CreateExistingAuthor()
        {
            Author test = new Author() { AuthorId = 1, BirthYear = 1986, Gender = 0, HomeCountry = "Hungary", Name = "Nagy Elemér" };
            Assert.Throws<InvalidOperationException>(() => logic.CreateAuthor(test));
            mockAuthorRepo.Verify(m => m.Create(It.IsAny<Author>()), Times.Never);
        }

        [Test]
        public void FirstAuthorsBirthYearEightySix()
        {
            int firstBirthYear = logic.ReadAllAuthor().FirstOrDefault().BirthYear.GetValueOrDefault();
            Assert.That(firstBirthYear, Is.EqualTo(1986));
            mockAuthorRepo.Verify(m => m.ReadAll(), Times.Once);
        }

        [Test]
        public void FirstAuthorBirthYearIsNotNinty()
        {
            int firstBirthYear = logic.ReadAllAuthor().FirstOrDefault().BirthYear.GetValueOrDefault();
            Assert.That(firstBirthYear, Is.Not.EqualTo(1990));
            mockAuthorRepo.Verify(m => m.ReadAll(), Times.Once);
        }

        [Test]
        public void IMBDTest()
        {
            int testyear = 2010;
            var s = isl.HackIMDB(testyear);
            int minYear = testyear;
            foreach (var item in s)
            {
                if (item.YearOfTheBook < minYear)
                {
                    minYear = item.YearOfTheBook;//a
                }
            }
            var vegleges = from oldest in s
                           where oldest.YearOfTheBook.Equals(minYear)
                           select oldest;
            ComparedBooks endend = vegleges.First();
            Assert.That(endend.ToString(), Is.EqualTo(new ComparedBooks("Az", 0.5, 1.5, 1943).ToString()));
        }

        [Test]
        public void GetAllAuthorsByCountryTest()
        {
            string s = isl.GetAllAuthorsByCountry("Hungary").First();
            Assert.That(s, Is.EqualTo("{ Name = Nagy Elemér, Country = Hungary }"));
        }

        [Test]
        public void GetAllOldBooksTest()
        {
            int s = isl.GetAllOldBooks(2000).First();
            Assert.That(s, Is.EqualTo(2));
        }

        [Test]
        public void GetLastCheapestPublishersTest()
        {
            string s = isl.GetLastCheapestPublisher().First();
            Assert.That(s, Is.EqualTo("WestEnd Book"));
        }

        [Test]
        public void ListPublisherByPrintingCapacityTest()
        {
            string s = isl.ListPublisherByPrintingCapacity().First();
            Assert.That(s, Is.EqualTo("{ Name = WestEnd Book, Capacity = 100 }"));
        }
        [Test]
        public void GetBooksByAuthorTest()
        {
            string s = isl.GetBooksByAuthor("Kovács Máté").First();
            Assert.That(s, Is.EqualTo("{ AuthorName = Kovács Máté, Title = Tüskevár }"));
        }
        [Test]
        public void GetBookByPublisherTest()
        {
            string s = isl.GetBookByPublisher(1999,2003).First();
            Assert.That(s,Is.EqualTo("{ BookName = Koromfeketécske, ReleaseYear = 2000, PublisherName = Aréna Book }"));
        }
        [Test]
        public void BookCountByAuthorsTest()
        {
            string s = isl.BookCountByAuthors().First();
            Assert.That(s, Is.EqualTo("{ AuthorName = Kovács Máté, BookCount = 2 }"));
        }
        [Test]
        public void WhichPublisherPublishedTheAuthorsBookTest()
        {
            string s = isl.WhichPublisherPublishedTheAuthorsBook("Kovács Máté").First();
            Assert.That(s, Is.EqualTo("{ AuthorName = Kovács Máté, BookTitle = Tüskevár, PublisherName = Aba könykiadó }"));
        }
        [Test]
        public void WhichPublisherPublishedTheAuthorsBookTest2()
        {
            Assert.That(() => isl.WhichPublisherPublishedTheAuthorsBook("Kovács Máté"), Throws.Nothing);
        }
        [Test]
        public void OlderThan30AuthorAndTheirBooks()
        {
            string s = isl.OlderThan30AuthorAndTheirBooks().First();
            Assert.That(s, Is.EqualTo("{ AuthorName = Xiam-ping, AuthorID = 9, BookTitle = Transformers, BookRating = 4,5, PublisherName = WestEnd Book }"));
        }
    }
}
