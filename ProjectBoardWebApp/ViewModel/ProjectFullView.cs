using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectBoardWebApp.Models;

namespace ProjectBoardWebApp.ViewModel
{
    public class ProjectFullView
    {
        public Project projectVm { get; set; }
        public Organizations orgVm { get; set; }
    }
}
