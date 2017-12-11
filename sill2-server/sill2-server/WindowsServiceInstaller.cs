using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace sill2_server
{
	[RunInstaller(true)]
	public class WindowsServiceInstaller : Installer
	{
		public WindowsServiceInstaller()
		{
			ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
			ServiceInstaller serviceInstaller = new ServiceInstaller();

			//# Service Account Information
			serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
			serviceProcessInstaller.Username = null;
			serviceProcessInstaller.Password = null;

			//# Service Information
			serviceInstaller.DisplayName = "Controlador de limite de sessões dos usuários.";
			serviceInstaller.StartType = ServiceStartMode.Automatic;

			//# This must be identical to the WindowsService.ServiceBase name
			//# set in the constructor of WindowsService.cs
			serviceInstaller.ServiceName = "SILL2 Server";

			this.Installers.Add(serviceProcessInstaller);
			this.Installers.Add(serviceInstaller);
		}
	}
}