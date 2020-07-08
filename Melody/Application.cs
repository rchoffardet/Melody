using Melody.Binding;
using Melody.Formatting;
using Melody.Formatting.Implementations;
using Melody.Handling;
using Melody.Routing;
using Newtonsoft.Json;
using System;
using System.Web;

namespace Melody
{
    public abstract class Application : IHttpModule
    {
        private Router router;

        public void Init(HttpApplication context)
        {
            var handlers = new DefaultHandlerContainer();
            var binders = new DefaultBinderContainer();
            var formatters = new DefaultFormatterContainer();
            formatters.Add(new DefaultFormatter());

            var config = new Configuration(handlers, binders, formatters);
            Configure(config);

            var builder = new RouterBuilder(config);
            Routes(builder);

            router = builder.Build();

            context.BeginRequest += BeginRequest;
        }

        protected abstract void Configure(Configuration configuration);

        protected abstract void Routes(RouterBuilder app);

        private void BeginRequest(object sender, EventArgs args)
        {
            var app = (HttpApplication)sender;
            var context = app.Context;

            var request = context.Request;
            var handler = this.router.Match(request);
            var response = handler();

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(response));
            context.Response.End();
        }

        public void Dispose()
        {
        }
    }
}