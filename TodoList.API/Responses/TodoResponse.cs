using TodoList.API.DataToObject;

namespace TodoList.API.Responses
{
    public class TodoResponse<T>
    {
        public T data { get; set; }  
    }
}
