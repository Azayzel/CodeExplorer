namespace GitHubExplorer.Controls
{
    partial class GitHubLogin : MetroFramework.Controls.MetroUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.usernameBox = new MetroFramework.Controls.MetroTextBox();
            this.passwordBox = new MetroFramework.Controls.MetroTextBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(14, 10);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(130, 20);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "UserName or Email";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(14, 65);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 20);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Password";
            // 
            // usernameBox
            // 
            // 
            // 
            // 
            this.usernameBox.CustomButton.Image = null;
            this.usernameBox.CustomButton.Location = new System.Drawing.Point(237, 1);
            this.usernameBox.CustomButton.Name = "";
            this.usernameBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.usernameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.usernameBox.CustomButton.TabIndex = 1;
            this.usernameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.usernameBox.CustomButton.UseSelectable = true;
            this.usernameBox.Lines = new string[0];
            this.usernameBox.Location = new System.Drawing.Point(14, 33);
            this.usernameBox.MaxLength = 32767;
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.PasswordChar = '\0';
            this.usernameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernameBox.SelectedText = "";
            this.usernameBox.SelectionLength = 0;
            this.usernameBox.SelectionStart = 0;
            this.usernameBox.ShortcutsEnabled = true;
            this.usernameBox.ShowButton = true;
            this.usernameBox.Size = new System.Drawing.Size(259, 23);
            this.usernameBox.TabIndex = 3;
            this.usernameBox.UseSelectable = true;
            this.usernameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.usernameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // passwordBox
            // 
            // 
            // 
            // 
            this.passwordBox.CustomButton.Image = null;
            this.passwordBox.CustomButton.Location = new System.Drawing.Point(237, 1);
            this.passwordBox.CustomButton.Name = "";
            this.passwordBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordBox.CustomButton.TabIndex = 1;
            this.passwordBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordBox.CustomButton.UseSelectable = true;
            this.passwordBox.Lines = new string[0];
            this.passwordBox.Location = new System.Drawing.Point(14, 86);
            this.passwordBox.MaxLength = 32767;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '●';
            this.passwordBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordBox.SelectedText = "";
            this.passwordBox.SelectionLength = 0;
            this.passwordBox.SelectionStart = 0;
            this.passwordBox.ShortcutsEnabled = true;
            this.passwordBox.ShowButton = true;
            this.passwordBox.Size = new System.Drawing.Size(259, 23);
            this.passwordBox.TabIndex = 4;
            this.passwordBox.UseSelectable = true;
            this.passwordBox.UseSystemPasswordChar = true;
            this.passwordBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // iconButton1
            // 
            this.iconButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Github;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconSize = 30;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.Location = new System.Drawing.Point(80, 121);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(15);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Rotation = 0D;
            this.iconButton1.Size = new System.Drawing.Size(123, 36);
            this.iconButton1.TabIndex = 5;
            this.iconButton1.Text = "Login";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // GitHubLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "GitHubLogin";
            this.Size = new System.Drawing.Size(302, 176);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox usernameBox;
        private MetroFramework.Controls.MetroTextBox passwordBox;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}
