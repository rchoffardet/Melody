namespace Melody.Binding
{
    public interface Binder<out ModelType>
    {
        ModelType Bind();
    }
}