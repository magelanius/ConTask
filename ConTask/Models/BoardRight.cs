using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConTask.Models
{
    public class BoardRight
    {
        public string BoardId { get; set; }
        public string UserId { get; set; }

        private enum Rights { Owner, Member, ProjectManager }

        [EnumDataType(typeof(Rights))]
        private Rights Status { get; set; }

        public int StatusId
        {
            get
            {
                return (int)this.Status;
            }
            set
            {
                Status = (Rights)value;
            }
        }
    }
}