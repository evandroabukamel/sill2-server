using System;
using System.Windows.Forms;

namespace sill2_server
{
    public partial class Auth : Form
	{
		private string user;
		private string pass;

		public Auth()
		{
			InitializeComponent();
		}

		/* Sets user and password */
		private void btnAuth_Click(object sender, EventArgs e)
		{
            user = txtUser.Text;
            pass = txtPass.Text;
			Auth.ActiveForm.Close();
		}

		public string getUser()
		{
			return user;
		}

		public string getPass()
		{
			return pass;
		}
	}
}