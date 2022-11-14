using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCZ6Y1_HFT_2022231.Models;

namespace WCZ6Y1_HFT_2022231.Repository
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(PublisherDbContext publisherDb) : base(publisherDb)
        {
        }

        public override Author ReadOne(int Id)
        {
            return ReadAll().Where(x => x.AuthorId.Equals(Id)).FirstOrDefault();
        }

        public override void Update(Author oldEntity, Author newEntity)
        {
            if (oldEntity != null && newEntity != null)
            {
                oldEntity.BirthYear = newEntity.BirthYear;
                oldEntity.HomeCountry = newEntity.HomeCountry;
                oldEntity.Gender = newEntity.Gender;
                oldEntity.Name = newEntity.Name;
                PublisherDb.SaveChanges();
            }
        }
        public int BirthYearFilter(int birthyear)
        {
            return ReadAll().Where(x => x.BirthYear > birthyear).Count();
        }
    }
}
