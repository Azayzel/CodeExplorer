using Microsoft.Win32;
using Octokit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Utilities
{
    public class GitHubClientActions
    {
        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "Software\\GitHubCodeExplorer";
        const string keyName = userRoot + "\\" + subkey;


        private string clientId = "1d050342adb53f492319";
        private string clientSecret = "4e4c9189de54fdd95792d844689acecf7cba2d6a";
        public static GitHubClient client = new GitHubClient(new ProductHeaderValue("CodeExplorer"));
        private static string accessToken;


        public static bool CheckForToken()
        {
            var data = (string)Registry.GetValue(keyName, "Data", null);
            Console.WriteLine(data);
            if (data != null && data.Length > 0)
            {
                accessToken = data.ToString();
                client.Credentials = new Credentials(accessToken);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> Authorize(string code)
        {
            if (!String.IsNullOrEmpty(code))
            {
                var token = await client.Oauth.CreateAccessToken(
                    new OauthTokenRequest(clientId, clientSecret, code));
                return token.AccessToken;
            }
            return "Could Not Get Token";
        }

        private string GetOauthLoginUrl()
        {

            // 1. Redirect users to request GitHub access
            var request = new OauthLoginRequest(clientId)
            {
                Scopes = { "user", "notifications" }
            };
            var oauthLoginUrl = client.Oauth.GetGitHubLoginUrl(request);
            Console.WriteLine(oauthLoginUrl);
            Debug.WriteLine(oauthLoginUrl);
            return oauthLoginUrl.ToString();
        }

       
        public static async Task<SearchRepositoryResult> SearchGitHub(string term)
        {
            SearchRepositoriesRequest srch = new SearchRepositoriesRequest();
            srch.User = term;
            var results = await client.Search.SearchRepo(srch);
            return results;
        }
        public static async Task<IReadOnlyList<Repository>> GetUserRepos()
        {
            return await client.Repository.GetAllForCurrent();
        }
    }
}
