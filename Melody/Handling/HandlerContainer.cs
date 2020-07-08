namespace Melody.Handling
{
    public interface HandlerContainer
    {
        Handler<QueryType, ResultType> Get<QueryType, ResultType>();
        HandlerContainer Add<QueryType, ResultType>(Handler<QueryType, ResultType> handler);
    }
}