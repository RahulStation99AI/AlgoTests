namespace Alogs
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /*
     * Problem Description:
     * 
     * We want to implement a middleware router for our web service, which based on the path returns different strings (these would represent “functions to invoke” in a real application).
     * 
     * Our interface for the router looks something like:
     * 
     * Router.addRoute("/bar", "result")
     * Router.callRoute("/bar") -> "result"
     * 
     * interface Router {
     *   fun addRoute(path: String, result: String) : Unit;
     *   fun callRoute(path: String) : String;
     * }
     * Usage:
     * Router.addRoute("/bar", "result")
     * 
     * Scale up 1: Wildcard Matching Paths
     * 
     * Extend the route declarations such that we can have wildcards in the paths.
     * 
     * Router router = Router()
     * router.addRoute("/foo", "foo")
     * router.addRoute("/bar/baz", "bar")
     */

    public class AtlassianCoding
    {
        /*
            Desription: 
            Map<string, string>
            Add =-> Check and Add or Update.
            Call -> Lookup the Map and return result.

            Steps:

            Edge Case:

            Error Handling:
        */

        private readonly Dictionary<string, string> MapDict = new Dictionary<string, string>();

        public uint AddRoute(string route, string result)
        {
            if (string.IsNullOrEmpty(route))
            {
                throw new ArgumentNullException($"Invalid Argument: {route}");
            }

            if (string.IsNullOrEmpty(result))
            {
                throw new ArgumentNullException($"Invalid Argument {result}");
            }

            if (!MapDict.ContainsKey(route))
            {
                MapDict.Add(route, result);
            }
            else
            {
                MapDict[route] = result;
            }

            return (uint)MapDict.Count;
        }

        public string CallRoute(string route)
        {
            if (string.IsNullOrEmpty(route))
            {
                throw new ArgumentNullException($"Invalid Argument: {route}");
            }

            var routes = route.Split("/");

            if (!MapDict.ContainsKey(route))
            {
                throw new InvalidOperationException($"{route} route doesn't exist");
            }

            foreach (var r in MapDict)
            {
                var regEx = r.Key;
                var target = r.Key.Split("/");

                if (regEx.Contains("*")) // If regEx match needed.
                {
                    // Convert wildcard pattern to regex pattern
                    var pattern = "^" + Regex.Escape(regEx).Replace("\\*", "[^/]+") + "$";
                    var reg = new Regex(pattern);

                    if (reg.IsMatch(route))
                    {
                        return r.Value;
                    }
                }
                else
                {
                    if (routes[0] == target[0])
                    {
                        return r.Value;
                    }

                    if (r.Key == route)
                    {
                        return r.Value;
                    }
                }
            }

            return MapDict[route];
        }

        public static void Test()
        {
            string result = "Result";
            AtlassianCoding test = new AtlassianCoding();
            test.AddRoute("/bar", result);

            var res = test.CallRoute("/bar");
            if (res != result)
            {
                Console.WriteLine($"expected: {result}, Got: {res}");
            }

            try
            {
                test.AddRoute("", "result"); //  Error case
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                test.AddRoute("/bar", ""); // error case
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                test.AddRoute("", ""); // error case
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}