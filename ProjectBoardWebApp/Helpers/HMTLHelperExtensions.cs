using Microsoft.AspNetCore.Mvc.Rendering;
using System;


namespace ProjectBoardWebApp
{
    public static class HtmlHelpers
    {
        public static string isActive(this IHtmlHelper html, string controller = null, string action = null)
        {
            string activeClass = "active"; // change here if you another name to activate sidebar items
            // detect current app state
            string actualAction = (string) html.ViewContext.RouteData.Values["action"];
            string actualController = (string) html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = actualController;

            if (String.IsNullOrEmpty(action))
                action = actualAction;

            return (controller == actualController && action == actualAction) ? activeClass : String.Empty;
        }

        public static string StatusClass(this IHtmlHelper html, string status = null)
        {

            string badgeClass = status switch
            {
                "Created" => "badge-light",
                "Requirements" => "badge-info",
                "Design" => "badge-pink",
                "Development" => "badge-purple",
                "Testing" => "badge-inverse",
                "User Feedback" => "badge-green",
                "On Hold" => "badge-warning",
                "Canceled" => "badge-danger",
                "Closed" => "badge-dark",
                "Completed" => "badge-success",
                _ => "badge-info",
            };
            return badgeClass;
            
        }
    }
}
