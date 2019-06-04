using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using MediaBrowser;
using ExceptionsManager;

namespace CustomUserControls
{
    /// <summary>
    /// Custom controller for secured login
    /// </summary>
    public partial class LoginBox : UserControl
    {
        IUserManager userManager;
        Login loginForm;

        public LoginBox(Login parent)
        {
            InitializeComponent();

            txtUsername.Focus();
            userManager = new UserManager();

            loginForm = parent;
        }

        /// <summary>
        /// Clears the form inputs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearInputs(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        /// <summary>
        /// Perform login - check user on the DB and get his details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginUser(object sender, EventArgs e)
        {
            this.Enabled = false;
            btnClear.Enabled = false;

            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    ShowErrorMessage("No empty fields are allowed!");
                }
                else if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    UserDTO user = userManager.ValidateUser(txtUsername.Text, txtPassword.Text);
                    if (user != null)
                    {
                        loginForm.PassCredentials(user);

                        this.Dispose();
                    }
                    else
                    {
                        ShowErrorMessage("Wrong details.. please try again");
                        btnClear.Enabled = true;
                        this.Enabled = true;
                    }

                }
            }
            catch (DBConnectionException exp)
            {
                ShowErrorMessage(exp.Message);
                btnClear.Enabled = true;
                this.Enabled = true;
            }
        }

        /// <summary>
        /// Show login status for the user. Remove it after 2.5 seconds.
        /// </summary>
        /// <param name="msg"></param>
        private void ShowErrorMessage(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
                lblWrong.Text = msg;
            lblWrong.Visible = true;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 2500;
            timer.Tick += (source, e) => { lblWrong.Visible = false; timer.Stop(); };
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MediaManager mediaManager = new MediaManager();

            // ALL CRUD OPERATIONS DEMO

            int res;
            DataSet data = mediaManager.QueryMovies();
            res = mediaManager.CreateMovie("tests22", 1, 2, 3, 2019, 5.4m);
            res = mediaManager.UpdateMovie("Title", "another cool update", "Title", "tests22");
            res = mediaManager.DeleteMovie("Title", "update");
            if (data.Tables.Count <= 0)
                throw new Exception("Error fetching data");
        }
    }
}
