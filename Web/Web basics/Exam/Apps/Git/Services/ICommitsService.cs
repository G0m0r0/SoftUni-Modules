using Git.ViewModels.Commits;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        void Create(string description,string creatorId,string repoId);
        IEnumerable<AllCommitViewModel> GetAll();

        void Delete(string id);
    }
}
