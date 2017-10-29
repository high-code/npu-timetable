using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
namespace Timetable.WebApi.Routes
{
    public class ApiV1RoutePrefixAttribute : RoutePrefixAttribute
    {
        private const string RouteBase = "api/{apiVersion:apiVersionConstraint(v1)}";
        private const string PrefixRouteBase = RouteBase + "/";

        public ApiV1RoutePrefixAttribute(string routePrefix) : base(string.IsNullOrWhiteSpace(routePrefix) ? RouteBase : PrefixRouteBase + routePrefix)
        { }
    }
}