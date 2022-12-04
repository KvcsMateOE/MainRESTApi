using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCZ6Y1_HFT_2022231.Models;

namespace WCZ6Y1_HFT_2022231.Logic
{
    public interface ISideLogic
    {

        // IEnumerable<string> ListPublisherByPrintingCapacity();
        IEnumerable<string> GetAllAuthorsByCountry(string country);
        IEnumerable<AuthorsBook> GetAllAuthorsByCountry2(string country);
        // IEnumerable<int> GetAllOldBooks(int yearOfBoomers);
        // IEnumerable<ComparedBooks> HackIMDB(int yearOfBoomers);
        // IEnumerable<string> GetLastCheapestPublisher();
        IEnumerable<string> GetAllActionBooksWithMoreRatingThan2();
        IEnumerable<string> GetBooksByAuthor(string name); // ez az új
        IEnumerable<BooksByAuthor> GetBooksByAuthor2(string name);
        IEnumerable<string> GetBookByPublisher(int startDate, int finalDate);
        IEnumerable<BookByPublisher> GetBookByPublisher2(int startDate, int finalDate);
        // IEnumerable<string> BookCountByAuthors();
        IEnumerable<string> WhichPublisherPublishedTheAuthorsBook(string name);
        IEnumerable<string> OlderThan100AuthorAndTheirBooks();
        IEnumerable<OlderThan30> OlderThan100AuthorAndTheirBooks2();
    }
}

