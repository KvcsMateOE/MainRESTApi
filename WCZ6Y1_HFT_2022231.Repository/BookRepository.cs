using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCZ6Y1_HFT_2022231.Models;

namespace WCZ6Y1_HFT_2022231.Repository
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(PublisherDbContext publisherDb) : base(publisherDb)
        {
        }

        public override Book ReadOne(int Id)
        {
            return ReadAll().Where(x => x.BookId.Equals(Id)).FirstOrDefault();
        }

        public override void Update(Book oldEntity, Book newEntity)
        {
            if (oldEntity != null && newEntity != null)
            {
                oldEntity.ReleaseYear = newEntity.ReleaseYear;
                oldEntity.Rating = newEntity.Rating;
                oldEntity.Genre = newEntity.Genre;
                oldEntity.Translator = newEntity.Translator;
                oldEntity.Title = newEntity.Title;
                PublisherDb.SaveChanges();
            }
        }
    }
}