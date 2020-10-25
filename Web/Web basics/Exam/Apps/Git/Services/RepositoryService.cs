using Git.Data;
using Git.ViewModels.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext db;

        public RepositoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string name, bool repositoryType,string ownerId)
        {
            var repository = new Repository
            {
                Name = name,
                CreatedOn = DateTime.Now,
                IsPublic = repositoryType,
                OwnerId = ownerId,
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepoViewModel> GetAll()
        {
            var repos = this.db.Repositories.Select(x => new RepoViewModel
            {
                RepoId=x.Id,
                RepoName = x.Name,
                CreatorName = x.Owner.Username,
                DateTime = x.CreatedOn,
                CommitsCount = x.Commits.Count(),
                IsPublic=x.IsPublic,
            }).ToList();


            return repos;
        }

        public string GetNameById(string id)
        {
            return this.db.Repositories
                .Where(x => x.Id==id)
                .Select(x => x.Name)
                .FirstOrDefault();
        }
    }
}
