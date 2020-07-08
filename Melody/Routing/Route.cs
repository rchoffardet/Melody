using Melody.Io;
using System;

namespace Melody.Routing
{
    public class Route
    {
        public readonly string method;
        public readonly string path;
        public readonly Func<Response> handler;

        public Route(string method, string path, Func<Response> handler)
        {
            this.method = method;
            this.path = path;
            this.handler = handler;
        }
    }
}