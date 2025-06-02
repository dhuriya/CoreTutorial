using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Primitives;
using System.Configuration;

namespace CoreActionResult.Models
{
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        //Override the IsValidForrequest methdo to provide custom logic for request validation
        // routeContext : Provies information about the current routing for request.
        // actionDescriptor: Provides informatin about the action method
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor actionDescriptor)
        {
            // Check if the request headers are not null and contain X-Requested-With headeer
            if(routeContext.HttpContext.Request.Headers!=null && routeContext.HttpContext.Request.Headers.ContainsKey("X-Requested-With")
                && routeContext.HttpContext.Request.Headers.TryGetValue("X-Requested-With", out StringValues requestdWithHeader))
            {
                // Check if the "X-Requested-With" header contains the value "XMLHttpRequest" indicating an AJAX request
                if(requestdWithHeader.Contains("XMLHttpRequest"))
                {
                    // If the condition is met, return true to indicate the request is valid of AJAX
                    return true;
                }
            }
            // If the condition is not met, return false ot indicate the request is not valid of AJAX
            return false;
        }
    }
}
