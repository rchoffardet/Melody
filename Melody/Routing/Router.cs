using Melody.Io;
using System;
using System.Linq;
using System.Web;

namespace Melody.Routing
{
    public class Router
    {
        private readonly Route[] routes;

        public Router(Route[] routes)
        {
            this.routes = routes;
        }

        public Func<Response> Match(HttpRequest request)
        {
            var route = routes.FirstOrDefault(x =>
                x.method == request.HttpMethod
                && x.path == request.Path
            );

            if (route == null)
            {
                throw new Exception($"No route configure for {request.HttpMethod} {request.Path}");
            }

            return route.handler;
        }
    }
}