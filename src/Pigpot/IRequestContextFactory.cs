namespace Pigpot
{
    public interface IRequestContextFactory
    {
        IRequestContext CreateRequestContext(string path);
        IRequestContext CreateRequestContext(string path, string catalog);
    }
}
