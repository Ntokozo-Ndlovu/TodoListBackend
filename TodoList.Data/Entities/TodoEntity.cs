using System.ComponentModel;

namespace TodoList.Data.Entities
{
    public class TodoEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Completed { get; set; }
        public Guid CreatedBy { get; set; }
   
    }
}
