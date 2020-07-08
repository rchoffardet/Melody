using System.Collections.Generic;

namespace Melody.Formatting
{
    class DefaultFormatterContainer : FormatterContainer
    {
        private readonly List<Formatter> formatters = new List<Formatter>();

        public FormatterContainer Add(Formatter formatter)
        {
            formatters.Add(formatter);
            return this;
        }

        public Formatter[] GetFormatters()
        {
            return formatters.ToArray();
        }
    }
}