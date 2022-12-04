using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCZ6Y1_HFT_2022231.Models;
using WCZ6Y1_HFT_2022231.Repository;

namespace WCZ6Y1_HFT_2022231.Logic
{
    public class ComparedBooks
    {
        public string NameOfTheBook { get; set; }
        public double? OldRating { get; set; }
        public double NewRating { get; set; }
        public int YearOfTheBook { get; set; }

        public ComparedBooks(string nameOfTheBook, double? oldRating, double newRating, int yearOfTheBook)
        {
            NameOfTheBook = nameOfTheBook;
            OldRating = oldRating;
            NewRating = newRating;
            YearOfTheBook = yearOfTheBook;
        }

        public override string ToString()
        {
            return NameOfTheBook + " rating: " + OldRating + " new rating: " + NewRating;
        }
    }
    public class SideLogic : MainLogic, ISideLogic
    {
        public SideLogic(IRepository<Author> authorRepo, IRepository<Publisher> publisherRepo, IRepository<Book> bookRepo)
                   : base(authorRepo, publisherRepo, bookRepo)
        {
        }

       
        public IEnumerable<string> GetAllActionBooksWithMoreRatingThan2() //megtart
        {
            var res = from mvs in ReadAllBook()
                      where mvs.Rating > 2
                      select new
                      {
                          name = mvs.Title,
                          genr = mvs.Genre,
                          rat = mvs.Rating
                      };
            var res2 = from idk in res
                       where idk.genr.Equals("Action")
                       select new
                       {
                           Name = idk.name,
                           Rating = idk.rat,
                       }.ToString();

            return res2;


        }
       
        PublisherDbContext ctx = new PublisherDbContext();
        //  public IEnumerable<string> BooksBetween
        public IEnumerable<string> GetAllAuthorsByCountry(string country) //Megtartani
        {
            var result = from source in ReadAllAuthor()
                         where source.HomeCountry.Equals(country)
                         select new
                         {
                             Name = source.Name,
                             Country = source.HomeCountry
                         }.ToString();

            return result;
        }
        public IEnumerable<AuthorsBook> GetAllAuthorsByCountry2(string country) //Megtartani
        {
            return from source in ReadAllAuthor()
                   where source.HomeCountry.Equals(country)
                   select new AuthorsBook()
                   {
                       Name = source.Name,
                       Country = source.HomeCountry
                   };


        }
        public IEnumerable<string> GetBookByPublisher(int startDate, int finalDate) //megtart
        {
            var res = from mvs in ReadAllBook()
                      from y in ReadAllPublisher()
                      where mvs.ReleaseYear >= startDate && mvs.ReleaseYear <= finalDate && mvs.BookId == y.PublisherId
                      select new
                      {
                          BookName = mvs.Title,
                          ReleaseYear = mvs.ReleaseYear,
                          PublisherName = y.PublisherName
                      }.ToString();
            return res;
        }
        public IEnumerable<BookByPublisher> GetBookByPublisher2(int startDate, int finalDate) //megtart
        {
            var res = from mvs in ReadAllBook()
                      from y in ReadAllPublisher()
                      where mvs.ReleaseYear >= startDate && mvs.ReleaseYear <= finalDate && mvs.BookId == y.PublisherId
                      select new BookByPublisher()
                      {
                          BookName = mvs.Title,
                          ReleaseYear = mvs.ReleaseYear,
                          PublisherName = y.PublisherName
                      };
            return res;

        }
        public IEnumerable<string> GetBooksByAuthor(string name) //megtart 
        {
            var res = from mvs in ReadAllAuthor()
                      from y in ReadAllBook()
                      where mvs.Name == name && mvs.AuthorId == y.BookId
                      select new
                      {
                          AuthorName = mvs.Name,
                          Title = y.Title
                      }.ToString();

            return res;
            ;
        }
        public IEnumerable<BooksByAuthor> GetBooksByAuthor2(string name) //megtart 
        {
            var res = from mvs in ReadAllAuthor()
                      from y in ReadAllBook()
                      where mvs.Name == name && mvs.AuthorId == y.BookId
                      select new BooksByAuthor()
                      {
                          AuthorName = mvs.Name,
                          Title = y.Title
                      };

            return res;
            ;
        }

        public IEnumerable<string> WhichPublisherPublishedTheAuthorsBook(string name) //megtart
        {
            var res = from mvs in ReadAllBook()
                      from y in ReadAllAuthor()
                      from x in ReadAllPublisher()
                      where mvs.Title == name && y.AuthorId == x.PublisherId && mvs.BookId == x.PublisherId
                      select new
                      {
                          AuthorName = y.Name,
                          BookTitle = mvs.Title,
                          PublisherName = x.PublisherName
                      }.ToString();

            return res;
        }
        public IEnumerable<string> OlderThan100AuthorAndTheirBooks() //megtart
        {



            int t = DateTime.Now.Year;
            var res = from mvs in ReadAllBook()
                      from y in ReadAllAuthor()
                      from x in ReadAllPublisher()
                      where (t - y.BirthYear) > 100
                      where (y.AuthorId == x.PublisherId)
                      where (mvs.BookId == x.PublisherId)

                      select new
                      {
                          AuthorName = y.Name,
                          Birthyear = y.BirthYear,
                          BookTitle = mvs.Title,
                          // BookRating = mvs.Rating,
                          PublisherName = x.PublisherName

                      }.ToString();

            return res;
        }
        public IEnumerable<OlderThan30> OlderThan100AuthorAndTheirBooks2() //megtart
        {



            int t = DateTime.Now.Year;
            var res = from mvs in ReadAllBook()
                      from y in ReadAllAuthor()
                      from x in ReadAllPublisher()
                      where (t - y.BirthYear) > 100
                      where (y.AuthorId == x.PublisherId)
                      where (mvs.BookId == x.PublisherId)

                      select new OlderThan30()
                      {
                          AuthorName = y.Name,
                          Birthyear = y.BirthYear,
                          BookTitle = mvs.Title,
                          // BookRating = mvs.Rating,
                          PublisherName = x.PublisherName

                      };

            return res;
        }


    }
}