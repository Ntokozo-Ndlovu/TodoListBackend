using TodoList.Data.Entities;

namespace TodoList.Data.Repository
{
    public class TodoRepository : ITodoRepository
    {
        //lets create a temp memory to store todos
        public List<TodoEntity> todoList = new List<TodoEntity>();
        public TodoEntity createTodo(TodoEntity entity)
        {
            this.todoList.Add(entity);
            return entity;
        }

        public TodoEntity deleteTodo(Guid todoId)
        {
            var index = this.todoList.FindIndex(todo => todo.Id == todoId);
            if (index == -1)
                return null;
            var entity = this.todoList[index];
            this.todoList.RemoveAt(index);
            return entity;
        }

        public List<TodoEntity> findAll(Guid createdBy)
        {
            return this.todoList.FindAll(todo => todo.createdBy.Equals(createdBy));
        }

        public TodoEntity findTodo(Guid todoId)
        {
            var entity = this.todoList.Find(todo => todo.Id == todoId);
            
            return entity;
        }

        public TodoEntity updateTodo(TodoEntity entity)
        {
            var updateTodoIndex = this.todoList.FindIndex(todoList => todoList.Id == entity.Id);
            if(updateTodoIndex != -1)
            {
                this.todoList[updateTodoIndex] = entity;

            }
            return entity;
           }
    }
}
