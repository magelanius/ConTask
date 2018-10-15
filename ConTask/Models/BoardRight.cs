using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConTask.Models
{
    public class BoardRight
    {
        [Key]
        [Column(Order = 0)]
        public string Id { get; set; }
        public string BoardId { get; set; }
        public string MemberId { get; set; }
        
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