using Melody.Io;

namespace Melody.Formatting.Implementations
{
    class DefaultFormatter : Formatter
    {
        public bool CanFormat(object value)
        {
            return true;
        }

        public Response Format(object value)
        {
            return new Response(value);
        }
    }
}