using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CoreLearn.Models
{
    //******************************************************************************
    // Example to Understand Custom Route Constraint in ASP.NET Core MVC
    //******************************************************************************
    public class AlphaNumericConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpcontext, IRouter router, string routeKey, RouteValueDictionary values,RouteDirection routeDirection)
        {
            if(httpcontext == null)
            {
                throw new ArgumentNullException(nameof(httpcontext));
            }
            if(router == null)
            {
                throw new ArgumentNullException(nameof(router));
            }
            if(routeKey == null)
            {
                throw new ArgumentException(nameof(routeKey));
            }
            if(values == null)
            {
                throw new ArgumentException(nameof(values));
            }
            if(values.TryGetValue(routeKey, out object? routeValue))
            {
                var parameterValueString = Convert.ToString(routeValue);
                if(Regex.IsMatch(parameterValueString ?? string.Empty, "^(?=. *[a-zA-z]) (?=.*[0-9])[A-Za-z0-9]+$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}