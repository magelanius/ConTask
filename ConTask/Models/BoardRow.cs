using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConTask.Models
{
    public class BoardRow
    {

        public int Id { get; set; }
        public int ColumnId { get; set; }
        public int TaskId { get; set; }
        public string Content { get; set; }
    }
}