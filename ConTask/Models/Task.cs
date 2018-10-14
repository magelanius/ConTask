using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConTask.Models
{
    public class Task
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }

        public DateTime? PlannedStartAt { get; set; }
        public DateTime? ActualyStartedAt { get; set; }
        public DateTime? DeadLine { get; set; }


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