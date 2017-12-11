namespace sill2_server
{
    partial class histForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(histForm));
			this.lblUser = new System.Windows.Forms.Label();
			this.lblComp = new System.Windows.Forms.Label();
			this.lblData = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.txtComp = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.datagridHist = new System.Windows.Forms.DataGridView();
			this.dtp1 = new System.Windows.Forms.DateTimePicker();
			this.dtp2 = new System.Windows.Forms.DateTimePicker();
			this.lblTempo = new System.Windows.Forms.Label();
			this.lblTotalTime = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.datagridHist)).BeginInit();
			this.SuspendLayout();
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUser.Location = new System.Drawing.Point(33, 13);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(53, 15);
			this.lblUser.TabIndex = 0;
			this.lblUser.Text = "Usuário:";
			// 
			// lblComp
			// 
			this.lblComp.AutoSize = true;
			this.lblComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblComp.Location = new System.Drawing.Point(33, 42);
			this.lblComp.Name = "lblComp";
			this.lblComp.Size = new System.Drawing.Size(78, 15);
			this.lblComp.TabIndex = 1;
			this.lblComp.Text = "Computador:";
			// 
			// lblData
			// 
			this.lblData.AutoSize = true;
			this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblData.Location = new System.Drawing.Point(262, 13);
			this.lblData.Name = "lblData";
			this.lblData.Size = new System.Drawing.Size(36, 15);
			this.lblData.TabIndex = 2;
			this.lblData.Text = "Data:";
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(117, 12);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(110, 20);
			this.txtUser.TabIndex = 1;
			this.txtUser.Validated += new System.EventHandler(this.txtUser_TextChanged);
			// 
			// txtComp
			// 
			this.txtComp.Location = new System.Drawing.Point(117, 41);
			this.txtComp.Name = "txtComp";
			this.txtComp.Size = new System.Drawing.Size(110, 20);
			this.txtComp.TabIndex = 2;
			this.txtComp.TextChanged += new System.EventHandler(this.txtComp_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(284, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "a";
			// 
			// datagridHist
			// 
			this.datagridHist.AllowUserToAddRows = false;
			this.datagridHist.AllowUserToDeleteRows = false;
			this.datagridHist.AllowUserToOrderColumns = true;
			this.datagridHist.AllowUserToResizeRows = false;
			this.datagridHist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.datagridHist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.datagridHist.Location = new System.Drawing.Point(10, 71);
			this.datagridHist.Margin = new System.Windows.Forms.Padding(10);
			this.datagridHist.Name = "datagridHist";
			this.datagridHist.ReadOnly = true;
			this.datagridHist.Size = new System.Drawing.Size(592, 441);
			this.datagridHist.TabIndex = 5;
			// 
			// dtp1
			// 
			this.dtp1.Location = new System.Drawing.Point(304, 12);
			this.dtp1.Name = "dtp1";
			this.dtp1.Size = new System.Drawing.Size(227, 20);
			this.dtp1.TabIndex = 3;
			this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
			// 
			// dtp2
			// 
			this.dtp2.Location = new System.Drawing.Point(304, 42);
			this.dtp2.Name = "dtp2";
			this.dtp2.Size = new System.Drawing.Size(227, 20);
			this.dtp2.TabIndex = 4;
			this.dtp2.ValueChanged += new System.EventHandler(this.dtp2_ValueChanged);
			// 
			// lblTempo
			// 
			this.lblTempo.AutoSize = true;
			this.lblTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTempo.Location = new System.Drawing.Point(300, 522);
			this.lblTempo.Name = "lblTempo";
			this.lblTempo.Size = new System.Drawing.Size(134, 24);
			this.lblTempo.TabIndex = 0;
			this.lblTempo.Text = "Tempo Total:";
			// 
			// lblTotalTime
			// 
			this.lblTotalTime.AutoSize = true;
			this.lblTotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalTime.ForeColor = System.Drawing.Color.RoyalBlue;
			this.lblTotalTime.Location = new System.Drawing.Point(447, 525);
			this.lblTotalTime.Name = "lblTotalTime";
			this.lblTotalTime.Size = new System.Drawing.Size(0, 20);
			this.lblTotalTime.TabIndex = 7;
			// 
			// histForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(612, 561);
			this.Controls.Add(this.lblTotalTime);
			this.Controls.Add(this.lblTempo);
			this.Controls.Add(this.dtp2);
			this.Controls.Add(this.dtp1);
			this.Controls.Add(this.datagridHist);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtComp);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.lblData);
			this.Controls.Add(this.lblComp);
			this.Controls.Add(this.lblUser);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "histForm";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Consultar histórico de sessões";
			this.Load += new System.EventHandler(this.histForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.datagridHist)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtComp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView datagridHist;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Label lblTempo;
		private System.Windows.Forms.Label lblTotalTime;
    }
}