using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitHubExplorer.Controls
{
    public partial class GitHubAuth_Browser : MetroFramework.Forms.MetroForm
    {
        private static string _url;
        public GitHubAuth_Browser(string url)
        {
            _url = url;
            InitializeComponent();
            StartBrowser(_url);
        }

        private void StartBrowser(string url)
        {
            webBrowser1.Url = new Uri(url);
           
        }
    }
}
