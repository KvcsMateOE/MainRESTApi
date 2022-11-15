using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCZ6Y1_HFT_2022231.Logic
{
    public interface ISideLogic
    {
        IEnumerable<string> ListPublisherByPrintingCapacity();
        IEnumerable<string> GetAllAuthorsByCountry(string country);
        IEnumerable<int> GetAllOldBooks(int yearOfBoomers);
        IEnumerable<ComparedBooks> HackIMDB(int yearOfBoomers);
        IEnumerable<string> GetLastCheapestPublisher();
        IEnumerable<string> GetAllActionBooksWithMoreRatingThan2();
    }
}

