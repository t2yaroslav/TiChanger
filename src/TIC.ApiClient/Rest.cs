using CF.RESTClientDotNet;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIC.ApiClient.model.Atlassian;

namespace TIC.ApiClient
{
    public class Rest
    {
        #region Fields
        //TODO: Change these values to what you want them to be
        private const string RepoName = "Backup";
        private const string RepoDescription = "Some description";
        private static string username = "t2yaroslav";
        private static string password = "Git2Yaroslav";
        private static RESTClient _bitbucketClient;
        #endregion
        
        #region Methods

        public async Task<Repository> Go()
        {
            GetBitBucketClient(true);

            //Load the repos
            var repos = (await _bitbucketClient.GetAsync<RepositoryList>());

            Console.WriteLine($"Got {repos.values.Count} repos.");

            //Get the repo by name
            var repo = repos.values.FirstOrDefault(r => r.name == RepoName);

            repo.description = RepoDescription;

            var requestUri = $"https://api.bitbucket.org/2.0/repositories/{username}/{repo.full_name.Split('/')[1]}";

            //Save the repo with the new description and get the repo back from Bitbucket
            repo = await _bitbucketClient.PutAsync<Repository, Repository>(repo, requestUri);

            return repo;
            Console.WriteLine($"Saved repo and Bitbucket didn't complain. The description of the repo that came back from Bitbucket was '{repo.description}'.\r\n{(repo.description == RepoDescription ? "Changing the description succeeded." : "Changing the description failed.")}");
        }

        private static void GetBitBucketClient(bool isGet)
        {
            var url = "https://api.bitbucket.org/2.0/repositories/" + username;
            _bitbucketClient = new RESTClient(new NewtonsoftSerializationAdapter(), new Uri(url));

            if (!string.IsNullOrEmpty(password))
            {
                var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password));
                _bitbucketClient.Headers.Add("Authorization", "Basic " + credentials);
            }
        }
        #endregion
    }
}