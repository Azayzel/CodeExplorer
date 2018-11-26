using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Octokit;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using GitHubExplorer.Utilities;

namespace GitHubExplorer.Controls
{
    public partial class GitHubLogin : MetroFramework.Controls.MetroUserControl
    {
        // Need to move these to env
        private string clientId = "1d050342adb53f492319";
        private string clientSecret = "4e4c9189de54fdd95792d844689acecf7cba2d6a";
        public GitHubClient client;
        private string accesstoken;


        public GitHubLogin()
        {
            InitializeComponent();
            SetInputs();
            client = new GitHubClient(new ProductHeaderValue("CodeExplorer"));
        }

        /// <summary>
        /// Get a random un-used port for re-direct
        /// ** Not using this since Github requires static port in app registration
        /// </summary>
        /// <returns></returns>
        public static int GetRandomUnusedPort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        /// <summary>
        /// Set FontAwesome Icons in inputs
        /// </summary>
        private void SetInputs()
        {

           metroTile1.TileImage = IconChar.GithubSquare.ToBitmap(45, Color.Black);
        }

        /// <summary>
        /// Begin OAuth Web-Browser Workflow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void metroTile1_Click(object sender, EventArgs e)
        {
            string tempURI = string.Format("http://{0}:{1}/", "localhost", 4010);
            Uri redirectURI = new Uri(tempURI);
            var request = new OauthLoginRequest(clientId)
            {
                Scopes = { "user", "notifications", "repo" },
                RedirectUri = redirectURI
            };

            // NOTE: user must be navigated to this URL
            var oauthLoginUrl = client.Oauth.GetGitHubLoginUrl(request);



            // Creates an HttpListener to listen for requests on that redirect URI.
            var http = new HttpListener();
            http.Prefixes.Add(redirectURI.ToString());
            http.Start();

            // Still working on getting a new Browser in-app
            // we can do this with WebView that will instantiate MS Edge but targets .net 4.6.2 and ^
            //GitHubAuth_Browser dialog = new GitHubAuth_Browser(oauthLoginUrl.ToString());
            //dialog.ShowDialog();

            // Start new Tab/ Browser to OAuth Url
            System.Diagnostics.Process.Start(oauthLoginUrl.ToString());



            // Waits for the OAuth authorization response.
            var context = await http.GetContextAsync();
            var response = context.Response;
            string responseString = string.Format("<html><head><meta http-equiv='refresh' content='10;url=https://google.com'></head><body>Please return to the app.</body></html>");

            // Get Response and stop listener
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                http.Stop();
            });

            // extracts the code
            var code = context.Request.QueryString.Get("code");
            var token = await Authorize(code);

            // Got token, now pull repos of user.
            accesstoken = token;

            // Save To HKCU for future use
            SaveTokenToRegistry();


            //Save credentials to github Client
            GitHubClientActions.client.Credentials = new Credentials(token);
        }

        /// <summary>
        /// Get Token from response code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Build OAuth Request URL
        /// </summary>
        /// <returns>OAuthUrl</returns>
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

        /// <summary>
        /// Save OAuth Token to Registry
        /// </summary>
        private void SaveTokenToRegistry()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\GitHubCodeExplorer");
            key.SetValue("Data", accesstoken);
            key.Close();
        }

       
    }
}
