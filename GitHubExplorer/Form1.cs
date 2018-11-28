using DAL.Models;
using GitHubExplorer.Utilities;
using Microsoft.Win32;
using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitHubExplorer
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        
        public string token;
        public Form1()
        {
            InitializeComponent();

            metroTabControl1.SelectedIndexChanged += new EventHandler(checkIndex);
            
        }

        private async void GetRepos()
        {
            IReadOnlyList<Repository> repos = await GitHubClientActions.GetUserRepos();
            foreach (var repo in repos)
            {
                Console.WriteLine("Checking repo: " + repo.FullName);
            }
        }

        private void checkIndex(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    // Do nothing, this is main page
                    break;
                case 1:
                    // Search Github Page
                    break;
                case 2:
                    // Company Hub

                    // Get customers to fill Grid
                    gridPanel.Visible = true;
                    List<CustomerAndOrder> custAndOrders = DbActions.GetPreviousOrders("30");
                    orderInfoGrid.DataSource = custAndOrders;

                    break;
            }
        }


        

        /// <summary>
        /// OnLoad Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            bool haveKey = GitHubClientActions.CheckForToken();
            Console.WriteLine("Have key?: " + haveKey);
            if (haveKey)
            {
                gitHubLogin1.Visible = false;
                GetRepos();
            }
        }
    }
}
