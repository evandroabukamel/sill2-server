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
using System.Windows.Forms;

namespace sill2_server
{
    public partial class idvForm : Form
    {
        private mntForm mntFormInstance;

        public idvForm()
        {
            InitializeComponent();
        }

        /* Loads the labs list to the combobox cmbSign. */
        private void idvForm_Load(object sender, EventArgs e)
        {            
            cmbSign.Items.Add("LOGOFF");
            cmbSign.Items.Add("RESTART");
            cmbSign.Items.Add("SHUTDOWN");

            // Instance a mntForm to access yours methods
            mntFormInstance = new mntForm();
        }

		/* Sends the selected signal to a lab to the machines on a file */
		private async void btnSendSignal_Click(object sender, EventArgs e)
		{
			try
			{
				string maq = txtMaq.Text.ToString();
				string signal = cmbSign.SelectedItem.ToString();
				string message = txtMsg.Text.ToString();
				string time = txtTime.Text.ToString();

				// Call the callPsShutdown() method from the mntForm
				await mntFormInstance.callPsShutdown(maq, maq, time, message, signal);
			}
			catch (Exception ex)
			{
				MessageBox.Show("sill2-server: The signal could not be aborted.\n" + ex.Message);
			}
		}

		/* Abort a sended signal */
		private async void btnCancel_Click(object sender, EventArgs e)
		{
			try
			{
				string maq = txtMaq.Text.ToString();
				string signal = "ABORT";

				// Call the callPsShutdown() method from the mntForm
				await mntFormInstance.callPsShutdown(maq, maq, "", "", signal);
			}
			catch (Exception ex)
			{
				MessageBox.Show("sill2-server: The signal could not be aborted.\n" + ex.Message);
			}
		}

		/* Disables the time and message setter if the signal choosed is LOGOFF, because it not contains this option */
		private void cmbSign_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If LOGOFF choosed
            /*if (String.Compare(cmbSign.SelectedItem.ToString(), "LOGOFF") == 0)
            {
                txtTime.Text = "0";
                txtMsg.Text = "SEM MENSAGEM. O ENVIO DO SINAL SERÁ INSTANTÂNEO!";
                txtTime.Enabled = false;
                txtMsg.Enabled = false;
            }
            else
            {
                txtTime.Text = "";
                txtTime.Enabled = true;

                txtMsg.Text = "";
                txtMsg.Enabled = true;
            }*/
        }
    }
}
