using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;
using TodoList.API.DataToObject;
using TodoList.API.Requests;
using TodoList.API.Responses;
using TodoList.Data.Entities;
using TodoList.Data.Repository;
using TodoList.Domain.JwtAuthorization;

namespace TodoList.Services.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v2/todo")]
    public class TodoController : ControllerBase
    {

        public ITodoRepository todoRepositoryService;

        public IJwtAuthorization jwtAuthorizationService;
        public TodoController(ITodoRepository todoRepository, IJwtAuthorization jwtAuthorizationService)
        {
            this.todoRepositoryService = todoRepository;
            this.jwtAuthorizationService = jwtAuthorizationService;

        }


        [HttpGet("{todoId}")]
        public ActionResult<TodoResponse<TodoDataToObject>> getTodo(Guid todoId)
        {
            var todo = this.todoRepositoryService.findTodo(todoId);
      
            if(todo == null)
            {
                return NotFound();
            }
            TodoResponse<TodoDataToObject> response = new TodoResponse<TodoDataToObject>()
            {
                data = todo.asTodoDTO()
            };

            return response;
        }

        
        [HttpPost("")]
        public ActionResult<TodoResponse<TodoDataToObject>> createTodo([FromHeader]string authorization,[FromBody]TodoRequest todo)
        {

            string token = authorization.Split(" ")[1];
            string userIdString = this.jwtAuthorizationService.DecodeJwtToken(token);
           
            TodoEntity todoEntity = new TodoEntity()
            {
                Id = Guid.NewGuid(),
                name = todo.name,
                description = todo.description,
                startDate = todo.startDate,
                endDate = todo.endDate,
                createdBy = Guid.Parse(userIdString)
            };

            this.todoRepositoryService.createTodo(todoEntity);
            TodoResponse<TodoDataToObject> response = new TodoResponse<TodoDataToObject>()
            {
                data = todoEntity.asTodoDTO()
            };
            return response;
        }

        [HttpGet("")]
        public ActionResult<TodoResponse<List<TodoDataToObject>>> getAllTodoList([FromHeader] string authorization)
        {

            string token = authorization.Split(" ")[1];
            string userIdString = this.jwtAuthorizationService.DecodeJwtToken(token);

            List<TodoDataToObject> responseData = new List<TodoDataToObject>();
            this.todoRepositoryService.findAll(Guid.Parse(userIdString)).ForEach(item => responseData.Add(item.asTodoDTO()));

            TodoResponse<List<TodoDataToObject>> response = new TodoResponse<List<TodoDataToObject>>()
            {
                data = responseData
            };
            return response;
        }

        [HttpDelete("{todoId}")]
        public ActionResult<TodoResponse<TodoDataToObject>> deleteTodo(Guid todoId)
        {
            var todoItem = this.todoRepositoryService.deleteTodo(todoId);
            if(todoItem == null)
            {
                return NotFound();
            }
            TodoResponse<TodoDataToObject> response = new TodoResponse<TodoDataToObject>()
            {
                data = todoItem.asTodoDTO()
            };

            return response;                
        }


        [HttpPatch("{todoId}")]
        public ActionResult<TodoResponse<TodoDataToObject>> updateTodo(Guid todoId,[FromBody] System.Text.Json.Nodes.JsonObject body)
        {   
            TodoRequest todo = JsonSerializer.Deserialize<TodoRequest>(body);
            Console.WriteLine(todo);
            var todoItem = this.todoRepositoryService.findTodo(todoId);
            if(todoItem == null)
            {
                return NotFound();
            }
            if(todo.completed != null)
            {
                todoItem.completed = todo.completed;
            }
            if(todo.name != null)
            {
                todoItem.name = todo.name;
            }
            if(todo.startDate != null)
            {
                todoItem.startDate = todo.startDate;
            }
            if (todo.endDate != null)
            {
                todoItem.endDate = todo.endDate;
            }
            if (todo.description != null)
            {
                todoItem.description = todo.description;
            }

            this.todoRepositoryService.updateTodo(todoItem);

            TodoResponse<TodoDataToObject> response = new TodoResponse<TodoDataToObject>()
            {
                data = todoItem.asTodoDTO()
            };
            return response;
        }
    }
}
