using Melody.Handling;

namespace Melody.Samples.HelloWorld.App.Greeting
{
    class GreetHandler : Handler<Greet, string>
    {
        public string Handle(Greet query)
        {
            return $"Hello {query.name}!";
        }
    }
}