using Melody.Binding;
using Melody.Formatting;
using Melody.Handling;
using Melody.Io;
using System;
using System.Collections.Generic;

namespace Melody.Routing
{
    public class RouterBuilder
    {
        private readonly BinderContainer bindings;
        private readonly HandlerContainer handlers;
        private readonly Formatter formatter;
        private readonly List<Route> routes = new List<Route>();

        public RouterBuilder(Configuration configuration)
        {
            this.bindings = configuration.binders;
            this.handlers = configuration.handlers;
            this.formatter = new CompositeFormatter(configuration.formatters);
        }

        public void Get(string path, Func<Response> handler)
        {
            routes.Add(new Route("GET", path, handler));
        }

        public void Get<QueryType, ResultType>(string path)
        {
            Get(path, () =>
            {
                var binder = bindings.Get<QueryType>();
                var query = binder.Bind();

                var handler = handlers.Get<QueryType, ResultType>();
                var content = handler.Handle(query);

                return formatter.Format(content);
            });
        }

        public Router Build()
        {
            return new Router(routes.ToArray());
        }

    }
}