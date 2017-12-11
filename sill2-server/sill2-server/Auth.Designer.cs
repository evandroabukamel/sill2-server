namespace sill2_server
{
	partial class Auth
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
			this.lblUser = new System.Windows.Forms.Label();
			this.lblPass = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.btnAuth = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.Location = new System.Drawing.Point(52, 19);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(43, 13);
			this.lblUser.TabIndex = 0;
			this.lblUser.Text = "Usuário";
			// 
			// lblPass
			// 
			this.lblPass.AutoSize = true;
			this.lblPass.Location = new System.Drawing.Point(57, 51);
			this.lblPass.Name = "lblPass";
			this.lblPass.Size = new System.Drawing.Size(38, 13);
			this.lblPass.TabIndex = 1;
			this.lblPass.Text = "Senha";
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(101, 16);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(118, 20);
			this.txtUser.TabIndex = 2;
			// 
			// txtPass
			// 
			this.txtPass.Location = new System.Drawing.Point(101, 48);
			this.txtPass.Name = "txtPass";
			this.txtPass.Size = new System.Drawing.Size(118, 20);
			this.txtPass.TabIndex = 3;
			// 
			// btnAuth
			// 
			this.btnAuth.Location = new System.Drawing.Point(101, 98);
			this.btnAuth.Name = "btnAuth";
			this.btnAuth.Size = new System.Drawing.Size(75, 23);
			this.btnAuth.TabIndex = 4;
			this.btnAuth.Text = "Ok";
			this.btnAuth.UseVisualStyleBackColor = true;
			this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
			// 
			// Auth
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(275, 141);
			this.Controls.Add(this.btnAuth);
			this.Controls.Add(this.txtPass);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.lblPass);
			this.Controls.Add(this.lblUser);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Auth";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Autenticação";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.Label lblPass;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.Button btnAuth;
	}
}