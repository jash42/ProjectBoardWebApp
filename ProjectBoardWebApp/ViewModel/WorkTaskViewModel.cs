using ProjectBoardWebApp.Areas.Identity.Data;
using ProjectBoardWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBoardWebApp.ViewModel
{
    public class WorkTaskViewModel
    {
        public Project ProjectVm { get; set; }
        public WorkTask WorkTaskVm { get; set; }
        public ApplicationUser UserVm { get; set; }
    }
}
