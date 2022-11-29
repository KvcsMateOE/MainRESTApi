using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCZ6Y1_HFT_2022231.Client.Menu.Function;

namespace WCZ6Y1_HFT_2022231.Client.Menu
{
   public class SubMenus
    {
        public static ConsoleMenu SetupAuthorSub()
        {
            var AuthorSub = new ConsoleMenu(new string[] { "null" }, 1)
                .Add("View all authors", () => MenuFunctions.ReadAllAuthors())
                .Add("Add a new author", () => MenuFunctions.CreateOrUpdateAuthor(true))
                .Add("Modify an author", () => MenuFunctions.CreateOrUpdateAuthor(false))
                .Add("Delete an author", () => MenuFunctions.DeleteAuthor())
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "-->";
                    config.EnableWriteTitle = true;
                    config.Title = "Author Menu";
                });

            return AuthorSub;
        }

        public static ConsoleMenu SetupBookSub()
        {
            var BookSub = new ConsoleMenu(new string[] { "null" }, 1)
                .Add("View all books", () => MenuFunctions.ReadAllBooks())
                .Add("Add a new book", () => MenuFunctions.CreateOrUpdateBook(true))
                .Add("Modify a book", () => MenuFunctions.CreateOrUpdateBook(false))
                .Add("Delete a book", () => MenuFunctions.DeleteBook())
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "-->";
                    config.EnableWriteTitle = true;
                    config.Title = "Book Menu";
                });

            return BookSub;
        }

        public static ConsoleMenu SetupPublisherSub()
        {
            var PublisherSub = new ConsoleMenu(new string[] { "null" }, 1)
                .Add("View all publishers", () => MenuFunctions.ReadAllPublisher())
                .Add("Add a new publisher", () => MenuFunctions.CreateOrUpdatePublisher(true))
                .Add("Modify a publisher", () => MenuFunctions.CreateOrUpdatePublisher(false))
                .Add("Delete a publisher", () => MenuFunctions.DeletePublisher())
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "-->";
                    config.EnableWriteTitle = true;
                    config.Title = "Publisher Menu";
                });

            return PublisherSub;
        }

        public static ConsoleMenu SetupQuerySub()
        {
            var QuerySub = new ConsoleMenu(new string[] { "null" }, 1)
                .Add("Show Capacity", () => MenuFunctions.PrintSideResult("ListPublisherByPrintingCapacity"))
                .Add("Get All Authors By Country (Enter country)", () => MenuFunctions.PrintSideResult("GetAllAuthorsByCountry"))
                .Add("Get All Old Books (Enter year)", () => MenuFunctions.PrintSideResult("GetAllOldBooks"))
                .Add("Hack IMDB (Enter year)", () => MenuFunctions.PrintSideResult("HackIMDB"))
                .Add("Get Last Cheapest Publishers", () => MenuFunctions.PrintSideResult("GetLastCheapestPublishers"))
                .Add("JoinedTabledPublisherQuery", () => MenuFunctions.PrintSideResult("GetAllActionBooksWithMoreRatingThan2"))
                .Add("Books by author (Enter author name)",() => MenuFunctions.PrintSideResult("GetBooksByAuthor")) // itt az újítás
                .Add("Books by publisher between time interval (Enter 2 year)", () =>MenuFunctions.PrintSideResult("GetBookByPublisher"))
                .Add("Book counter by author", () => MenuFunctions.PrintSideResult("BookCountByAuthors"))
                .Add("The author's book published by these publisher: (Enter author name)", () => MenuFunctions.PrintSideResult("WhichPublisherPublishedTheAuthorsBook"))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "-->";
                    config.EnableWriteTitle = true;
                    config.Title = "Query Menu";
                });

            return QuerySub;
        }
    }
}
