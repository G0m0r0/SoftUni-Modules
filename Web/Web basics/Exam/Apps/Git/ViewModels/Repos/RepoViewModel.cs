using System;

namespace Git.ViewModels.Repos
{
    public class RepoViewModel
    {
        public string RepoId { get; set; }
        public string RepoName { get; set; }
        public string CreatorName { get; set; }
        public DateTime DateTime { get; set; }
        public int CommitsCount { get; set; }
        public bool IsPublic { get; set; }
    }
}
