using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ProjectBoardWebApp
{
    public class GlobalLists
    {

        public static SelectList StatusValueList()
        {
            SelectList statusValues = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem {Text = "-- Choose Status --", Value = string.Empty},
                    new SelectListItem {Text = "Created", Value = "Created"},
                    new SelectListItem {Text = "Requirements", Value = "Requirements"},
                    new SelectListItem {Text = "Design", Value = "Design"},
                    new SelectListItem {Text = "Development", Value = "Development"},
                    new SelectListItem {Text = "Testing", Value = "Testing"},
                    new SelectListItem {Text = "User Feedback", Value = "User Feedback"},
                    new SelectListItem {Text = "On Hold", Value = "On Hold"},
                    new SelectListItem {Text = "Canceled", Value = "Canceled"},
                    new SelectListItem {Text = "Closed", Value = "Closed"},
                    new SelectListItem {Text = "Completed", Value = "Completed"},
                }, "Value", "Text");

            return statusValues;
        }

    }
}
