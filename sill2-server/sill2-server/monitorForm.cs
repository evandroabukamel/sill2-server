using System;
using System.Collections;
using System.Windows.Forms;
using System.Threading;

namespace sill2_server
{
    public partial class monitorForm : Form
	{
		// Monitors array
		public struct Monitor
		{
			public ListBox lb;
			public TextBox tbx;
			public string selected;
		}
		private Monitor[] monitors;
		
		// List of logged and free users
		private ArrayList mainList;

		// Threads
		private Thread[] loggedBoxThreads;
		public delegate void LoggedBoxCallback(ListBox lb, TextBox tbx, string slt);
		
		public monitorForm()
		{
			InitializeComponent();

            // Bind the userList from the main form
            mainList = formMain.mainList;
		}

		/* Puts a thread to automaticaly load the listboxes */
		private void monitorForm_Load(object sender, EventArgs e)
		{
			// Creates and starts the thread for refresh the loggedBox
			try
			{
                // Fill the array of monitors
                monitors = new Monitor[10];
                monitors[0].lb = loggedBox1;
                monitors[0].tbx = txtFilter1;
                monitors[1].lb = loggedBox2;
                monitors[1].tbx = txtFilter2;
                monitors[2].lb = loggedBox3;
                monitors[2].tbx = txtFilter3;
                monitors[3].lb = loggedBox4;
                monitors[3].tbx = txtFilter4;
                monitors[4].lb = loggedBox5;
                monitors[4].tbx = txtFilter5;
                monitors[5].lb = loggedBox6;
                monitors[5].tbx = txtFilter6;
                monitors[6].lb = loggedBox7;
                monitors[6].tbx = txtFilter7;
                monitors[7].lb = loggedBox8;
                monitors[7].tbx = txtFilter8;
                monitors[8].lb = loggedBox9;
                monitors[8].tbx = txtFilter9;
                monitors[9].lb = loggedBox10;
                monitors[9].tbx = txtFilter10;

                // Create and start the threads
                loggedBoxThreads = new Thread[monitors.Length];
				for (int t = 0; t < monitors.Length; t++)
				{
                    loggedBoxThreads[t] = new Thread(new ParameterizedThreadStart(loggedBoxRefresh));
                    loggedBoxThreads[t].Start(monitors[t]);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
			}

            // Creates the double click handler for the loggedBoxes
            loggedBox1.MouseDoubleClick += new MouseEventHandler(loggedBox_MouseDoubleClick);
            loggedBox2.MouseDoubleClick += new MouseEventHandler(loggedBox_MouseDoubleClick);
            loggedBox3.MouseDoubleClick += new MouseEventHandler(loggedBox_MouseDoubleClick);
            loggedBox4.MouseDoubleClick += new MouseEventHandler(loggedBox_MouseDoubleClick);
            loggedBox5.MouseDoubleClick += new MouseEventHandler(loggedBox_MouseDoubleClick);
            loggedBox6.MouseDoubleClick += new MouseEventHandler(loggedBox_MouseDoubleClick);
            loggedBox7.MouseDoubleClick += new MouseEventHandler(loggedBox_MouseDoubleClick);
            loggedBox8.MouseDoubleClick += new MouseEventHandler(loggedBox_MouseDoubleClick);
            loggedBox9.MouseDoubleClick += new MouseEventHandler(loggedBox_MouseDoubleClick);
            loggedBox10.MouseDoubleClick += new MouseEventHandler(loggedBox_MouseDoubleClick);
		}

		/* Update and refresh the logged user listbox */
		public void loggedBoxRefresh(object objMon)
		{
			Monitor monitor = (Monitor)objMon;
			while (true)
			{
                loggedBoxLoad(monitor.lb, monitor.tbx, monitor.selected);
				Thread.Sleep(2500);
			}
		}

		/* Load the users logged from arraylist to a listbox and make it reload */
		public void loggedBoxLoad(ListBox lb, TextBox tbx, string slt)
		{
			if (lb.InvokeRequired)
			{
				LoggedBoxCallback fbc = new LoggedBoxCallback(loggedBoxLoad);
                Invoke(fbc, new object[] { lb, tbx, slt });
			}
			else
			{
				lb.Items.Clear();

                mainList = new ArrayList();
                mainList = formMain.mainList;
				string filter = tbx.Text;

                // Bind the userList from the main form
                mainList = formMain.mainList;

				// Loads the userList to a listbox
				foreach (User user in mainList)
				{
					// Verifies if the computer matches empty filter
					if (filter.Trim().Equals(""))
					{
						bool filtered = false;
						// Verifies each of the filters applied
						for (int t = 0; t < monitors.Length; t++)
						{
							string auxFilter = monitors[t].tbx.Text;
							if (user.Computer.IndexOf(auxFilter, StringComparison.OrdinalIgnoreCase) == 0 && !auxFilter.Equals(""))
								filtered = true;
						}
						if (!filtered)
							lb.Items.Add(user.Computer + " \\ " + user.Name);
					} // Verifies if the computer matches some filter
					else if (user.Computer.IndexOf(filter, StringComparison.OrdinalIgnoreCase) == 0 && !filter.Equals(""))
						lb.Items.Add(user.Computer + " \\ " + user.Name);
				}

				lb.Refresh();
				//lb.Update();

				if (lb.FindStringExact(slt) >= 0)
				{
					slt = lb.SelectedItem.ToString();
					lb.SelectedIndex = lb.FindStringExact(slt);
				}
			}
		}

		/* Capture the event of double click on an item of listbox */
		private void loggedBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				ListBox loggedBox = (ListBox)sender;
				int index = loggedBox.IndexFromPoint(e.Location);
				string compUser = loggedBox.SelectedItem.ToString();

				if (index != System.Windows.Forms.ListBox.NoMatches)
				{
					formMain.showRunningApps(compUser);
				}
			}
			catch (Exception ex) {
				MessageBox.Show("sill2-server: Error to view the computer process.\n" + ex.Message);
			}
		}

		/* On form close, stop the threads */
		private void monitorForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			for (int t = 0; t < 8; t++)
			{
                loggedBoxThreads[t].Abort();
			}
		}
	}
}