using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConTask.Models
{
    public class BoardColumn
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public string Name { get; set; }

        private enum Types { Text, Date}

        [EnumDataType(typeof(Types))]
        private Types Type { get; set; }

        public int StatusId
        {
            get
            {
                return (int)this.Type;
            }
            set
            {
                Type = (Types)value;
            }
        }
    }
}