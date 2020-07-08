using Melody.Binding;

namespace Melody.Samples.HelloWorld.App.Greeting
{
    class GreetBinder : Binder<Greet>
    {
        public Greet Bind()
        {
            return new Greet("world");
        }
    }
}