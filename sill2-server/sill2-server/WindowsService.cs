using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ServiceProcess;

namespace sill2_server
{
	public class WindowsService : ServiceBase
	{
		public WindowsService()
		{
			this.ServiceName = "SILL2 Server";
			this.EventLog.Log = "Application";

			// These Flags set whether or not to handle that specific type of event. Set to true if you need it, false otherwise.
			this.CanHandlePowerEvent = true;
			this.CanHandleSessionChangeEvent = false;
			this.CanPauseAndContinue = false;
			this.CanShutdown = false;
			this.CanStop = true;
		}
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			ServiceBase.Run(new WindowsService());
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		protected override void OnStart(string[] args)
		{
			base.OnStart(args);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new formMain());
		}

		protected override void OnStop()
		{
			base.OnStop();

			Application.Exit();
		}

		protected override void OnPause()
		{
			base.OnPause();
		}

		protected override void OnContinue()
		{
			base.OnContinue();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new formMain());
		}

		protected override void OnShutdown()
		{
			base.OnShutdown();
		}

		protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
		{
			return base.OnPowerEvent(powerStatus);
		}

		protected override void OnSessionChange(SessionChangeDescription changeDescription)
		{
			base.OnSessionChange(changeDescription);
		}
	}
}