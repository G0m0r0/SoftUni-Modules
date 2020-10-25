using Git.ViewModels.Repos;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoryService
    {
        void Create(string name, bool repositoryType,string ownerId);
        IEnumerable<RepoViewModel> GetAll();
        string GetNameById(string id);
    }
}
