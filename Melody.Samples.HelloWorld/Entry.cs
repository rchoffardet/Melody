using Melody.Routing;
using Melody.Samples.HelloWorld.App.Greeting;

namespace Melody.Samples.HelloWorld
{
    class Entry : Application
    {
        protected override void Configure(Configuration configuration)
        {
            configuration.binders.Add(new GreetBinder());
            configuration.handlers.Add(new GreetHandler());
        }

        protected override void Routes(RouterBuilder app)
        {
            app.Get<Greet, string>("/");
            app.Get<Greet, string>("/hello");
        }

    }
}