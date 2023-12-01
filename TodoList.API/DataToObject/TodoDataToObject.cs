namespace TodoList.API.DataToObject
{
    public class TodoDataToObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean Completed { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
