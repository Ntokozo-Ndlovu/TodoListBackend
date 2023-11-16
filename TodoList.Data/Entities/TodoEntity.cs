using System.ComponentModel;

namespace TodoList.Data.Entities
{
    public class TodoEntity
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTimeOffset startDate { get; set; }
        public DateTimeOffset endDate { get; set; }
        [DefaultValue(false)]
        public bool completed { get; set; }
        public Guid createdBy { get; set; }
   
    }
}
