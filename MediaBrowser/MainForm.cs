using CustomUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBrowser
{
    /// <summary>
    /// Main form class - MDI form to host all others
    /// </summary>
    public partial class MainForm : Form
    {

        Login login = new Login();
        LoginBox loginBox;

        /// <summary>
        /// Open the main MDI Form. Filling the main form with the login form.
        /// </summary>
        public MainForm()
        {

            InitializeComponent();

            // Call the login custom controller
            loginBox = new LoginBox(login);
            login.MdiParent = this;
            login.Anchor = AnchorStyles.None;
            this.ShowIcon = false;
            this.Text = "Media Manager";

            // Add the custom controller on the hosting form window
            login.Controls.Add(loginBox);
            login.Width = loginBox.Width;
            loginBox.Height += 3;
            loginBox.Width += 3;
            login.Left -= 10;
            login.Top -= 40;

            login.Show();
        }

        /// <summary>
        /// Add a menu strip with an option to quit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
