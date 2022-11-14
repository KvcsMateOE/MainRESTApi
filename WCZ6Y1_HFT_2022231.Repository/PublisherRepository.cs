using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCZ6Y1_HFT_2022231.Models;

namespace WCZ6Y1_HFT_2022231.Repository
{
    public class PublisherRepository : Repository<Publisher>
    {
        public PublisherRepository(PublisherDbContext publisherDb) : base(publisherDb)
        {

        }

        public override Publisher ReadOne(int Id)
        {
            return ReadAll().Where(x => x.PublisherId.Equals(Id)).FirstOrDefault();
        }

        public override void Update(Publisher oldEntity, Publisher newEntity)
        {
            if (oldEntity != null && newEntity != null)
            {
                oldEntity.Address = newEntity.Address;
                oldEntity.PublisherName = newEntity.PublisherName;
                oldEntity.NumberOfContacts = newEntity.NumberOfContacts;
                oldEntity.PrintingCapacity = newEntity.PrintingCapacity;
                oldEntity.PublishingPrice = newEntity.PublishingPrice;

                PublisherDb.SaveChanges();
            }
        }
    }
}
