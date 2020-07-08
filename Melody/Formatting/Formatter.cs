using Melody.Io;

namespace Melody.Formatting
{
    public interface Formatter
    {
        bool CanFormat(object value);
        Response Format(object value);
    }
}