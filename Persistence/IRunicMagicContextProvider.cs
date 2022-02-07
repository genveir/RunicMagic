namespace Persistence
{
    internal interface IRunicMagicContextProvider
    {
        RunicMagicDbContext Context { get; }
    }
}