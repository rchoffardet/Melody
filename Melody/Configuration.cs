using Melody.Binding;
using Melody.Formatting;
using Melody.Handling;

namespace Melody
{
    public class Configuration
    {
        public readonly HandlerContainer handlers;
        public readonly BinderContainer binders;
        public readonly FormatterContainer formatters;

        public Configuration(HandlerContainer handlers, BinderContainer binders, FormatterContainer formatters)
        {
            this.handlers = handlers;
            this.binders = binders;
            this.formatters = formatters;
        }
    }
}