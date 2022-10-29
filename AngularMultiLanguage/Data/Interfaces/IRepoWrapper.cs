namespace AngularMultiLanguage.Data.Interfaces
{
    public interface IRepoWrapper
    {
        ICountry RepoCountry { get; }
        Task<int> CommitAsync();
    }
}
