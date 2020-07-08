using System;
using System.Collections.Generic;

namespace Melody.Handling
{
    class DefaultHandlerContainer : HandlerContainer
    {
        private Dictionary<Tuple<Type, Type>, object> handlers = new Dictionary<Tuple<Type, Type>, object>();

        public Handler<QueryType, ResultType> Get<QueryType, ResultType>()
        {
            var key = new Tuple<Type, Type>(typeof(QueryType), typeof(ResultType));
            if (!handlers.ContainsKey(key))
            {
                throw new Exception($"No handler configured for {typeof(QueryType).Name}/{typeof(ResultType).Name}");
            }

            return handlers[key] as Handler<QueryType, ResultType>;
        }

        public HandlerContainer Add<QueryType, ResultType>(Handler<QueryType, ResultType> handler)
        {
            handlers.Add(new Tuple<Type, Type>(typeof(QueryType), typeof(ResultType)), handler);
            return this;
        }
    }
}