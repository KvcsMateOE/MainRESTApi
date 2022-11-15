using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCZ6Y1_HFT_2022231.Models;

namespace WCZ6Y1_HFT_2022231.Logic
{
    public interface IMainLogic
    {
        void CreateAuthor(Author entity);
        void CreatePublisher(Publisher entity);
        void CreateBook(Book entity);

        IQueryable<Author> ReadAllAuthor();
        IQueryable<Publisher> ReadAllPublisher();
        IQueryable<Book> ReadAllBook();

        Author ReadAuthor(int Id);
        Publisher ReadPublisher(int Id);
        Book ReadBook(int Id);

        void UpdateAuthor(int oldEntityId, Author entity);
        void UpdatePublisher(int oldEntityId, Publisher entity);
        void UpdateBook(int oldEntityId, Book entity);

        void DeleteAuthor(int Id);
        void DeletePublisher(int Id);
        void DeleteBook(int Id);
    }
}
