using AngularMultiLanguage.Data.Interfaces;

namespace AngularMultiLanguage.Data.Repo
{
    public class RepoWrapper : IRepoWrapper
    {
        private readonly MutltiLanDBContext _dbContext;
        private readonly ICountry? _counryRepo;
        public RepoWrapper(MutltiLanDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public ICountry RepoCountry => _counryRepo??new SQLCountry(_dbContext);

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
