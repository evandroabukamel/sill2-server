/**
 * SILL2 - Server (Sistema Individual LimitLogin v2.0)
 * 
 * Author: Evandro Abu Kamel
 * Company: Pontifícia Universidade Católica de Minas Gerais
 * Copyright: Evandro Abu Kamel © 2011 - 2016
 * Description: This is the file of the formMain class, responsable for the application main window.
 **/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sill2_server
{
    public partial class formMain : Form
	{
        // Program Version
		private string version = " v1.17.2";
		private int lastErrorCode = 0;
		
		// List of logged and free users
        private ArrayList userList;
		public static ArrayList mainList;
        private ArrayList freeList;

		// Items selected from listboxes
		private string selectedLogged = null;
		private string selectedFreeuser = null;

		// MRE
		private readonly ManualResetEvent pauseLoggedBoxEvent = new ManualResetEvent(true);
		private readonly ManualResetEvent pauseFreeuserBoxEvent = new ManualResetEvent(true);
		private bool reloadLogged = false;
		private bool reloadFreeuser = false;

		// Workers
		BackgroundWorker workerLoggedBox = new BackgroundWorker();
		BackgroundWorker workerFreeuserBox = new BackgroundWorker();

		// Callbacks
		public delegate void LoggedBoxCallback(ListBox lb);
		public delegate void FreeuserBoxCallback(ListBox lb);
		
		// MySQL connection attributes
		public static MySqlConnection dbConn;
		public static MySqlDataAdapter dbAdapter;
		public static DataSet dbDataSet;

		public formMain()
		{
			InitializeComponent();

            // Set Version and Developer
            Text += version;
            lblDeveloper.Text = "Desenvolvido por Evandro Abu Kamel \nevandro.ak@pucminas.br";
			
			// Defines dataset
			dbDataSet = new DataSet();
			// Defines connection string
			dbConn = DBConnection.create();

			// Creates and starts the worker for refresh the LoggedBox
			try
			{
				workerLoggedBox.DoWork += new DoWorkEventHandler(workerLoggedBox_DoWork);
				workerLoggedBox.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			// Creates and starts the worker for refresh the FreeuserBox
			try
			{
				workerFreeuserBox.DoWork += new DoWorkEventHandler(workerFreeuserBox_DoWork);
				workerFreeuserBox.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        /* Puts a thread to automaticaly load the listboxes */
        private void formMain_Load(object sender, EventArgs e)
        {
            // Initializes the notifyIcon
            trayIcon = new NotifyIcon();
            trayIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath.ToString());
            trayIcon.ContextMenuStrip = contextMenu;
            trayIcon.DoubleClick += new EventHandler(notifyIcon_DoubleClick);
            trayIcon.Visible = false;

            // Enables the doubleClick on a ListBox Item
            loggedBox.MouseDoubleClick += new MouseEventHandler(loggedBox_MouseDoubleClick); 
        }

		/* Get the logged users from database and load them in a arraylist */
		private async Task<ArrayList> getLogged()
		{
			// Creates the auxiliars objects
			ArrayList list = new ArrayList();
			User user;

			// Open MySQL connection
			using (MySqlConnection tempConn = DBConnection.create())
			{
				if (tempConn.State != ConnectionState.Open)
				{
					try
					{
						RetryMySqlConnection(tempConn);
					}
					catch (Exception ex)
					{
						if (lastErrorCode != 1)
						{
							MessageBox.Show("1 - sill2-server: Connection could not be established.\n" + ex.Message);
							lastErrorCode = 1;
						}
					}
				}

				string sqlGetLoggedComm = "SELECT `user`, `computer`, `logon`, `lognow`, " +
					" IF (NOW() - INTERVAL 15 SECOND <= lognow, 1, 0) AS logged " +
					" FROM `sill2`.`logged` ORDER BY `computer` ASC;";
				using (MySqlCommand getLoggedComm = new MySqlCommand(sqlGetLoggedComm, tempConn))
				using (MySqlDataReader loggedList = (MySqlDataReader)await getLoggedComm.ExecuteReaderAsync())
				{
					// Reads each row from DataReader
					while (loggedList.Read())
					{
						// Instantiates a User
						user = new User(loggedList.GetString("user"), 
							loggedList.GetString("computer"), 
							loggedList.GetDateTime("logon"), 
							loggedList.GetDateTime("lognow"), 
							loggedList.GetBoolean("logged"));

						// Verifies if the user is realy logged
						if (user.Logged)
						{
							list.Add(user);
						}
						else // If the user is not logged...
						{
							// Open MySQL connection
							using (MySqlConnection tempConn2 = DBConnection.create())
							{
								// Open MySQL connection
								if (tempConn2.State == ConnectionState.Closed)
								{
									try
									{
										tempConn2.Open();
									}
									catch (Exception ex)
									{
										MessageBox.Show("sill2-server: Connection could not be established.\n" + ex.Message);
									}
								}

								// Saves the history of the logged user
								try
								{
									string chkrow = "CONCAT('" + user.Name + "','" + user.Computer + "','" + user.Logon() + "', NOW())";
									string insertHistorySql = "INSERT IGNORE INTO `sill2`.`history`(`user`, `computer`, `logon`, `logoff`, `chkrow`) "
										+ " VALUES('" + user.Name + "', '" + user.Computer + "', '" + user.Logon() + "', NOW(), MD5(" + chkrow + "));";
									using (MySqlCommand insHistoryComm = new MySqlCommand(insertHistorySql, tempConn2))
									{
										insHistoryComm.ExecuteNonQuery();
									}
								}
								catch (Exception ex)
								{
									MessageBox.Show("sill2-server: The user " + user.Computer + " \\ " + user.Name + " could not be inserted on the history table.\n" + ex.Message);
								}

								// Removes the user/computer from logged list on database and listbox
								try
								{
									string delLoggedSql = "DELETE FROM `sill2`.`logged` WHERE `user`='" + user.Name + "' AND `computer`='" + user.Computer + "';";
									using (MySqlCommand delLoggedComm = new MySqlCommand(delLoggedSql, tempConn2))
									{
										delLoggedComm.ExecuteNonQuery();
									}
								}
								catch (Exception ex)
								{
									MessageBox.Show("sill2-server: The user " + user.Computer + " \\ " + user.Name + " could not be deleted from users logged list.\n" + ex.Message);
								}

								tempConn2.Close();
                            }
						}
					}
					loggedList.Close();
                    loggedList.Dispose();
                    tempConn.Close();
				}
			}
			return list;
		}

		/* Get the free to login users from database and load them in a arraylist */
		private async Task<ArrayList> getFree()
		{
			// Creates the auxiliars objects
			ArrayList list = new ArrayList();
			User user;

			// Open MySQL connection
			using (MySqlConnection tempConn = DBConnection.create())
			{
				try
				{
					RetryMySqlConnection(tempConn);

					string sqlGetFreeUserComm = "SELECT `login` FROM `sill2`.`freeusers`;";
					using (MySqlCommand getFreeUserComm = new MySqlCommand(sqlGetFreeUserComm, tempConn))
					using (MySqlDataReader freeUsersList = (MySqlDataReader)await getFreeUserComm.ExecuteReaderAsync())
					{
						// Reads each row from DataReader
						while (freeUsersList.Read())
						{
							user = new User(freeUsersList.GetString("login"));
							list.Add(user);
						}

						freeUsersList.Close();
						freeUsersList.Dispose();
						tempConn.Close();
					}
				}
				catch (Exception ex)
				{
					if (lastErrorCode != 2)
					{
						MessageBox.Show("2 - sill2-server: Connection could not be established.\n" + ex.Message);
						lastErrorCode = 2;
					}
				}

				return list;
			}
		}

		/* Load the users logged from arraylist to a listbox and make it reload */
		public async void loggedBoxLoad(ListBox lb)
		{
			Application.DoEvents();
			//ThreadSafe(() =>
			//{
			if (lb.InvokeRequired)
			{
				LoggedBoxCallback fbc = new LoggedBoxCallback(loggedBoxLoad);
				Invoke(fbc, new object[] { lb });
			}
			else
			{
                //SuspendLayout();

                userList = new ArrayList();
				userList = await getLogged();
				mainList = userList;

				lb.Items.Clear();

				// Loads the userList to a listbox
				foreach (User user in userList)
				{
					lb.Items.Add(user.Computer + " \\ " + user.Name);
				}

				lb.Refresh();
				// lb.Update();
				Application.DoEvents();

				if (lb.FindStringExact(selectedLogged) >= 0)
				{
					lb.SelectedIndex = lb.FindStringExact(selectedLogged);
                }

                //ResumeLayout();
            }
			//});
		}

		/* Load the free to login users from arraylist to a listbox and make it reload */
		public async void freeuserBoxLoad(ListBox lb)
		{
			Application.DoEvents();
			//ThreadSafe(() =>
			//{
			if (lb.InvokeRequired)
			{
				FreeuserBoxCallback fbc = new FreeuserBoxCallback(freeuserBoxLoad);
				Invoke(fbc, new object[] { lb });
			}
			else
			{
                //SuspendLayout();

                freeList = new ArrayList();
				freeList = await getFree();

				lb.Items.Clear();

				// Loads the userList to a listbox
				foreach (User user in freeList)
				{
					lb.Items.Add(user.Name);
				}

				lb.Refresh();
				//lb.Update();
				Application.DoEvents();

				if (lb.FindStringExact(selectedFreeuser) >= 0)
				{
					lb.SelectedIndex = lb.FindStringExact(selectedFreeuser);
				}

               //ResumeLayout();
            }
			//});
		}

		void workerLoggedBox_DoWork(object sender, DoWorkEventArgs e)
		{
			//Glorious time-consuming code that no longer blocks!
			while (true)
			{
				loggedBoxLoad(loggedBox);
				Application.DoEvents();
				if (reloadLogged == false && pauseLoggedBoxEvent.WaitOne(2500))
				{
					pauseLoggedBoxEvent.Reset();
				}
				else
				{
					pauseLoggedBoxEvent.Set();
					reloadLogged = false;
				}

				//Application.DoEvents();
			}
		}

		void workerFreeuserBox_DoWork(object sender, DoWorkEventArgs e)
		{
			//Glorious time-consuming code that no longer blocks!
			while (true)
			{
				freeuserBoxLoad(freeuserBox);				
				Application.DoEvents();
                if (reloadFreeuser == false && pauseFreeuserBoxEvent.WaitOne(2500))
                {
                    pauseFreeuserBoxEvent.Reset();
					reloadFreeuser = false;
				}
                else
                {
                    pauseFreeuserBoxEvent.Set();
				}

				//Application.DoEvents();
			}
		}
		
		/* Add a logged user to the free to login list on database */
		private void btnAddFree_Click(object sender, EventArgs e)
		{
			new Thread(() =>
			{
				string login = "";
				// Open MySQL connection
				if (dbConn.State == ConnectionState.Closed)
				{
					try
					{
						RetryMySqlConnection(dbConn);
					}
					catch (Exception ex)
					{
						MessageBox.Show("sill2-server: Connection could not be established.\n" + ex.Message);
					}
				}

				try
				{
					// Retrieves the user name
					login = loggedBox.SelectedItem.ToString();
					string[] logged = login.Split('\\');
					login = logged[1].Trim();

					string sqlAddFreeComm = "INSERT INTO `sill2`.`freeusers`(`login`) VALUES('" + login + "');";
					using (MySqlCommand addFreeComm = new MySqlCommand(sqlAddFreeComm, dbConn))
					{
						addFreeComm.ExecuteNonQuery();
					}
				}
				catch (MySqlException)
				{
					MessageBox.Show("O usuário " + login + " já está na lista de usuários livres.");
				}
				catch (Exception ex)
				{
					MessageBox.Show("sill2-server: The user could not be added to free users list.\n" + ex.Message);
				}
				dbConn.Close();
			}).Start();
        }

        /* Remove a user from the free to login list on database */
        private void btnDelFree_Click(object sender, EventArgs e)
        {
			// Retrieves the user name
			string login = "";

			// Open MySQL connection
			if (dbConn.State == ConnectionState.Closed)
			{
				try
				{
					RetryMySqlConnection(dbConn);
				}
				catch (Exception ex)
				{
					MessageBox.Show("sill2-server: Connection could not be established.\n" + ex.Message);
				}
			}

			try
			{
				login = freeuserBox.SelectedItem.ToString().Trim();

				using (MySqlCommand delFreeComm = new MySqlCommand("DELETE FROM `sill2`.`freeusers` WHERE `login`='" + login + "';", dbConn))
				{
					delFreeComm.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("sill2-server: The user could not be deleted from free users list.\n" + ex.Message);
			}
			dbConn.Close();
        }

		/* Saves the value of the loggedBox selected item */
		private void loggedBox_SelectedValueChanged(object sender, EventArgs e)
		{
			if (loggedBox.SelectedIndex >= 0)
				selectedLogged = loggedBox.SelectedItem.ToString();
			Application.DoEvents();
		}

		/* Saves the value of the freeuserBox selected item */
		private void freeuserBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (freeuserBox.SelectedIndex >= 0)
				selectedFreeuser = freeuserBox.SelectedItem.ToString();
			Application.DoEvents();
		}

		/* Show the form when the user double clicks on the notify icon. */
		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			backNotify();
		}

        /* Call the command to show the main window */
		private void mostarJanelaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			backNotify();
		}

        /* Terminates the application and the threads */
		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
            dbConn.Close();
			trayIcon.Visible = false;
			Environment.Exit(0);
		}

		/* Handle Closing of the Form and show the tray icon */
		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = true;
            Hide();
            runNotify();
		}

        /* Shows the try icon and its message */
		private void runNotify()
		{
			trayIcon.Visible = true;
			trayIcon.ShowBalloonTip(5, "SILL2 Server", "SILL2 foi minimizado para a bandeja do sistema.", ToolTipIcon.Info);
		}

        /* Shows the main windows and hide the tray icon */
		private void backNotify()
		{
			trayIcon.Visible = false;

            Show();
            WindowState = FormWindowState.Normal;

            // Activate the form.
            Activate();
		}

        /* Search the computers that have the same users logged */
		private void btnPesqUser_Click(object sender, EventArgs e)
		{
			string user = txtbxPesqUser.Text;

			// Open MySQL connection
			// MySqlConnection tempConn = DBConnection.create();
			if (dbConn.State == ConnectionState.Closed)
			{
				try
				{
					dbConn.Open();
				}
				catch (Exception ex)
				{
					MessageBox.Show("sill2-server: Connection could not be established.\n" + ex.Message);
				}
			}

			string sqlSearchUserQuery = "SELECT `computer` FROM `sill2`.`logged` WHERE `user`='" + user + "';";
			using (MySqlCommand searchUserQuery = new MySqlCommand(sqlSearchUserQuery, dbConn))
			using (MySqlDataReader searchUserRes = searchUserQuery.ExecuteReader())
			{
				if (searchUserRes.HasRows)
				{
					string searchUserMessage = "O usuário " + user + " está logado em: \n";
					while (searchUserRes.Read())
					{
						searchUserMessage += "\n" + searchUserRes.GetString("computer");

					}
					MessageBox.Show(searchUserMessage);
				}
				else
					MessageBox.Show("O usuário " + user + " não está logado.");

				txtbxPesqUser.Text = "";
				searchUserRes.Close();
				dbConn.Close();
			}
        }

        /* Search the user logged on a computer */
		private void btnPesqComp_Click(object sender, EventArgs e)
		{
			string computer = txtbxPesqComp.Text;
			string user;

			// Open MySQL connection
			// MySqlConnection tempConn = DBConnection.create();
			if (dbConn.State == ConnectionState.Closed)
			{
				try
				{
					dbConn.Open();
				}
				catch (Exception ex)
				{
					MessageBox.Show("sill2-server: Connection could not be established.\n" + ex.Message);
				}
			}

			string sqlSearchCompQuery = "SELECT `user` FROM `sill2`.`logged` WHERE `computer`='" + computer + "';";
			using (MySqlCommand searchCompQuery = new MySqlCommand(sqlSearchCompQuery, dbConn))
			using (MySqlDataReader searchCompRes = searchCompQuery.ExecuteReader())
			{
				if (searchCompRes.HasRows)
				{
					searchCompRes.Read();
					user = searchCompRes.GetString("user");
					MessageBox.Show("O computador " + computer + " está sendo usado por " + user + ".");
				}
				else
					MessageBox.Show("O computador " + computer + " não está sendo usado.");

				txtbxPesqComp.Text = "";
				searchCompRes.Close();
				dbConn.Close();
			}
        }

		/* Remove a logged user from logged list, freeing it */
		private void btnUnblock_Click(object sender, EventArgs e)
		{
			new Thread(() =>
			{
				string login = txtbxBlocked.Text.Trim();
				string computer;

				try
				{
					using (MySqlConnection tempConn = DBConnection.create())
					{
						string sqlSearchCompQuery = "SELECT `computer` FROM `sill2`.`logged` WHERE `user`='" + login + "';";
						using (MySqlCommand searchCompQuery = new MySqlCommand(sqlSearchCompQuery, dbConn))
						using (MySqlDataReader searchCompRes = searchCompQuery.ExecuteReader())
						{
							if (searchCompRes.HasRows)
							{
								searchCompRes.Read();
								computer = searchCompRes.GetString("computer");
							}
							searchCompRes.Close();
						}

						// Removes the user from logged table
						tempConn.Open();
						string sqlUnblockQuery = "DELETE FROM `sill2`.`logged` WHERE `user`='" + login + "';";
						using (MySqlCommand unblockQuery = new MySqlCommand(sqlUnblockQuery, tempConn))
						{
							if (unblockQuery.ExecuteNonQuery() > 0)
								MessageBox.Show("O usuário " + login + " está liberado.");
							else
								MessageBox.Show("O usuário " + login + " não foi encontrado.");

							// Logoff the user by PowerShell
						}
						tempConn.Close();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("sill2-server: The user could not be liberated.\n" + ex.Message);
				}
			}).Start();
        }

        /* Add a logged user to the free to login list on database */
        private void bntAddFreeUser_Click(object sender, EventArgs e)
        {
			new Thread(() =>
			{
				// Retrieves the user name
				string login = txtbxAddFreeUser.Text.Trim();

				if (login.Length > 0)
				{
					// Open MySQL connection
					if (dbConn.State == ConnectionState.Closed)
					{
						try
						{
							dbConn.Open();
						}
						catch (Exception ex)
						{
							MessageBox.Show("sill2-server: Connection could not be established.\n" + ex.Message);
						}
					}

					try
					{
						string sqlAddFreeComm = "INSERT INTO `sill2`.`freeusers`(`login`) VALUES('" + login + "');";
						using (MySqlCommand addFreeComm = new MySqlCommand(sqlAddFreeComm, dbConn))
						{
							addFreeComm.ExecuteNonQuery();
						}
					}
					catch (MySqlException)
					{
						MessageBox.Show("O usuário " + login + " já está na lista de usuários livres.");
					}
					catch (Exception ex)
					{
						MessageBox.Show("sill2-server: The user could not be added to free users list.\n" + ex.Message);
					}
					dbConn.Close();

					// Clear the textBox
					SetText("", txtbxAddFreeUser);
				}
			}).Start();
		}

		/* Executes the SILL2 Client on a remote machine */
		private void btnClient_Click(object sender, EventArgs e)
		{
			new Thread(() =>
			{
				string comp = txtbxClient.Text.Trim();

				try
				{
					// Create the hidden directory on client machine
					string path = @"\\" + comp + "\\c$\\Program files\\sill2-client";
					if (!Directory.Exists(path))
					{
						DirectoryInfo di = Directory.CreateDirectory(path);
						di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
					}

					// Copy the files to the client
					File.Copy(@"\\" + comp + "\\c$\\Program files\\sill2-client\\sill2-client.exe", path + "\\sill2-client.exe", true);
					File.Copy(@"\\" + comp + "\\c$\\Program files\\sill2-client\\sill2-client-config.ini", path + "\\sill2-client-config.ini", true);
					File.Copy(@"\\" + comp + "\\c$\\Program files\\sill2-client\\MySql.Data.dll", path + "\\MySql.Data.dll", true);
				}
				catch (Exception ex)
				{
					MessageBox.Show("sill2-server: Error while copying SILL2 Client files.\n" + ex.Message + "\n" + ex.GetBaseException());
				}

				// Use ProcessStartInfo class to create the proccess
				ProcessStartInfo psexec = new ProcessStartInfo();
				psexec.CreateNoWindow = false;
				psexec.UseShellExecute = true;
				psexec.WorkingDirectory = @"" + Environment.CurrentDirectory.ToString();
				psexec.FileName = "psexec.exe";
				psexec.WindowStyle = ProcessWindowStyle.Hidden;
				psexec.Arguments = @"\\" + comp + "\\c$\\Program files\\sill2-client\\sill2-client.exe";

				try
				{
					// Start the process with the info we specified.
					// Call WaitForExit and then the using statement will close.
					using (Process exeProcess = Process.Start(psexec))
					{
						//exeProcess.WaitForExit();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("sill2-server: Error while calling psexec.exe.\n" + ex.Message);
				}
			}).Start();
		}

		// Show the window of Monitor by Lab
		private void btnMonit_Click(object sender, EventArgs e)
		{
			//Form monitorFormInstance = new monitorForm();
			//monitorFormInstance.Show();
			new Thread(() => new monitorForm().ShowDialog()).Start();
		}

        /* Show the window of labs management */
        private void btnMntForm_Click(object sender, EventArgs e)
        {
			//Form mntFormInstance = new mntForm();
			//mntFormInstance.Show();
			new Thread(() => new mntForm().ShowDialog()).Start();
		}

        /* Show the window of individual computer management */
		private void btnIdvForm_Click(object sender, EventArgs e)
		{
			//Form idvFormInstance = new idvForm();
			//idvFormInstance.Show();
			new Thread(() => new idvForm().ShowDialog()).Start();
		}

		/* Show the window of the history of login and logoff */
        private void btnHistForm_Click(object sender, EventArgs e)
        {
            //Form histFormInstance = new histForm();
            //histFormInstance.Show();
			new Thread(() => new histForm().ShowDialog()).Start();
		}

		/* Show the window with the applications running on a computer */
		public static void showRunningApps(string compUser)
		{
			//Form appsFormInstance = new appsForm(compUser);
			//appsFormInstance.Show();
			new Thread(() => new appsForm(compUser).ShowDialog()).Start();
		}

		/* Capture the event of double click on an item of listbox */
		private void loggedBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = loggedBox.IndexFromPoint(e.Location);

			if (loggedBox.SelectedItem != null)
			{
				string compUser = loggedBox.SelectedItem.ToString();

				if (index != ListBox.NoMatches)
				{
					showRunningApps(compUser);
				}
			}
		}

		/* Get the list of applications on remote computer */
		public static ArrayList getApps(string comp)
		{
			ArrayList list = new ArrayList();
			try
			{
				ConnectionOptions co = new ConnectionOptions();
				co.Impersonation = ImpersonationLevel.Impersonate;
				co.EnablePrivileges = true;

				ManagementScope scope = new ManagementScope(@"\\" + comp + @"\root\cimv2", co);
				SelectQuery query = new SelectQuery("SELECT * FROM Win32_Process");
				ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

				StringBuilder cols;

				foreach (ManagementObject app in searcher.Get())
				{
					cols = new StringBuilder("");
					//MessageBox.Show(app.GetPropertyValue("Caption").ToString());
					cols.Append(app.GetPropertyValue("Caption").ToString()).Append("   ||||   ");
					cols.Append(app.GetPropertyValue("WorkingSetSize").ToString()).Append("   ||||   ");
					//cols.Append(app.GetPropertyValue("ExecutablePath").ToString()); //.Append("   ||||   ");
					// cols.Append(app.GetPropertyValue("CommandLine").ToString()); //.Append("   ||||   ");
					// cols.Append(app.GetPropertyValue("ExecutablePath").ToString());
					// MessageBox.Show(cols.ToString());

					list.Add(cols.ToString());
				}

				// Sort the array by alphabetical
				list.Sort();
			}
			catch (Exception ex)
			{
				MessageBox.Show("sill2-server: Error to retrieve the remote process list. \n" + ex.Message + "\n" + ex.StackTrace);
			}
			return list;
		}

		// Change the text of a TextBox calling from inside a new Thread
		delegate void SetTextCallback(string text, TextBox textBox);
		private void SetText(string text, TextBox textBox)
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (textBox.InvokeRequired)
			{
				SetTextCallback d = new SetTextCallback(SetText);
				this.Invoke(d, new object[] { text, textBox });
			}
			else
			{
				textBox.Text = text;
			}
		}

		public MySqlConnection RetryMySqlConnection(MySqlConnection connection)
		{
			while (connection.State != ConnectionState.Open)
			{
				// Delay for 10 seconds...
				Thread.Sleep(10000);

				// Checks if connection is closed
				if (connection.State == ConnectionState.Closed)
				{
					connection.Open();
				}
				else if (connection.State == ConnectionState.Broken)
				{
					connection.Close();
					connection.Open();
				}
			}
			return connection;
		}

		public static void ThreadSafe(Action action)
		{
			Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal,
				new MethodInvoker(action));
		}
		
	}
}