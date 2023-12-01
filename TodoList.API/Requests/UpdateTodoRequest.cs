using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.API.Requests
{
    public class UpdateTodoRequest
    {
        public bool? completed { get; set; }
        public string? name { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string? description { get; set; }
    }
}
