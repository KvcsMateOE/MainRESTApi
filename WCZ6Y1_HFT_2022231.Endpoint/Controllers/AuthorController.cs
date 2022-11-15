
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
    public class AuthorController : ControllerBase
    {
        IMainLogic logic;

        public AuthorController(IMainLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Author> ReadAll()
        {
            return logic.ReadAllAuthor();
        }

        [HttpGet("{id}")]
        public Author Read(int id)
        {
            return logic.ReadAuthor(id);
        }

        [HttpPost]
        public void Create([FromBody] Author entity)
        {
            logic.CreateAuthor(entity);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Author entity)
        {
            logic.UpdateAuthor(id, entity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.DeleteAuthor(id);
        }
    }
}
