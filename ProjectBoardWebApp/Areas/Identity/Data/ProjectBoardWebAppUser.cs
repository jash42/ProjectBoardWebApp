using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBoardWebApp.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }

        public string ProfilePic { get; set; } = "01.jpg";

        public string UserFullName { get { return FirstName + " " + LastName; } }

        public int OrgID { get; set; }

        [StringLength(25)]
        public string userLocation { get; set; }
    }
}
