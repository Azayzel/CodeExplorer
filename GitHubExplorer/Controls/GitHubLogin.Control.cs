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

namespace GitHubExplorer.Controls
{
    public partial class GitHubLogin : MetroFramework.Controls.MetroUserControl
    {
        public GitHubLogin()
        {
            InitializeComponent();
            SetInputs();
        }

        private void SetInputs()
        {
            // Login Button Icon
            loginButton.Image = IconChar.GithubAlt.ToBitmap(30, Color.Black);
            loginButton.ImageAlign = ContentAlignment.MiddleLeft;

            // UserName Icon in Input
            usernameBox.CustomButton.Image = IconChar.User.ToBitmap(15, Color.Black);

            // Password Box Icon in Input
            passwordBox.CustomButton.Image = IconChar.Lock.ToBitmap(15, Color.Black);
        }

    }
}
