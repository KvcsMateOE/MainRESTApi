using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WCZ6Y1_HFT_2022231.Logic;
using WCZ6Y1_HFT_2022231.Models;

namespace WCZ6Y1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        IMainLogic logic;

        public PublisherController(IMainLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Publisher> ReadAll()
        {
            return logic.ReadAllPublisher();
        }

        [HttpGet("{id}")]
        public Publisher Read(int id)
        {
            return logic.ReadPublisher(id);
        }

        [HttpPost]
        public void Create([FromBody] Publisher entity)
        {
            logic.CreatePublisher(entity);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Publisher entity)
        {
            logic.UpdatePublisher(id, entity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.DeletePublisher(id);
        }
    }
}