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
    }
}