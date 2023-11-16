namespace TodoList.API.DataToObject
{
    public class TodoDataToObject
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTimeOffset startDate { get; set; }
        public DateTimeOffset endDate { get; set; }
        public Boolean completed { get; set; }
        public Guid createdBy { get; set; }
    }
}
