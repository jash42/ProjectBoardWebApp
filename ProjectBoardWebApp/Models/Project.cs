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
        [Display(Name = "Short Description")]
        [DataType(DataType.MultilineText)]
        public string ProjectDesc { get; set; }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Full Description")]
        public string ProjectLongDesc { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime ProjectStartDate { get; set; }

        [StringLength(25)]
        [Display(Name = "Status")]
        public string ProjectStatus { get; set; }

        [StringLength(450)]
        [Display(Name = "Project Lead")]
        public string LeaderID { get; set; }

        [Required]
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Display(Name ="Projected Hours")]
        public decimal HoursProjected { get; set; }

        [Display(Name ="Hours Used")]
        public decimal HoursUsed { get; set; }

        public string PercentComplete { get { return Decimal.Round(((HoursUsed / HoursProjected) * 100),0).ToString(); } }

    }
}
