using System;
using System.Collections.Generic;

namespace Melody.Binding
{
    class DefaultBinderContainer : BinderContainer
    {
        private Dictionary<Type, object> binders = new Dictionary<Type, object>();

        public Binder<ModelType> Get<ModelType>()
        {
            var key = typeof(ModelType);
            if (!binders.ContainsKey(key))
            {
                throw new Exception($"No binder configured for {typeof(ModelType).Name}");
            }

            return binders[key] as Binder<ModelType>;
        }

        public BinderContainer Add<ModelType>(Binder<ModelType> binder)
        {
            binders.Add(typeof(ModelType), binder);
            return this;
        }
    }
}