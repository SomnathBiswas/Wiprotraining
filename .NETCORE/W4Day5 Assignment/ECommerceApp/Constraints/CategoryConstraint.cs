using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace ECommerceApp.Constraints
{
    public class CategoryConstraint : IRouteConstraint
    {
        private static readonly HashSet<string> ValidCategories =
            new HashSet<string> { "electronics", "clothing", "books" };

        public bool Match(HttpContext httpContext, IRouter route,
                          string parameterName, RouteValueDictionary values,
                          RouteDirection routeDirection)
        {
            if (!values.ContainsKey(parameterName))
                return false;

            var value = values[parameterName]?.ToString()?.ToLower();
            return !string.IsNullOrEmpty(value) && ValidCategories.Contains(value);
        }
    }
}
