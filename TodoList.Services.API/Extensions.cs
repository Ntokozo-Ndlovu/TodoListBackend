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
                StartDate = todo.StartDate,
                EndDate = todo.EndDate,
                Name = todo.Name,
                Description = todo.Description,
                CreatedBy = todo.CreatedBy,
                Id = todo.Id,
                Completed   = todo.Completed
            };
        }
        public static UserDataToObject asUserDTO(this UserEntity user)
        {
            return new UserDataToObject()
            {
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username
            };
        }
    
    }
}
