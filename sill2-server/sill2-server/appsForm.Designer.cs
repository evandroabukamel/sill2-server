namespace sill2_server
{
	partial class appsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(appsForm));
			this.lblCompUser = new System.Windows.Forms.Label();
			this.appsBox = new System.Windows.Forms.ListBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.gridProcess = new System.Windows.Forms.DataGridView();
			this.exec = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mem = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.command = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridProcess)).BeginInit();
			this.SuspendLayout();
			// 
			// lblCompUser
			// 
			this.lblCompUser.AutoSize = true;
			this.lblCompUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCompUser.Location = new System.Drawing.Point(12, 22);
			this.lblCompUser.Name = "lblCompUser";
			this.lblCompUser.Size = new System.Drawing.Size(130, 24);
			this.lblCompUser.TabIndex = 0;
			this.lblCompUser.Text = "lblCompUser";
			// 
			// appsBox
			// 
			this.appsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.appsBox.BackColor = System.Drawing.Color.White;
			this.appsBox.FormattingEnabled = true;
			this.appsBox.Location = new System.Drawing.Point(12, 71);
			this.appsBox.Name = "appsBox";
			this.appsBox.Size = new System.Drawing.Size(600, 472);
			this.appsBox.TabIndex = 1;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Image = global::sill2_server.Properties.Resources.refresh_icon;
			this.btnRefresh.Location = new System.Drawing.Point(557, 9);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(55, 55);
			this.btnRefresh.TabIndex = 2;
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// gridProcess
			// 
			this.gridProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridProcess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.exec,
            this.mem,
            this.command,
            this.desc});
			this.gridProcess.Location = new System.Drawing.Point(12, 70);
			this.gridProcess.Name = "gridProcess";
			this.gridProcess.Size = new System.Drawing.Size(600, 10);
			this.gridProcess.TabIndex = 3;
			this.gridProcess.Visible = false;
			// 
			// exec
			// 
			this.exec.HeaderText = "Executável";
			this.exec.Name = "exec";
			this.exec.ReadOnly = true;
			// 
			// mem
			// 
			this.mem.HeaderText = "Memória (KiB)";
			this.mem.Name = "mem";
			this.mem.ReadOnly = true;
			// 
			// command
			// 
			this.command.HeaderText = "Comando";
			this.command.Name = "command";
			this.command.ReadOnly = true;
			// 
			// desc
			// 
			this.desc.HeaderText = "Descrição";
			this.desc.Name = "desc";
			this.desc.ReadOnly = true;
			// 
			// appsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(624, 558);
			this.Controls.Add(this.gridProcess);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.appsBox);
			this.Controls.Add(this.lblCompUser);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "appsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Aplicativos em Execução";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.appsForm_FormClosing);
			this.Load += new System.EventHandler(this.appsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridProcess)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblCompUser;
		private System.Windows.Forms.ListBox appsBox;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.DataGridView gridProcess;
		private System.Windows.Forms.DataGridViewTextBoxColumn exec;
		private System.Windows.Forms.DataGridViewTextBoxColumn mem;
		private System.Windows.Forms.DataGridViewTextBoxColumn command;
		private System.Windows.Forms.DataGridViewTextBoxColumn desc;
	}
}