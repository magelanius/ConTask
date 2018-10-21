using ConTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConTask.ViewModels
{
    public class BoardFormViewModel
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public BoardFormViewModel()
        {
            Id = 0;
            //Guid.NewGuid().ToString()
        }

        public BoardFormViewModel(Board board)
        {
            Id = board.Id;
            Name = board.Name;
        }
    }
}