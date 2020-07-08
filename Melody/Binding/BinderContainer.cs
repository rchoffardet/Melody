namespace Melody.Binding
{
    public interface BinderContainer
    {
        Binder<ModelType> Get<ModelType>();
        BinderContainer Add<ModelType>(Binder<ModelType> binder);
    }
}