namespace Melody.Handling
{
    public interface Handler<in QueryType, out ResultTpe>
    {
        ResultTpe Handle(QueryType query);
    }
}