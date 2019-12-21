using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectBoardWebApp.Models;
using ProjectBoardWebApp.Areas.Identity.Data;

namespace ProjectBoardWebApp.ViewModel
{
    public class ProjectFullView
    {
        public Project ProjectVm { get; set; }
        public Organizations OrgVm { get; set; }
        public ApplicationUser UserVm { get; set; }
    }
}
