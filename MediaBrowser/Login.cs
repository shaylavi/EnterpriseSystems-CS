using BusinessLogic;
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
    /// Form box to host a custom controller - used for login
    /// </summary>
    public partial class Login : Form
    {
        MediaBrowser mBrowser;

        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pass connected user's credentials from custom  controller to other forms.
        /// </summary>
        /// <param name="user"></param>
        public void PassCredentials(UserDTO user) {
            mBrowser = new MediaBrowser(user);

            mBrowser.MdiParent = this.ParentForm;
            mBrowser.Anchor = AnchorStyles.None;
            mBrowser.Text = "Movies Browser";
            mBrowser.ShowIcon = false;

            this.Close();
            mBrowser.Show();

        }
    }
}
