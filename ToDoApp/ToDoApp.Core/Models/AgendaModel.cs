using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Core.Models
{
    public class AgendaModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
