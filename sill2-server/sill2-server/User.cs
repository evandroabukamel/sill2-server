using System;

namespace sill2_server
{
    public class User
	{
		private string name, computer;
		private DateTime logon, lognow;
		private bool logged;

		public User(string us, string comp, DateTime lo, DateTime ln, bool lg)
		{
            name = us;
            computer = comp;
            logon = lo;
            lognow = ln;
			logged = lg;
		}

		public User(string us)
		{
            name = us;
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
                name = value;
			}
		}

		public string Computer
		{
			get
			{
				return computer;
			}
			set
			{
                computer = value;
			}
		}

		public string Logon()
		{
			return logon.ToString("yyyy-MM-dd HH:mm:ss");
		}

		public void Logon(DateTime value)
		{
            logon = value;
		}

		public string Lognow()
		{
			return lognow.ToString("yyyy-MM-dd HH:mm:ss");
		}

		public void Lognow(DateTime value)
		{
            lognow = value;
		}

		public bool Logged
		{
			get
			{
				return logged;
			}
			set
			{
				logged = value;
			}
		}
	}
}