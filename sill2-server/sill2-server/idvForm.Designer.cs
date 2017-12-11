namespace sill2_server
{
    partial class idvForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(idvForm));
			this.lblSegs = new System.Windows.Forms.Label();
			this.txtTime = new System.Windows.Forms.TextBox();
			this.lblTime = new System.Windows.Forms.Label();
			this.cmbSign = new System.Windows.Forms.ComboBox();
			this.lblSign = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSendSignal = new System.Windows.Forms.Button();
			this.lblLab = new System.Windows.Forms.Label();
			this.txtMaq = new System.Windows.Forms.TextBox();
			this.lblMsg = new System.Windows.Forms.Label();
			this.txtMsg = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblSegs
			// 
			this.lblSegs.AutoSize = true;
			this.lblSegs.Location = new System.Drawing.Point(206, 80);
			this.lblSegs.Name = "lblSegs";
			this.lblSegs.Size = new System.Drawing.Size(53, 13);
			this.lblSegs.TabIndex = 13;
			this.lblSegs.Text = "segundos";
			// 
			// txtTime
			// 
			this.txtTime.Location = new System.Drawing.Point(151, 77);
			this.txtTime.Name = "txtTime";
			this.txtTime.Size = new System.Drawing.Size(49, 20);
			this.txtTime.TabIndex = 3;
			// 
			// lblTime
			// 
			this.lblTime.AutoSize = true;
			this.lblTime.Location = new System.Drawing.Point(12, 80);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(96, 13);
			this.lblTime.TabIndex = 11;
			this.lblTime.Text = "Tempo para envio:";
			// 
			// cmbSign
			// 
			this.cmbSign.FormattingEnabled = true;
			this.cmbSign.Location = new System.Drawing.Point(151, 46);
			this.cmbSign.Name = "cmbSign";
			this.cmbSign.Size = new System.Drawing.Size(138, 21);
			this.cmbSign.TabIndex = 2;
			this.cmbSign.SelectedIndexChanged += new System.EventHandler(this.cmbSign_SelectedIndexChanged);
			// 
			// lblSign
			// 
			this.lblSign.AutoSize = true;
			this.lblSign.Location = new System.Drawing.Point(12, 49);
			this.lblSign.Name = "lblSign";
			this.lblSign.Size = new System.Drawing.Size(131, 13);
			this.lblSign.TabIndex = 7;
			this.lblSign.Text = "Selecione o sinal a enviar:";
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Image = global::sill2_server.Properties.Resources.cancel_icon;
			this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancel.Location = new System.Drawing.Point(12, 228);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Padding = new System.Windows.Forms.Padding(3, 0, 5, 0);
			this.btnCancel.Size = new System.Drawing.Size(115, 70);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Abortar Sinal";
			this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSendSignal
			// 
			this.btnSendSignal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSendSignal.Image = global::sill2_server.Properties.Resources.ok_icon;
			this.btnSendSignal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSendSignal.Location = new System.Drawing.Point(176, 228);
			this.btnSendSignal.Name = "btnSendSignal";
			this.btnSendSignal.Padding = new System.Windows.Forms.Padding(7, 0, 5, 0);
			this.btnSendSignal.Size = new System.Drawing.Size(115, 70);
			this.btnSendSignal.TabIndex = 5;
			this.btnSendSignal.Text = "Enviar Sinal";
			this.btnSendSignal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSendSignal.UseVisualStyleBackColor = true;
			this.btnSendSignal.Click += new System.EventHandler(this.btnSendSignal_Click);
			// 
			// lblLab
			// 
			this.lblLab.AutoSize = true;
			this.lblLab.Location = new System.Drawing.Point(12, 18);
			this.lblLab.Name = "lblLab";
			this.lblLab.Size = new System.Drawing.Size(96, 13);
			this.lblLab.TabIndex = 14;
			this.lblLab.Text = "Nome da máquina:";
			// 
			// txtMaq
			// 
			this.txtMaq.Location = new System.Drawing.Point(151, 15);
			this.txtMaq.MaxLength = 256;
			this.txtMaq.Name = "txtMaq";
			this.txtMaq.Size = new System.Drawing.Size(138, 20);
			this.txtMaq.TabIndex = 1;
			// 
			// lblMsg
			// 
			this.lblMsg.AutoSize = true;
			this.lblMsg.Location = new System.Drawing.Point(12, 110);
			this.lblMsg.Name = "lblMsg";
			this.lblMsg.Size = new System.Drawing.Size(67, 13);
			this.lblMsg.TabIndex = 16;
			this.lblMsg.Text = "Menssagem:";
			// 
			// txtMsg
			// 
			this.txtMsg.Location = new System.Drawing.Point(15, 126);
			this.txtMsg.Multiline = true;
			this.txtMsg.Name = "txtMsg";
			this.txtMsg.Size = new System.Drawing.Size(274, 82);
			this.txtMsg.TabIndex = 4;
			// 
			// idvForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(303, 310);
			this.Controls.Add(this.txtMsg);
			this.Controls.Add(this.lblMsg);
			this.Controls.Add(this.txtMaq);
			this.Controls.Add(this.lblLab);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSendSignal);
			this.Controls.Add(this.lblSegs);
			this.Controls.Add(this.txtTime);
			this.Controls.Add(this.lblTime);
			this.Controls.Add(this.cmbSign);
			this.Controls.Add(this.lblSign);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "idvForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Controle Individual de Máquinas e Usuários";
			this.Load += new System.EventHandler(this.idvForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSendSignal;
        private System.Windows.Forms.Label lblSegs;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox cmbSign;
        private System.Windows.Forms.Label lblSign;
        private System.Windows.Forms.Label lblLab;
        private System.Windows.Forms.TextBox txtMaq;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtMsg;
    }
}