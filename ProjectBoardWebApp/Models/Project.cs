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
        public string ProjectName { get; set; }

        [Required]
        [StringLength(500)]
        public string ProjectDesc { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ProjectStartDate { get; set; }

        [StringLength(25)]
        public string ProjectStatus { get; set; }

        [StringLength(450)]
        public string LeaderID { get; set; }

        public int ClientId { get; set; }
    }
}
