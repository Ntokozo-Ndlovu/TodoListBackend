
using TodoList.Data.Entities;

namespace TodoList.Data.Repository
{
    public interface ITodoRepository
    {
        public TodoEntity findTodo(Guid todoId);
        public List<TodoEntity> findAll(Guid createId);
        public TodoEntity createTodo(TodoEntity entity);
        public TodoEntity updateTodo(TodoEntity entity);
        public TodoEntity deleteTodo(Guid todoId);
    }
}
