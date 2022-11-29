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

        public IEnumerable<string> GetAllAuthorsByCountry(string country)
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

        public IEnumerable<int> GetAllOldBooks(int yearOfBoomers)
        {

            var result = from source in ReadAllBook()
                         where source.ReleaseYear <= yearOfBoomers
                         select source.BookId;

            return result;
            ;
        }
       



        public IEnumerable<string> GetLastCheapestPublisher()
        {
            var result = ReadAllPublisher();
            int min = 4000;
            List<string> list = new List<string>();
            foreach (var pub in result)
            {
                if (pub.PublishingPrice < min)
                {
                    min = pub.PublishingPrice;
                    list.Add(pub.PublisherName);
                }
            }
            return list;
        }

        public IEnumerable<string> ListPublisherByPrintingCapacity()
        {
            var result = from c in ReadAllPublisher()
                         where c.PrintingCapacity > 80
                         select new
                         {
                             Name = c.PublisherName,
                             Capacity = c.PrintingCapacity
                         }.ToString();
            return result;
        }

        public IEnumerable<ComparedBooks> HackIMDB(int yearOfBoomers)
        {
            var source = GetAllOldBooks(yearOfBoomers);
            List<ComparedBooks> list = new List<ComparedBooks>();
            foreach (var thisbookId in source)
            {
                Book _old = ReadBook(thisbookId);
               
                double magic = (double)_old.Rating + 1;
                list.Add(new ComparedBooks(_old.Title, _old.Rating, magic, _old.ReleaseYear));
            }

            return list;
        }
        public IEnumerable<string> GetAllActionBooksWithMoreRatingThan2()
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
        //public IEnumerable<string> GetBooksByAuthor(string name)
        //{
        //    var res = from mvs in ctx.Books
        //              join g in ctx.Authors on mvs.Authorid equals g.AuthorId
        //              //where mvs.Authorid == g.AuthorId
        //              where g.Name == name
        //              select new
        //              {
        //                  Name = g.Name,
        //                  AuthorId = g.AuthorId,
        //                  BookId = mvs.BookId,
        //                  BookName = mvs.Title
        //              }.ToString();
        //    return res;
        //    ;
        //}
        PublisherDbContext ctx = new PublisherDbContext();
        //  public IEnumerable<string> BooksBetween
        public IEnumerable<string> GetBooksByAuthor(string name)
        {
            var res = from mvs in ctx.Books
                      where mvs.Author.Name==name
                      select new
                      {
                          AuthorName = mvs.Author.Name,
                          Title = mvs.Title
                      }.ToString();
                      
            return res;
            ;
        }
        public IEnumerable<string> GetBookByPublisher(int startDate, int finalDate)
        {
            var res = from mvs in ctx.Books
                      where mvs.ReleaseYear >= startDate && mvs.ReleaseYear <= finalDate
                      select new
                      {
                          BookName= mvs.Title,
                          ReleaseYear=mvs.ReleaseYear,
                          PublisherName=mvs.Publisher.PublisherName
                      }.ToString();
            return res;
        }
        public IEnumerable<string> BookCountByAuthors()
        {
            var res = from mvs in ctx.Books
                      group mvs by mvs.Author.Name into g
                      orderby g.Count() descending
                      select new
                      {
                          AuthorName = g.Key,
                          BookCount = g.Count(),
                          

                      }.ToString();

            return res;
        }
        public IEnumerable<string>WhichPublisherPublishedTheAuthorsBook(string name)
        {
            var res = from mvs in ctx.Books
                      where mvs.Author.Name == name
                      select new
                      {
                          AuthorName = mvs.Author.Name,
                          BookTitle = mvs.Title,
                          PublisherName = mvs.Publisher.PublisherName
                      }.ToString();

                return res;
        }



    }
}