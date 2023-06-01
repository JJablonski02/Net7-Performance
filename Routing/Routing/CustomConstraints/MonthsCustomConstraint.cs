﻿using System.Text.RegularExpressions;

namespace Routing.CustomConstraints
{
    public class MonthsCustomConstraint : IRouteConstraint
    {
        //Eg: sales-report/2020/apr
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //check whether the value exists
            if (!values.ContainsKey(routeKey)) //month
            {
                return false; //not a match
            }

            Regex regex = new Regex("^(apr|jul|oct|jan)$");
            string? monthValue = Convert.ToString(values[routeKey]);

            if(regex.IsMatch(monthValue))
            {
                return true; //it's a match
            }
            else
            {
                return false;
            }
        }
    }
}
