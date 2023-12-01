namespace TodoList.API.Requests
{
    public class TodoRequest
    {
        public string name { get; set; }
        public string description { get; set; }

        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Boolean completed { get; set; }
    }
}
