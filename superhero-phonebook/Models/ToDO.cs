using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class ToDo
    {
        public int id { get; set; }
        public int parentId { get; set; }
        public string note { get; set; }
        public DateTime due { get; set; }
        public ToDo(int id, int parentId, string note, DateTime due)
        {
            this.id = id;
            this.parentId = parentId;
            this.note = note;
            this.due = due;
        }
    }
}
