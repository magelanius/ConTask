using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConTask.Models
{
    public class Project
    {
        [Key]
        [Column(Order = 0)]
        public string Id { get; set; }
        public string BoardId { get; set; }
        public string Description { get; set; }

        public DateTime? StartedAt { get; set; }
        public DateTime? DeadLine { get; set; }


        //
        private enum Priorities { VeryHigh, High, Medium, Low, VeryLow }

        [EnumDataType(typeof(Priorities))]
        private Priorities Priority { get; set; }

        public int PriorityId
        {
            get
            {
                return (int)this.Priority;
            }
            set
            {
                Priority = (Priorities)value;
            }
        }


        //
        private enum Statuses { Done, InProcess, Failed, Stuck }

        [EnumDataType(typeof(Statuses))]
        private Statuses Status { get; set; }

        public int StatusId
        {
            get
            {
                return (int)this.Status;
            }
            set
            {
                Status = (Statuses)value;
            }
        }
    }
}