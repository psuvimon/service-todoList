using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReactASPCrud.Models;
using ReactASPCrud.Services;
using MongoDB.Driver;
using System;
using System.Text.Json;

namespace ReactASPCrud.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class TodoListController : ControllerBase
    {
        private readonly ListService _listService;
        public TodoListController(ListService listService)
        {
            _listService = listService;
        }

        public class JsonStringResult : ContentResult
{
        public JsonStringResult(string json)
        {
            Content = json;
            ContentType = "application/json";
        }
}

        // GET api/todoLists
        [HttpGet]
        public List<TodoList> Get()
        {
            return _listService.GetAll();
        }
        // GET api/todoLists/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_listService.GetById(id));
        }
        // POST api/todoLists
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoList list)
        {
            _listService.Create(list);
            return Ok(list);
        }
        // PUT api/todoLists/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TodoList list)
        {
            _listService.Update(id, list);
            return NoContent();
        }
        // DELETE api/todoLists/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lists = _listService.Delete(id);
            return Ok(lists);
        }
        public override NoContentResult NoContent()
        {
            return base.NoContent();
        }
    }
}