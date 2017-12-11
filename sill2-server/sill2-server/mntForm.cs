/**
 * SILL2 - Server (Sistema Individual LimitLogin v2.0)
 * 
 * Author: Evandro Abu Kamel
 * Company: Pontifícia Universidade Católica de Minas Gerais
 * Copyright: Evandro Abu Kamel © 2011
 * Description: This file contains an abstract class and a method that is responsable to read the configuration file
 *				to access the database. The method parse the lines of the file and creates a MySqlConnection, returning it. 
 **/

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace sill2_server
{
    public partial class mntForm : Form
	{
        public ArrayList labList;
		public delegate void SinalCallback(string filepath);
		
		public mntForm()
		{
			InitializeComponent();
			
            chklistLab.Items.Add("TODOS");
            labList = getLabList();

			foreach (string lab in getLabLabelList(labList))
			{
                chklistLab.Items.Add(lab);
            }
		}

        /* Loads the labs list to the combobox cmbLab and cmbSign. */
        private void mntForm_Load(object sender, EventArgs e)
        {
			cmbSign.Items.Add("LOGOFF");
            cmbSign.Items.Add("RESTART");
            cmbSign.Items.Add("SHUTDOWN");
			cmbSign.Items.Add("INSTALAR CLIENT");
        }

		/* Returns the list with the labs names, not the files paths */
		public ArrayList getLabLabelList(ArrayList labList)
		{
			ArrayList list = new ArrayList();
			foreach (string lab in labList)
			{
				string[] labPath = lab.Split('\\');
				string labFileName = labPath[labPath.Length - 1];
				list.Add(labFileName.Replace(".txt", "").Trim());
			}
			return list;
		}

        /* Get the names of the labs from reading the labs directory. */
		private ArrayList getLabList()
        {
            string[] labsVector = Directory.GetFiles(@""+Environment.CurrentDirectory+"\\labs\\", "*.txt");
            ArrayList labsList = new ArrayList();
            foreach (string lab in labsVector)
            {
                labsList.Add(lab);
            }
            return labsList;
        }

		/* Sends the selected signal to a lab to the machines on a file */
		private async void btnSendSignal_Click(object sender, EventArgs e)
		{
			try
			{
				int time = int.Parse(txtTime.Text);
				string signal = cmbSign.SelectedItem.ToString();
				string message = "Prezado(a), esse laboratório entrará em manutenção em breve. Favor utilizar outro laboratório.";

				// Send signal for ALL labs
				if (chklistLab.GetItemChecked(0))
				{
					string filePath = "";
					for (int i = 0; i < labList.Count; i++)
					{
						filePath = labList[i].ToString();
						await callPsShutdown(filePath, chklistLab.Items[i + 1].ToString(), time.ToString(), message, signal);
						//MessageBox.Show("Waiting...");

						//await Task.Delay(45000);
						Application.DoEvents();
					}
				}
				else    // Send signal for just ONE or SOME labs
				{
					string filePath = "";
					for (int i = 0; i < labList.Count; i++)
					{
						if (chklistLab.GetItemChecked(i + 1))
						{
							filePath = labList[i].ToString();
							await callPsShutdown(filePath, chklistLab.Items[i + 1].ToString(), time.ToString(), message, signal);
							//MessageBox.Show("Waiting...");

							//await Task.Delay(45000);
							Application.DoEvents();
						}
					}

					Application.DoEvents();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("sill2-server: The signal could not be send.\n" + ex.Message);
			}
		}

		/* Abort a sended signal */
		private async void btnCancel_Click(object sender, EventArgs e)
		{
			try
			{
				string signal = "ABORT";

				// Send signal for ALL labs
				if (chklistLab.GetItemChecked(0))
				{
					string filePath = "";
					for (int i = 0; i < labList.Count; i++)
					{
						filePath = labList[i].ToString();
						await callPsShutdown(filePath, chklistLab.Items[i + 1].ToString(), "", "", signal);
						//MessageBox.Show("Waiting...");

						//await Task.Delay(45000);
						Application.DoEvents();
					}
				}
				else    // Send signal for just ONE or SOME labs
				{
					// Retrieves the lab file path from the selected lab on combobox
					string filePath = "";
					for (int i = 0; i < labList.Count; i++)
					{
						if (chklistLab.GetItemChecked(i + 1))
						{
							filePath = labList[i].ToString();
							await callPsShutdown(filePath, chklistLab.Items[i + 1].ToString(), "", "", signal);
							//MessageBox.Show("Waiting...");

							//await Task.Delay(45000);
							Application.DoEvents();
						}
					}

					Application.DoEvents();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("sill2-server: The signal could not be aborted.\n" + ex.Message);
			}
		}

		/* Call the PsShtudown.exe for a lab file */
		async public Task callPsShutdown(string labFilePath, string labName, string time, string message, string signal)
        {
			await Task.Run(async () =>
			{
				string option = "-l";
				string[] maqlist;
				if (String.Compare(signal, "RESTART") == 0)
					option = "-r";
				if (String.Compare(signal, "SHUTDOWN") == 0)
					option = "-k";
				if (String.Compare(signal, "ABORT") == 0)
					option = "-a";

				if (File.Exists(labFilePath))
				{
					// Get all computers IPs/names from a file
					maqlist = File.ReadAllLines(labFilePath);
				}
				else
				{
					// Get the computer name
					maqlist = new string[1];
					maqlist[0] = labFilePath;
				}

				if (String.Compare(signal, "INSTALAR CLIENT") != 0)
				{
					// Use ProcessStartInfo class to create the proccess
					ProcessStartInfo psshutdown = new ProcessStartInfo();
					psshutdown.CreateNoWindow = true;
					psshutdown.UseShellExecute = true;
					psshutdown.WorkingDirectory = @"" + Environment.CurrentDirectory.ToString();
					psshutdown.FileName = "psshutdown.exe";
					psshutdown.WindowStyle = ProcessWindowStyle.Hidden;

					// Sends the signal for each computer...
					foreach (string maq in maqlist)	
					{
						if (String.Compare(signal, "RESTART") == 0 || String.Compare(signal, "SHUTDOWN") == 0)
							psshutdown.Arguments = "\\\\" + maq + " -accepteula " + option + " -t " + time + " -e p:4:2 -n 7 -m \"" + message + "\" ";
						else if (String.Compare(signal, "ABORT") == 0)  // If have to abort the singal
							psshutdown.Arguments = "\\\\" + maq + " -accepteula " + option + " -n 7";
						else if (String.Compare(signal, "LOGOFF") == 0) // To send logoff signal, use a PowerShell command
						{
							// Don't let too many process to run
							while (CountProcessRunning("powershell") >= 7)
							{
								await Task.Delay(2000);
							}

							/**
							 * Consultar futuramente nova forma de enviar sinal atraves do PowerShell
							 * https://blogs.technet.microsoft.com/dkegg/2011/10/25/powershell-remote-user-logoff-reboot/
							 * */
							psshutdown.WorkingDirectory = @"" + Environment.SystemDirectory + "System32\\WindowsPowerShell\\v1.0";
							psshutdown.FileName = "powershell.exe";
							psshutdown.Arguments = "(gwmi win32_operatingsystem -ComputerName " + maq + ").Win32ShutdownTracker("+ time + ", \"" + message + "\", 4)";

							try
							{
								// Start the process with the info we specified.
								// Call WaitForExit and then the using statement will close.
								using (Process exeProcess = Process.Start(psshutdown))
								{
									//exeProcess.WaitForExit();
									await Task.Delay(1000);
								}
							}
							catch (Exception ex)
							{
								new Thread(() =>
								{
									MessageBox.Show("sill2-server: Error while calling powershell.exe.\n" + ex.Message);
								}).Start();
							}
						}

						if (String.Compare(signal, "RESTART") == 0 || String.Compare(signal, "SHUTDOWN") == 0 || String.Compare(signal, "ABORT") == 0)
						{
							try
							{
								// Don't let too many process to run
								while (CountProcessRunning("psshutdown") >= 7)
								{
									await Task.Delay(2000);
								}

								// Start the process with the info we specified.
								// Call WaitForExit and then the using statement will close.
								using (Process exeProcess = Process.Start(psshutdown))
								{
									//exeProcess.WaitForExit();
									await Task.Delay(1000);
								}
							}
							catch (Exception ex)
							{
								new Thread(() =>
								{
									MessageBox.Show("sill2-server: Error while calling PsShutdown.exe.\n" + ex.Message);
								}).Start();
							}
						}
					}
				}
				else // Executes the installation of SILL2 CLIENT
				{
					// Sends the signal for each computer...
					foreach (string maq in maqlist)
					{
						try
						{
							// Create the hidden directory on client machine
							string path = @"\\" + maq + "\\c$\\Windows\\SysWoW64";
							if (!Directory.Exists(path))
							{
								DirectoryInfo di = Directory.CreateDirectory(path);
								di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
							}

							// Copy the files to the client
							File.Copy(DBConnection.getFileServer() + "\\..\\sill2-client\\sill2-client.exe", path + "\\sill2-client.exe", true);
							File.Copy(DBConnection.getFileServer() + "\\..\\sill2-client\\sill2-client-config.ini", path + "\\sill2-client-config.ini", true);
							File.Copy(DBConnection.getFileServer() + "\\..\\sill2-client\\MySql.Data.dll", path + "\\MySql.Data.dll", true);
							await Task.Delay(1000);
						}
						catch (Exception ex)
						{
							new Thread(() =>
							{
								MessageBox.Show("sill2-server: Error while copying SILL2 Client files.\n" + ex.Message + "\n" + ex.GetBaseException());
							}).Start();
						}
					}
				}

				new Thread(() =>
				{
					MessageBox.Show(String.Format("Sinal enviado ao {0}!", labName));
				}).Start();
			});
		}

        /* Disables the time setter if the signal choosed is LOGOFF, because it not contains this option */
        private void cmbSign_SelectedValueChanged(object sender, EventArgs e)
        {
            // If LOGOFF choosed
            /*if (String.Compare(cmbSign.SelectedItem.ToString(), "LOGOFF") == 0)
            {
                txtTime.Text = "0";
                txtTime.Enabled = false;
            }
            else
            {
                txtTime.Text = "";
                txtTime.Enabled = true;
            }*/
        }

		/* Counts how many a process is running */
		public static int CountProcessRunning(string name)
		{
			int count = 0;
			// Here we're going to get a list of all running processes on the computer
			foreach (Process clsProcess in Process.GetProcesses())
			{
				/**
				 *	Now we're going to see if any of the running processes
				 *	match the currently running processes. Be sure to not
				 *	add the .exe to the name you provide, i.e: NOTEPAD,
				 *	not NOTEPAD.EXE or false is always returned even if
				 *	notepad is running.
				 *	Remember, if you have the process running more than once,
				 *	say IE open 4 times the loop thr way it is now will close all 4,
				 *	if you want it to just close the first one it finds
				 *	then add a return; after the Kill
				 */
				if (clsProcess.ProcessName.ToLower().Equals(name))
				{
					// if the process is found to be running then we return a true
					count++;
				}
			}
			//otherwise we return a false
			return count;
		}
	}
}
