using System;
using System.Linq;
using Melody.Io;

namespace Melody.Formatting
{
    class CompositeFormatter : Formatter
    {
        private readonly Formatter[] formatters;

        public CompositeFormatter(FormatterContainer container)
        {
            formatters = container.GetFormatters();
        }

        public bool CanFormat(object value)
        {
            return formatters.Any(x => x.CanFormat(value));
        }

        public Response Format(object value)
        {
            var formatter = formatters.FirstOrDefault(x => x.CanFormat(value));
            if (formatter == null)
            {
                throw new Exception($"No formatter configured for {value.GetType().Name}");
            }

            return formatter.Format(value);
        }
    }
}