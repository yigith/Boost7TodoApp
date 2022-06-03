using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoListApi.Data;

// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio
namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TodoItemsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<TodoItem> Get()
        {
            return _db.TodoItems.OrderBy(x => x.IsDone).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            TodoItem todoItem = _db.TodoItems.Find(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public ActionResult<TodoItem> Post(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _db.TodoItems.Add(todoItem);
                _db.SaveChanges();
                return todoItem;
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _db.TodoItems.Update(todoItem);
                _db.SaveChanges();
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TodoItem todoItem = _db.TodoItems.Find(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _db.TodoItems.Remove(todoItem);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
