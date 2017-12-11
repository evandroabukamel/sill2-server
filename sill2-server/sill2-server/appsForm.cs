using System;
using System.Collections;
using System.Threading;
using System.Windows.Forms;

namespace sill2_server
{
    public partial class appsForm : Form
	{
		private string compUser;
		private string user;
		private string comp;

		// Application list thread
		public ArrayList appsList;
		private string selectedApp;
		// private Thread appsBoxThread;
		public delegate void AppsBoxCallback(ListBox lb);

		// Form Constructor
		public appsForm(string compUser)
		{
			InitializeComponent();

			// Shows computer/user label
			this.compUser = compUser;
			string[] logged = compUser.Split('\\');
            comp = logged[0].Trim();
            user = logged[1].Trim();
		}

		private void appsForm_Load(object sender, EventArgs e)
		{
            // Set the comp / user label
            lblCompUser.Text = compUser;

            // Refresh the list box
            appsBoxLoad(appsBox);
		}

		/* Load the users logged from arraylist to a listbox and make it reload */
		public void appsBoxLoad(ListBox lb)
		{
			if (lb.InvokeRequired)
			{
				AppsBoxCallback fbc = new AppsBoxCallback(appsBoxLoad);
                Invoke(fbc, new object[] { lb });
			}
			else
			{
				lb.Items.Clear();

                appsList = new ArrayList();
                appsList = formMain.getApps(comp);

				// Loads the userList to a listbox
				foreach (string app in appsList)
				{
					lb.Items.Add(app.ToString());
					
					//this.gridProcess.Rows.Add(app);
					//this.appsBox.Items.Add(app.ToString());
				}

				lb.Refresh();
				//lb.Update();

				if (lb.FindStringExact(selectedApp) >= 0)
				{
					lb.SelectedIndex = lb.FindStringExact(selectedApp);
				}
			}
		}

		/* Update and refresh the logged user listbox */
		public void appsBoxRefresh()
		{
			while (true)
			{
                appsBoxLoad(appsBox);
				Thread.Sleep(2500);
			}
		}

		/* Saves the value of the appsBox selected item */
		private void loggedBox_SelectedValueChanged(object sender, EventArgs e)
		{
			if (appsBox.SelectedIndex >= 0)
                selectedApp = appsBox.SelectedItem.ToString();
		}

		/* On form closing, abort the thread */
		private void appsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			/*if (this.appsBoxThread.ThreadState == System.Threading.ThreadState.Running)
				this.appsBoxThread.Abort();*/
		}

		/* Refresh the listbox */
		private void btnRefresh_Click(object sender, EventArgs e)
		{
            appsBoxLoad(appsBox);
		}

	}
}