namespace TodoList.API.Responses
{
    public class LoginResponse
    {
        public Guid userId { get; set; }
        public string token { get; set; }
    }
}
