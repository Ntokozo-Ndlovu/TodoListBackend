using TodoList.API.DataToObject;
using TodoList.Data.Entities;

namespace TodoList.Services.API
{
    public static class Extensions
    {
        public static TodoDataToObject asTodoDTO(this TodoEntity todo)
        {
            return new TodoDataToObject()
            {
                startDate = todo.startDate,
                endDate = todo.endDate,
                name = todo.name,
                description = todo.description,
                createdBy = todo.createdBy,
                id = todo.Id,
                completed   = todo.completed
            };
        }
        public static UserDataToObject asUserDTO(this UserEntity user)
        {
            return new UserDataToObject()
            {
                email = user.email,
                name = user.name,
                surname = user.surname,
                username = user.username
            };
        }
    
    }
}
