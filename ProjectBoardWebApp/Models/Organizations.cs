using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBoardWebApp.Models
{
    public class Organizations
    {
        [Key]
        public int OrgID { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Organization Name")]
        public string OrgName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string OrgAddress { get; set; }

        [StringLength(100)]
        [Display(Name = "Address 2")]
        public string OrgAddress2 { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "City")]
        public string OrgCity { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "State")]
        public string OrgState { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Zip Code")]
        public string OrgZip { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(30)]
        [Display(Name = "Phone")]
        public string OrgPhone { get; set; }

        [StringLength(250)]
        [Display(Name = "Website")]
        public string OrgWebsite { get; set; }

        [StringLength(450)]
        [Display(Name = "Main Contact")]
        public string MainContact { get; set; }

        [StringLength(250)]
        [Display(Name = "Staging Site")]
        public string StagingUrl { get; set; }

    }
}
