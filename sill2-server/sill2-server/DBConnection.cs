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
using System.IO;
using System.Windows.Forms;
using Ini;
using MySql.Data.MySqlClient;

namespace sill2_server
{
    /**
	 * This class is responsable to read the configuration file, named "dbconnect.cfg", that must be
	 * in the same directory of the executable file "sill2-client".
	 */
    public abstract class DBConnection
	{
		private static string fileServer, domain, dbServer, database, port, user, password;
		private static MySqlConnection connection;

		/**
		 * This method reads and parses the configuration file and creates the MySqlConnection, returning it in the end.
		 */
		public static MySqlConnection create()
		{
			IniFile localConfigFile;
			
			// Try to read the configuration file for database connection
			try
			{
				localConfigFile = new IniFile(@"" + Directory.GetCurrentDirectory() + "\\sill2-server-config.ini");
				fileServer = localConfigFile.IniReadValue("Config", "FileServer");
                //serverConfigFile = new IniFile(@"" + fileServer + "\\sill2-server-config.ini");

                // Sets the connection variables
                domain = localConfigFile.IniReadValue("Config", "Domain");
                dbServer = localConfigFile.IniReadValue("Config", "DbServer");
                database = localConfigFile.IniReadValue("Config", "Database");
                port = localConfigFile.IniReadValue("Config", "Port");
                user = localConfigFile.IniReadValue("Config", "User");
                password = localConfigFile.IniReadValue("Config", "Password");

                /*
                // Compare DbServer
                if (String.Compare(
					localConfigFile.IniReadValue("Config", "DbServer"),
					serverConfigFile.IniReadValue("Config", "DbServer"),
					false) == 0)
				{
					dbServer = localConfigFile.IniReadValue("Config", "DbServer");
				}
				else
				{
					dbServer = serverConfigFile.IniReadValue("Config", "DbServer");
					localConfigFile.IniWriteValue("Config", "DbServer", dbServer);
				}

				// Compare Database
				if (String.Compare(
					localConfigFile.IniReadValue("Config", "Database"),
					serverConfigFile.IniReadValue("Config", "Database"),
					false) == 0)
				{
					database = localConfigFile.IniReadValue("Config", "Database");
				}
				else
				{
					database = serverConfigFile.IniReadValue("Config", "Database");
					localConfigFile.IniWriteValue("Config", "Database", database);
				}

				// Compare Port
				if (String.Compare(
					localConfigFile.IniReadValue("Config", "Port"),
					serverConfigFile.IniReadValue("Config", "Port"),
					false) == 0)
				{
					port = localConfigFile.IniReadValue("Config", "Port");
				}
				else
				{
					port = serverConfigFile.IniReadValue("Config", "Port");
					localConfigFile.IniWriteValue("Config", "Port", port);
				}

				// Compare User
				if (String.Compare(
					localConfigFile.IniReadValue("Config", "User"),
					serverConfigFile.IniReadValue("Config", "User"),
					false) == 0)
				{
					user = localConfigFile.IniReadValue("Config", "User");
				}
				else
				{
					user = serverConfigFile.IniReadValue("Config", "User");
					localConfigFile.IniWriteValue("Config", "User", user);
				}

				// Compare Password
				if (String.Compare(
					localConfigFile.IniReadValue("Config", "Password"),
					serverConfigFile.IniReadValue("Config", "Password"),
					false) == 0)
				{
					password = localConfigFile.IniReadValue("Config", "Password");
				}
				else
				{
					password = serverConfigFile.IniReadValue("Config", "Password");
					localConfigFile.IniWriteValue("Config", "Password", password);
				}*/

				// Create the MySQL connection
				try
				{
					connection = new MySqlConnection("server=" + dbServer + "; port=" + port + "; database=" + database + "; uid=" + user + "; pwd=" + password + "");
				}
				catch (MySqlException ex)
				{
					MessageBox.Show("sill2-server: The MySQL connection could not be created.\n" + ex.Message);
				}
				catch (Exception ex)
				{
					MessageBox.Show("sill2-server: The MySQL connection could not be created.\n" + ex.Message);
				}
			}
			catch (FileNotFoundException ex)
			{
				MessageBox.Show("sill2-server: The configuration file could not be found.\n" + ex.Message);
			}
			catch (DirectoryNotFoundException ex)
			{
				MessageBox.Show("sill2-server: The specified path is invalid.\n" + ex.Message);
			}
			catch (IOException ex)
			{
				MessageBox.Show("sill2-server: The path includes an incorrect or invalid syntax for file name, directory name, or volume label.\n" + ex.Message);
			}

			return connection;
		}

        /* Return the domain name */
        public static string getDomain()
        {
            return domain;
        }

        /* Return the file server */
        public static string getFileServer()
        {
            return fileServer;
        }
    }
}