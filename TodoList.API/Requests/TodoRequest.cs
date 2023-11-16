namespace TodoList.API.Requests
{
    public class TodoRequest
    {
        public string name { get; set; }
        public string description { get; set; }

        public DateTimeOffset startDate { get; set; }
        public DateTimeOffset endDate { get; set; }
        public Boolean completed { get; set; }
    }
}
