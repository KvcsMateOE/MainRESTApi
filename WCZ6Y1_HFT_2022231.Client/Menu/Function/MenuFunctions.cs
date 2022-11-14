using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCZ6Y1_HFT_2022231.Models;

namespace WCZ6Y1_HFT_2022231.Client.Menu.Function
{
   public static class MenuFunctions
    {
        public static void PrintSideResult(string queryName)
        {
            Console.WriteLine("Enter the required variable (press Enter if not required):");
            string variable = Console.ReadLine();
            foreach (var queryItem in Program.REST_API.GetSideResult<string>("side", queryName, variable))
            {
                Console.WriteLine(queryItem);
            }
            Console.ReadLine();
        }

        public static void DeleteAuthor()
        {
            Console.WriteLine("Enter the Id of the entity you wish to delete:");
            int id = int.Parse(Console.ReadLine());
            Program.REST_API.Delete(id, "author");
        }

        public static void ReadOneAuthor()
        {
            Console.WriteLine("Enter the Id of the author you wish to read:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(Program.REST_API.Get<Author>(id, "author"));
            Console.ReadLine();
        }

        public static void ReadAllAuthors()
        {
            foreach (var author in Program.REST_API.Get<Author>("author"))
            {
                Console.WriteLine(author);
            }
            Console.ReadLine();
        }

        public static void CreateOrUpdateAuthor(bool Create)
        {
            int id = -1;
            if (!Create) // Update
            {
                Console.WriteLine("Enter the Id of the author you wish to update");
                id = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the name of the new author:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the birth of year of the new author (ie.: 1973):");
            int birthYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the home country of the new author:");
            string homeCountry = Console.ReadLine();
            Console.WriteLine("Enter the gender of the new author:");
            int gender = int.Parse(Console.ReadLine());

            Author newAuthor = new()
            {
                Name = name,
                BirthYear = birthYear,
                HomeCountry = homeCountry,
                Gender = gender
            };

            if (Create)
            {
                Program.REST_API.Post(newAuthor, "author");
            }
            else
            {
                Program.REST_API.Put(newAuthor, "author");
            }
        }

        public static void DeleteBook()
        {
            Console.WriteLine("Enter the Id of the entity you wish to delete:");
            int id = int.Parse(Console.ReadLine());
            Program.REST_API.Delete(id, "book");
        }

        public static void ReadOneBook()
        {
            Console.WriteLine("Enter the Id of the book you wish to read:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(Program.REST_API.Get<Book>(id, "book"));
            Console.ReadLine();
        }

        public static void ReadAllBooks()
        {
            foreach (var book in Program.REST_API.Get<Book>("book"))
            {
                Console.WriteLine(book);
            }
            Console.ReadLine();
        }

        public static void CreateOrUpdateBook(bool Create)
        {
            int id = -1;
            if (!Create) // Update
            {
                Console.WriteLine("Enter the Id of the book you wish to update");
                id = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the title of the new book:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the release year of the new book (ie.: 1973):");
            int releaseYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the genre of the new book:");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter the translator of the new book:");
            string translator = Console.ReadLine();
            Console.WriteLine("Enter the rating of the new book:");
            double rating = double.Parse(Console.ReadLine());

            Book newBook = new()
            {
                Title = title,
                ReleaseYear = releaseYear,
                Genre = genre,
                Translator = translator,
                Rating = rating
            };

            if (Create)
            {
                Program.REST_API.Post(newBook, "book");
            }
            else
            {
                Program.REST_API.Put(newBook, "book");
            }
        }

        public static void DeletePublisher()
        {
            Console.WriteLine("Enter the Id of the entity you wish to delete:");
            int id = int.Parse(Console.ReadLine());
            Program.REST_API.Delete(id, "publisher");
        }

        public static void ReadOnePublisher()
        {
            Console.WriteLine("Enter the Id of the publisher you wish to read:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(Program.REST_API.Get<Publisher>(id, "publisher"));
            Console.ReadLine();
        }

        public static void ReadAllPublisher()
        {
            foreach (var publisher in Program.REST_API.Get<Publisher>("publisher"))
            {
                Console.WriteLine(publisher);
            }
            Console.ReadLine();
        }

        public static void CreateOrUpdatePublisher(bool Create)
        {//a
            int id = -1;
            if (!Create)
            {
                Console.WriteLine("Enter the Id of the publisher you wish to update");
                id = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the name of the new publisher:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the address of the new publisher:");
            string address = Console.ReadLine();
            int numberOfContacts = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the show room capacity of the new cinema:");
            int printingCapacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the ticket price of the new cinema:");
            int publishingPrice = int.Parse(Console.ReadLine());


            Publisher newPublisher = new()
            {
                PublisherName = name,
                Address = address,
                NumberOfContacts = numberOfContacts,
                PrintingCapacity = printingCapacity,
                PublishingPrice = publishingPrice

            };

            if (Create)
            {
                Program.REST_API.Post(newPublisher, "publisher");
            }
            else
            {
                Program.REST_API.Put(newPublisher, "publisher");
            }
        }
    }
}