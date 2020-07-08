namespace Melody.Formatting
{
    public interface FormatterContainer
    {
        FormatterContainer Add(Formatter formatter);
        Formatter[] GetFormatters();
    }
}