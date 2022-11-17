﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WCZ6Y1_HFT_2022231.Logic;

namespace WCZ6Y1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SideController : ControllerBase
    {

        ISideLogic sl;

        public SideController(ISideLogic ql)
        {
            this.sl = ql;
        }

        [HttpGet]
        public IEnumerable<string> ListPublisherByPrintingCapacity()
        {
            return sl.ListPublisherByPrintingCapacity();
        }

        [HttpGet("{country}")]
        public IEnumerable<string> GetAllAuthorsByCountry(string country)
        {
            return sl.GetAllAuthorsByCountry(country);
        }

        [HttpGet("{yearOfBoomers}")]
        public IEnumerable<int> GetAllOldBooks(int yearOfBoomers)
        {
            return sl.GetAllOldBooks(yearOfBoomers);
        }

        [HttpGet("{yearOfBoomers}")]
        public IEnumerable<ComparedBooks> HackIMDB(int yearOfBoomers)
        {
            return sl.HackIMDB(yearOfBoomers);
        }

        [HttpGet]
        public IEnumerable<string> GetLastCheapestPublisher()
        {
            return sl.GetLastCheapestPublisher();
        }

        [HttpGet]
        public IEnumerable<string> GetAllActionBooksWithMoreRatingThan2()
        {
            return sl.GetAllActionBooksWithMoreRatingThan2();
        }

    }
}

