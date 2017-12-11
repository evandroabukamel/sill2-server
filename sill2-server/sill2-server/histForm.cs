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
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sill2_server
{
    public partial class histForm : Form
    {
        // MySQL connection attributes
        public static MySqlConnection dbConn;
        public static MySqlDataAdapter dbAdapter;
        public static DataSet dbDataSet;
        private string histQuery;
        
        public histForm()
        {
            InitializeComponent();

            // Populate datagrid with data in the new dataset
            dbAdapter = new MySqlDataAdapter();
            dbDataSet = new DataSet();

            // Defines connection string and creates the connection
            dbConn = DBConnection.create();
        }

        /* Loads the selected data on datagrid */
        private void histForm_Load(object sender, EventArgs e)
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
                // Inits the SQL Query
                histQuery = "SET lc_time_names = 'pt_BR'; SELECT `user`, `computer`, DATE_FORMAT(`logon`, '%a, %e %b %Y, %H:%i:%s') AS `flogon`, DATE_FORMAT(`logoff`, '%a, %e %b %Y, %H:%i:%s') AS `flogoff` FROM `sill2`.`history` ";

                // Create data adapter
                executeQuery();

                // Populate a new data table and bind it to the BindingSource
                // Bind the data to the datagrid
                bindDatagrid();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("sill2-server: The data could not be bind to the data grid.\n" + ex.Message);
            }
        }

        /* Generates the query string and execute the command */
        private void executeQuery()
        {
            string query = " ";
			string timeQuery = "SELECT `user`, SEC_TO_TIME(SUM(TIMEDIFF(`logoff`, `logon`))) as `totaltime` FROM `sill2`.`history` ";
            int waux = 0;

            // Verifies if all fields are empty
            if (txtComp.TextLength == 0 
                && txtUser.TextLength == 0
                && dtp1.Value.Date == DateTime.Today.Date 
                && dtp2.Value.Date == DateTime.Today.Date)
            {
                query += " WHERE DATE(`history`.`logon`)=DATE(NOW()) ORDER BY `history`.`logon` DESC;";
            }
            else // If same field is filled mount the where query
            {
                query += " WHERE ";

                if (txtUser.TextLength > 0)
                {
                    query += " `user` = '" + txtUser.Text.Trim() + "' ";
                    waux++;
                }
                if (txtComp.TextLength > 0)
                {
                    if (waux > 0)
                        query += " AND ";
                    query += " `computer` LIKE '" + txtComp.Text.Trim() + "%' ";
                    waux++;
                }
                if (dtp1.Value.Date <= DateTime.Today)
                {
                    if (waux > 0)
                        query += " AND ";
                    query += " DATE(`logon`) >= '" + dtp1.Value.Date.ToString("yyyy-MM-dd") + "' ";
                    waux++;
                }
                if (dtp2.Value.Date <= DateTime.Today)
                {
                    if (waux > 0)
                        query += " AND ";
                    query += " DATE(`logoff`) <= '" + dtp2.Value.Date.ToString("yyyy-MM-dd") + "' ";
                    waux++;
                }

				timeQuery += query + " GROUP BY `user`;";
                query += " ORDER BY `logon` DESC;";
            }
            
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

            // Creates DataAdapter
			using (dbAdapter.SelectCommand = new MySqlCommand(histQuery + query, dbConn))
			using (MySqlDataReader totalTimeRes = new MySqlCommand(timeQuery, dbConn).ExecuteReader())
			{
				while (totalTimeRes.Read())
				{
					if (String.Compare(txtUser.Text, totalTimeRes.GetString("user")) == 0)
					{
						lblTotalTime.Text = totalTimeRes.GetString("totaltime");
					}
				}

				dbConn.Close();
			}
        }

        /* Binds the result on datagrid */
        private void bindDatagrid()
        {
            // Populate a new data table and bind it to the BindingSource
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dbAdapter.Fill(table);

            // Bind the data to the datagrid
            datagridHist.DataSource = table;

            // Sets the datagrid headers
            datagridHist.Columns[0].HeaderText = "Usuário";
            datagridHist.Columns[0].Width = 100;
            datagridHist.Columns[1].HeaderText = "Computador";
            datagridHist.Columns[1].Width = 100;
            datagridHist.Columns[2].HeaderText = "Logon";
            datagridHist.Columns[2].Width = 165;
            datagridHist.Columns[3].HeaderText = "Logoff";
            datagridHist.Columns[3].Width = 165;
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            // Create data adapter
            executeQuery();

            // Populate a new data table and bind it to the BindingSource
            // Bind the data to the datagrid
            bindDatagrid();
        }

        private void txtComp_TextChanged(object sender, EventArgs e)
        {
            // Create data adapter
            executeQuery();

            // Populate a new data table and bind it to the BindingSource
            // Bind the data to the datagrid
            bindDatagrid();
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            // Create data adapter
            executeQuery();

            // Populate a new data table and bind it to the BindingSource
            // Bind the data to the datagrid
            bindDatagrid();
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            // Create data adapter
            executeQuery();

            // Populate a new data table and bind it to the BindingSource
            // Bind the data to the datagrid
            bindDatagrid();
        }

    }
}
