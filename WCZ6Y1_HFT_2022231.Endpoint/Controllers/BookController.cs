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
    public class BookController : ControllerBase
    {
        IMainLogic logic;

        public BookController(IMainLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Book> ReadAll()
        {
            return logic.ReadAllBook();
        }

        [HttpGet("{id}")]
        public Book Read(int id)
        {
            return logic.ReadBook(id);
        }

        [HttpPost]
        public void Create([FromBody] Book entity)
        {
            logic.CreateBook(entity);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Book entity)
        {
            logic.UpdateBook(id, entity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.DeleteBook(id);
        }
    }
}
