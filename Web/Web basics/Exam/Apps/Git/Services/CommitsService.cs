using Git.Data;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string description, string creatorId, string repoId)
        {
            var commit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,                
                CreatorId = creatorId,
                RepositoryId = repoId,
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var commit = this.db.Commits.Find(id);
            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }

        public IEnumerable<AllCommitViewModel> GetAll()
        {
            var commits = this.db.Commits.Select(x => new AllCommitViewModel {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Description = x.Description,
                RepoName = x.Repository.Name,
            }).ToList();

            return commits;
        }
    }
}
