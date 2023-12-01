using TodoList.Data.Entities;

namespace TodoList.Data.Repository
{
    public class TodoRepository : ITodoRepository
    {
        //lets create a temp memory to store todos
        public List<TodoEntity> todoList = new List<TodoEntity>();
        TodoDbContext dbContext;
        public TodoRepository()
        {
            dbContext = new TodoDbContext();
        }
        public TodoEntity createTodo(TodoEntity entity)
        {
            var result = this.dbContext.Add(entity).Entity;
            this.dbContext.SaveChanges();
            return result;
        }

        public TodoEntity deleteTodo(Guid todoId)
        {

            var entity = this.dbContext.Todo.FirstOrDefault(todo => todo.Id == todoId); 
            if(entity == null)
            {
                throw new Exception("Not Found");
            }
            var result = this.dbContext.Todo.Remove(entity);
            this.dbContext.SaveChanges();
            return result.Entity;
        }

        public List<TodoEntity> findAll(Guid createdBy)
        {
            List<TodoEntity> result = this.dbContext.Todo.Where(todo => todo.CreatedBy == createdBy).ToList();
            
            return result;
        }

        public TodoEntity findTodo(Guid todoId)
        {
            var entity = this.dbContext.Todo.FirstOrDefault(todo => todo.Id == todoId);
            if(entity == null)
            {
                throw new Exception("NotFound");
            }
            return entity;
        }

        public TodoEntity updateTodo(TodoEntity entity)
        {

            var todoEntity = this.dbContext.Todo.Update(entity);
            this.dbContext.SaveChanges();

            return todoEntity.Entity;
           }
    }
}
