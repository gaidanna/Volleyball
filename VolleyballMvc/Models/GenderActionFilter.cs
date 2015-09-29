using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace VolleyballMvc.Models
{
    public class GenderActionFilter : System.Web.Mvc.ActionFilterAttribute
    {
            // This checks the current langauge code. if there's one missing, it defaults it.
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                const string routeDataKey = "gender";
                const string defaultLanguageCode = "male";
                var validLanguageCodes = new[] { "male", "female" };

                // Determine the language.
                if (filterContext.RouteData.Values[routeDataKey] == null ||
                    !validLanguageCodes.Contains(filterContext.RouteData.Values[routeDataKey]))
                {
                    // Add or overwrite the langauge code value.
                    if (filterContext.RouteData.Values.ContainsKey(routeDataKey))
                    {
                        filterContext.RouteData.Values[routeDataKey] = defaultLanguageCode;
                    }
                    else
                    {
                        filterContext.RouteData.Values.Add(routeDataKey, defaultLanguageCode);
                    }
                }

                base.OnActionExecuting(filterContext);
            }
    }
}