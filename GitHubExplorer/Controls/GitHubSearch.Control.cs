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
using GitHubExplorer.Utilities;
using Octokit;
using GitHubExplorer.Models;

namespace GitHubExplorer.Controls
{
    public partial class GitHubSearch : UserControl
    {
        SearchRepositoryResult searchResults;
        List<SearchResultGrid> gridData = new List<SearchResultGrid>();
        private string[] searchTypes = { "User", "Repository" };
        public GitHubSearch()
        {
            InitializeComponent();
            searchBox.CustomButton.Image = IconChar.Search.ToBitmap(15, Color.Black);
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            var term = searchBox.Text;
            var results = await GitHubClientActions.SearchGitHub(term);
            searchResults = results;
            foreach(var res in searchResults.Items)
            {
                SearchResultGrid result = new SearchResultGrid { FullName = res.FullName, URL = res.Url, Stars = res.StargazersCount.ToString(), Language = res.Language, OpenIssues = res.OpenIssuesCount.ToString() };
                gridData.Add(result);
            }
            resultsGrid.DataSource = gridData;
        }
    }
}
