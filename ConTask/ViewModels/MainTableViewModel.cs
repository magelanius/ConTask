using ConTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConTask.ViewModels
{
    public class MainTableViewModel
    {
        public List<Board> Boards { get; set; }
        public List<Project> Projects { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
        public List<BoardColumn> BoardColumns { get; set; }
        public List<BoardRow> BoardRows { get; set; }
    }
}