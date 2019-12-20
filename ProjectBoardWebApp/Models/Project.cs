using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBoardWebApp.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Description")]
        public string ProjectDesc { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime ProjectStartDate { get; set; }

        [StringLength(25)]
        [Display(Name = "Status")]
        public string ProjectStatus { get; set; }

        [StringLength(450)]
        public string LeaderID { get; set; }

        public int ClientId { get; set; }

        [Display(Name ="Projected Hours")]
        public decimal HoursProjected { get; set; }

        [Display(Name ="Hours Used")]
        public decimal HoursUsed { get; set; }



    }
}
