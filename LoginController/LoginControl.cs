using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginController
{
    public partial class LoginControl : Control
    {
        public LoginControl()
        {
            //InitializeComponent();
        }

        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    base.OnPaint(pe);
        //}

        public bool ValidateUser(string username, string password)
        {
            // call the model
            // return the result
            throw new NotImplementedException();
        }

        public bool RegisterNewUser(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
