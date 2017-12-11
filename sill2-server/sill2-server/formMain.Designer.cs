namespace sill2_server
{
	partial class formMain
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
			this.loggedLabel = new System.Windows.Forms.Label();
			this.loggedBox = new System.Windows.Forms.ListBox();
			this.freeuserBox = new System.Windows.Forms.ListBox();
			this.btnAddFree = new System.Windows.Forms.Button();
			this.freeLabel = new System.Windows.Forms.Label();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mostarJanelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lebalPesqUser = new System.Windows.Forms.Label();
			this.txtbxPesqUser = new System.Windows.Forms.TextBox();
			this.btnPesqUser = new System.Windows.Forms.Button();
			this.btnPesqComp = new System.Windows.Forms.Button();
			this.txtbxPesqComp = new System.Windows.Forms.TextBox();
			this.labelPesqComp = new System.Windows.Forms.Label();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.grpBoxLists = new System.Windows.Forms.GroupBox();
			this.brpBoxAddUserFree = new System.Windows.Forms.GroupBox();
			this.txtbxAddFreeUser = new System.Windows.Forms.TextBox();
			this.bntAddFreeUser = new System.Windows.Forms.Button();
			this.grpBoxCtrls = new System.Windows.Forms.GroupBox();
			this.btnMonit = new System.Windows.Forms.Button();
			this.btnHistForm = new System.Windows.Forms.Button();
			this.btnIdvForm = new System.Windows.Forms.Button();
			this.btnMntForm = new System.Windows.Forms.Button();
			this.grpBoxPesquisa = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnUnblock = new System.Windows.Forms.Button();
			this.txtbxBlocked = new System.Windows.Forms.TextBox();
			this.lblUserBlocked = new System.Windows.Forms.Label();
			this.lblDeveloper = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnClient = new System.Windows.Forms.Button();
			this.txtbxClient = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnDelFree = new System.Windows.Forms.Button();
			this.contextMenu.SuspendLayout();
			this.grpBoxLists.SuspendLayout();
			this.brpBoxAddUserFree.SuspendLayout();
			this.grpBoxCtrls.SuspendLayout();
			this.grpBoxPesquisa.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// loggedLabel
			// 
			this.loggedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.loggedLabel.AutoSize = true;
			this.loggedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loggedLabel.Location = new System.Drawing.Point(6, 16);
			this.loggedLabel.Name = "loggedLabel";
			this.loggedLabel.Size = new System.Drawing.Size(110, 15);
			this.loggedLabel.TabIndex = 0;
			this.loggedLabel.Text = "Usuários Logados:";
			// 
			// loggedBox
			// 
			this.loggedBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.loggedBox.FormattingEnabled = true;
			this.loggedBox.Location = new System.Drawing.Point(9, 34);
			this.loggedBox.Name = "loggedBox";
			this.loggedBox.Size = new System.Drawing.Size(177, 615);
			this.loggedBox.TabIndex = 1;
			this.loggedBox.SelectedValueChanged += new System.EventHandler(this.loggedBox_SelectedValueChanged);
			// 
			// freeuserBox
			// 
			this.freeuserBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.freeuserBox.FormattingEnabled = true;
			this.freeuserBox.Location = new System.Drawing.Point(237, 34);
			this.freeuserBox.Name = "freeuserBox";
			this.freeuserBox.Size = new System.Drawing.Size(190, 511);
			this.freeuserBox.TabIndex = 2;
			this.freeuserBox.SelectedIndexChanged += new System.EventHandler(this.freeuserBox_SelectedIndexChanged);
			// 
			// btnAddFree
			// 
			this.btnAddFree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddFree.Location = new System.Drawing.Point(192, 121);
			this.btnAddFree.Name = "btnAddFree";
			this.btnAddFree.Size = new System.Drawing.Size(39, 23);
			this.btnAddFree.TabIndex = 3;
			this.btnAddFree.Text = ">>";
			this.btnAddFree.UseVisualStyleBackColor = true;
			this.btnAddFree.Click += new System.EventHandler(this.btnAddFree_Click);
			// 
			// freeLabel
			// 
			this.freeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.freeLabel.AutoSize = true;
			this.freeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.freeLabel.Location = new System.Drawing.Point(234, 16);
			this.freeLabel.Name = "freeLabel";
			this.freeLabel.Size = new System.Drawing.Size(182, 15);
			this.freeLabel.TabIndex = 5;
			this.freeLabel.Text = "Usuários de Sessões Ilimitadas:";
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostarJanelaToolStripMenuItem,
            this.sairToolStripMenuItem});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(147, 48);
			// 
			// mostarJanelaToolStripMenuItem
			// 
			this.mostarJanelaToolStripMenuItem.Name = "mostarJanelaToolStripMenuItem";
			this.mostarJanelaToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.mostarJanelaToolStripMenuItem.Text = "Mostar Janela";
			this.mostarJanelaToolStripMenuItem.Click += new System.EventHandler(this.mostarJanelaToolStripMenuItem_Click);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.sairToolStripMenuItem.Text = "Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// lebalPesqUser
			// 
			this.lebalPesqUser.AutoSize = true;
			this.lebalPesqUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lebalPesqUser.Location = new System.Drawing.Point(31, 16);
			this.lebalPesqUser.Name = "lebalPesqUser";
			this.lebalPesqUser.Size = new System.Drawing.Size(111, 15);
			this.lebalPesqUser.TabIndex = 6;
			this.lebalPesqUser.Text = "Pesquisar Usuário:";
			// 
			// txtbxPesqUser
			// 
			this.txtbxPesqUser.Location = new System.Drawing.Point(148, 15);
			this.txtbxPesqUser.MaxLength = 64;
			this.txtbxPesqUser.Name = "txtbxPesqUser";
			this.txtbxPesqUser.Size = new System.Drawing.Size(113, 20);
			this.txtbxPesqUser.TabIndex = 7;
			// 
			// btnPesqUser
			// 
			this.btnPesqUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPesqUser.Location = new System.Drawing.Point(267, 12);
			this.btnPesqUser.Name = "btnPesqUser";
			this.btnPesqUser.Size = new System.Drawing.Size(75, 23);
			this.btnPesqUser.TabIndex = 8;
			this.btnPesqUser.Text = "Pesquisar";
			this.btnPesqUser.UseVisualStyleBackColor = true;
			this.btnPesqUser.Click += new System.EventHandler(this.btnPesqUser_Click);
			// 
			// btnPesqComp
			// 
			this.btnPesqComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPesqComp.Location = new System.Drawing.Point(267, 48);
			this.btnPesqComp.Name = "btnPesqComp";
			this.btnPesqComp.Size = new System.Drawing.Size(75, 23);
			this.btnPesqComp.TabIndex = 11;
			this.btnPesqComp.Text = "Pesquisar";
			this.btnPesqComp.UseVisualStyleBackColor = true;
			this.btnPesqComp.Click += new System.EventHandler(this.btnPesqComp_Click);
			// 
			// txtbxPesqComp
			// 
			this.txtbxPesqComp.Location = new System.Drawing.Point(148, 51);
			this.txtbxPesqComp.MaxLength = 64;
			this.txtbxPesqComp.Name = "txtbxPesqComp";
			this.txtbxPesqComp.Size = new System.Drawing.Size(113, 20);
			this.txtbxPesqComp.TabIndex = 10;
			// 
			// labelPesqComp
			// 
			this.labelPesqComp.AutoSize = true;
			this.labelPesqComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPesqComp.Location = new System.Drawing.Point(6, 52);
			this.labelPesqComp.Name = "labelPesqComp";
			this.labelPesqComp.Size = new System.Drawing.Size(136, 15);
			this.labelPesqComp.TabIndex = 9;
			this.labelPesqComp.Text = "Pesquisar Computador:";
			// 
			// trayIcon
			// 
			this.trayIcon.Text = "trayIcon";
			this.trayIcon.Visible = true;
			// 
			// grpBoxLists
			// 
			this.grpBoxLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.grpBoxLists.AutoSize = true;
			this.grpBoxLists.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.grpBoxLists.Controls.Add(this.brpBoxAddUserFree);
			this.grpBoxLists.Controls.Add(this.loggedBox);
			this.grpBoxLists.Controls.Add(this.loggedLabel);
			this.grpBoxLists.Controls.Add(this.btnAddFree);
			this.grpBoxLists.Controls.Add(this.freeuserBox);
			this.grpBoxLists.Controls.Add(this.freeLabel);
			this.grpBoxLists.Location = new System.Drawing.Point(0, 5);
			this.grpBoxLists.Name = "grpBoxLists";
			this.grpBoxLists.Size = new System.Drawing.Size(433, 680);
			this.grpBoxLists.TabIndex = 17;
			this.grpBoxLists.TabStop = false;
			this.grpBoxLists.Text = "Lista de Usuários Logados e Liberados";
			// 
			// brpBoxAddUserFree
			// 
			this.brpBoxAddUserFree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.brpBoxAddUserFree.Controls.Add(this.txtbxAddFreeUser);
			this.brpBoxAddUserFree.Controls.Add(this.bntAddFreeUser);
			this.brpBoxAddUserFree.Controls.Add(this.btnDelFree);
			this.brpBoxAddUserFree.Location = new System.Drawing.Point(237, 564);
			this.brpBoxAddUserFree.Name = "brpBoxAddUserFree";
			this.brpBoxAddUserFree.Size = new System.Drawing.Size(190, 97);
			this.brpBoxAddUserFree.TabIndex = 6;
			this.brpBoxAddUserFree.TabStop = false;
			this.brpBoxAddUserFree.Text = "Adicionar usuário livre";
			// 
			// txtbxAddFreeUser
			// 
			this.txtbxAddFreeUser.Location = new System.Drawing.Point(9, 19);
			this.txtbxAddFreeUser.Name = "txtbxAddFreeUser";
			this.txtbxAddFreeUser.Size = new System.Drawing.Size(107, 20);
			this.txtbxAddFreeUser.TabIndex = 17;
			// 
			// bntAddFreeUser
			// 
			this.bntAddFreeUser.BackColor = System.Drawing.Color.LightGreen;
			this.bntAddFreeUser.Location = new System.Drawing.Point(116, 17);
			this.bntAddFreeUser.Name = "bntAddFreeUser";
			this.bntAddFreeUser.Size = new System.Drawing.Size(68, 23);
			this.bntAddFreeUser.TabIndex = 18;
			this.bntAddFreeUser.Text = "Adicionar";
			this.bntAddFreeUser.UseVisualStyleBackColor = false;
			this.bntAddFreeUser.Click += new System.EventHandler(this.bntAddFreeUser_Click);
			// 
			// grpBoxCtrls
			// 
			this.grpBoxCtrls.AutoSize = true;
			this.grpBoxCtrls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.grpBoxCtrls.Controls.Add(this.btnMonit);
			this.grpBoxCtrls.Controls.Add(this.btnHistForm);
			this.grpBoxCtrls.Controls.Add(this.btnIdvForm);
			this.grpBoxCtrls.Controls.Add(this.btnMntForm);
			this.grpBoxCtrls.Location = new System.Drawing.Point(440, 247);
			this.grpBoxCtrls.Name = "grpBoxCtrls";
			this.grpBoxCtrls.Size = new System.Drawing.Size(348, 236);
			this.grpBoxCtrls.TabIndex = 18;
			this.grpBoxCtrls.TabStop = false;
			this.grpBoxCtrls.Text = "Controle de Máquinas e Laboratórios";
			// 
			// btnMonit
			// 
			this.btnMonit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMonit.Image = global::sill2_server.Properties.Resources.monitor_icon;
			this.btnMonit.Location = new System.Drawing.Point(177, 19);
			this.btnMonit.Name = "btnMonit";
			this.btnMonit.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.btnMonit.Size = new System.Drawing.Size(165, 96);
			this.btnMonit.TabIndex = 18;
			this.btnMonit.Text = "Monitorar por Laboratório";
			this.btnMonit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMonit.UseVisualStyleBackColor = true;
			this.btnMonit.Click += new System.EventHandler(this.btnMonit_Click);
			// 
			// btnHistForm
			// 
			this.btnHistForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.btnHistForm.Image = ((System.Drawing.Image)(resources.GetObject("btnHistForm.Image")));
			this.btnHistForm.Location = new System.Drawing.Point(177, 121);
			this.btnHistForm.Name = "btnHistForm";
			this.btnHistForm.Size = new System.Drawing.Size(165, 96);
			this.btnHistForm.TabIndex = 17;
			this.btnHistForm.Text = "Consultar Histórico";
			this.btnHistForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnHistForm.UseVisualStyleBackColor = true;
			this.btnHistForm.Click += new System.EventHandler(this.btnHistForm_Click);
			// 
			// btnIdvForm
			// 
			this.btnIdvForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnIdvForm.Image = global::sill2_server.Properties.Resources.computer_icon;
			this.btnIdvForm.Location = new System.Drawing.Point(6, 121);
			this.btnIdvForm.Name = "btnIdvForm";
			this.btnIdvForm.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.btnIdvForm.Size = new System.Drawing.Size(165, 96);
			this.btnIdvForm.TabIndex = 16;
			this.btnIdvForm.Text = "Controle Individual";
			this.btnIdvForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnIdvForm.UseVisualStyleBackColor = true;
			this.btnIdvForm.Click += new System.EventHandler(this.btnIdvForm_Click);
			// 
			// btnMntForm
			// 
			this.btnMntForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMntForm.Image = global::sill2_server.Properties.Resources.config_icon;
			this.btnMntForm.Location = new System.Drawing.Point(6, 19);
			this.btnMntForm.Name = "btnMntForm";
			this.btnMntForm.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.btnMntForm.Size = new System.Drawing.Size(165, 96);
			this.btnMntForm.TabIndex = 12;
			this.btnMntForm.Text = "Manutenção de Laboratórios";
			this.btnMntForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMntForm.UseVisualStyleBackColor = true;
			this.btnMntForm.Click += new System.EventHandler(this.btnMntForm_Click);
			// 
			// grpBoxPesquisa
			// 
			this.grpBoxPesquisa.AutoSize = true;
			this.grpBoxPesquisa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.grpBoxPesquisa.Controls.Add(this.txtbxPesqComp);
			this.grpBoxPesquisa.Controls.Add(this.lebalPesqUser);
			this.grpBoxPesquisa.Controls.Add(this.txtbxPesqUser);
			this.grpBoxPesquisa.Controls.Add(this.btnPesqUser);
			this.grpBoxPesquisa.Controls.Add(this.labelPesqComp);
			this.grpBoxPesquisa.Controls.Add(this.btnPesqComp);
			this.grpBoxPesquisa.Location = new System.Drawing.Point(440, 5);
			this.grpBoxPesquisa.Name = "grpBoxPesquisa";
			this.grpBoxPesquisa.Size = new System.Drawing.Size(348, 90);
			this.grpBoxPesquisa.TabIndex = 19;
			this.grpBoxPesquisa.TabStop = false;
			this.grpBoxPesquisa.Text = "Pesquisa de Usuário e Máquina";
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSize = true;
			this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox1.Controls.Add(this.btnUnblock);
			this.groupBox1.Controls.Add(this.txtbxBlocked);
			this.groupBox1.Controls.Add(this.lblUserBlocked);
			this.groupBox1.Location = new System.Drawing.Point(440, 102);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(348, 63);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Liberar Usuário Preso";
			// 
			// btnUnblock
			// 
			this.btnUnblock.Location = new System.Drawing.Point(267, 21);
			this.btnUnblock.Name = "btnUnblock";
			this.btnUnblock.Size = new System.Drawing.Size(75, 23);
			this.btnUnblock.TabIndex = 2;
			this.btnUnblock.Text = "Liberar";
			this.btnUnblock.UseVisualStyleBackColor = true;
			this.btnUnblock.Click += new System.EventHandler(this.btnUnblock_Click);
			// 
			// txtbxBlocked
			// 
			this.txtbxBlocked.Location = new System.Drawing.Point(148, 23);
			this.txtbxBlocked.Name = "txtbxBlocked";
			this.txtbxBlocked.Size = new System.Drawing.Size(113, 20);
			this.txtbxBlocked.TabIndex = 1;
			// 
			// lblUserBlocked
			// 
			this.lblUserBlocked.AutoSize = true;
			this.lblUserBlocked.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUserBlocked.Location = new System.Drawing.Point(89, 24);
			this.lblUserBlocked.Name = "lblUserBlocked";
			this.lblUserBlocked.Size = new System.Drawing.Size(53, 15);
			this.lblUserBlocked.TabIndex = 0;
			this.lblUserBlocked.Text = "Usuário:";
			// 
			// lblDeveloper
			// 
			this.lblDeveloper.AutoSize = true;
			this.lblDeveloper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDeveloper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lblDeveloper.Location = new System.Drawing.Point(471, 600);
			this.lblDeveloper.Name = "lblDeveloper";
			this.lblDeveloper.Size = new System.Drawing.Size(88, 15);
			this.lblDeveloper.TabIndex = 21;
			this.lblDeveloper.Text = "lblDeveloper";
			// 
			// groupBox2
			// 
			this.groupBox2.AutoSize = true;
			this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox2.Controls.Add(this.btnClient);
			this.groupBox2.Controls.Add(this.txtbxClient);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(440, 178);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(348, 63);
			this.groupBox2.TabIndex = 22;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Executar SILL2 Client Remotamente";
			this.groupBox2.Visible = false;
			// 
			// btnClient
			// 
			this.btnClient.Location = new System.Drawing.Point(267, 21);
			this.btnClient.Name = "btnClient";
			this.btnClient.Size = new System.Drawing.Size(75, 23);
			this.btnClient.TabIndex = 2;
			this.btnClient.Text = "Executar";
			this.btnClient.UseVisualStyleBackColor = true;
			this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
			// 
			// txtbxClient
			// 
			this.txtbxClient.Location = new System.Drawing.Point(148, 23);
			this.txtbxClient.Name = "txtbxClient";
			this.txtbxClient.Size = new System.Drawing.Size(113, 20);
			this.txtbxClient.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(64, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Computador:";
			// 
			// btnDelFree
			// 
			this.btnDelFree.BackColor = System.Drawing.Color.LightCoral;
			this.btnDelFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelFree.Location = new System.Drawing.Point(9, 56);
			this.btnDelFree.Name = "btnDelFree";
			this.btnDelFree.Size = new System.Drawing.Size(175, 23);
			this.btnDelFree.TabIndex = 4;
			this.btnDelFree.Text = "Remover selecionados";
			this.btnDelFree.UseVisualStyleBackColor = false;
			this.btnDelFree.Click += new System.EventHandler(this.btnDelFree_Click);
			// 
			// formMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(798, 685);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.grpBoxLists);
			this.Controls.Add(this.grpBoxPesquisa);
			this.Controls.Add(this.lblDeveloper);
			this.Controls.Add(this.grpBoxCtrls);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "formMain";
			this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sistema Individual LimitLogin2";
			this.Load += new System.EventHandler(this.formMain_Load);
			this.contextMenu.ResumeLayout(false);
			this.grpBoxLists.ResumeLayout(false);
			this.grpBoxLists.PerformLayout();
			this.brpBoxAddUserFree.ResumeLayout(false);
			this.brpBoxAddUserFree.PerformLayout();
			this.grpBoxCtrls.ResumeLayout(false);
			this.grpBoxPesquisa.ResumeLayout(false);
			this.grpBoxPesquisa.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label loggedLabel;
		private System.Windows.Forms.ListBox loggedBox;
		private System.Windows.Forms.ListBox freeuserBox;
		private System.Windows.Forms.Button btnAddFree;
		private System.Windows.Forms.Label freeLabel;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem mostarJanelaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.Label lebalPesqUser;
		private System.Windows.Forms.TextBox txtbxPesqUser;
		private System.Windows.Forms.Button btnPesqUser;
		private System.Windows.Forms.Button btnPesqComp;
		private System.Windows.Forms.TextBox txtbxPesqComp;
		private System.Windows.Forms.Label labelPesqComp;
		private System.Windows.Forms.Button btnMntForm;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button btnIdvForm;
        private System.Windows.Forms.GroupBox grpBoxLists;
        private System.Windows.Forms.GroupBox grpBoxCtrls;
        private System.Windows.Forms.GroupBox grpBoxPesquisa;
        private System.Windows.Forms.Button btnHistForm;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnUnblock;
		private System.Windows.Forms.TextBox txtbxBlocked;
		private System.Windows.Forms.Label lblUserBlocked;
		private System.Windows.Forms.Label lblDeveloper;
		private System.Windows.Forms.Button btnMonit;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnClient;
		private System.Windows.Forms.TextBox txtbxClient;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox brpBoxAddUserFree;
		private System.Windows.Forms.TextBox txtbxAddFreeUser;
		private System.Windows.Forms.Button bntAddFreeUser;
		private System.Windows.Forms.Button btnDelFree;
	}
}

