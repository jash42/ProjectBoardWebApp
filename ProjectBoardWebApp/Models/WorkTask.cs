using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectBoardWebApp.Models
{
    public class WorkTask
    {
        [Key]
        public int TaskID { get; set; }

        [Display(Name = "Project Name")]
        public int ProjectID { get; set; }

        [Display(Name = "Parent Task")]
        public int? ParentTask { get; set; } = 0;

        [Display(Name = "Assign To Team")]
        public int? TeamID { get; set; } = 0;

        [Display(Name = "Assign To User")]
        public string AssignedID { get; set; }

        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Display(Name = "Task Description")]
        public string TaskDesc { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime? DateCreated { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime? DateStarted { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Complete")]
        public DateTime? DateCompleted { get; set; }

        [Display(Name = "Estimated Hours")]
        public float? HoursEstimated { get; set; }

        [Display(Name = "Hours Used")]
        public float? HoursUsed { get; set; }


    }
}
