namespace SchoolLibrary
{
    partial class Notifications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notifications));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEntregue = new System.Windows.Forms.Button();
            this.btnRecusar = new System.Windows.Forms.Button();
            this.btnAceitar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPendentes = new System.Windows.Forms.TabPage();
            this.dgvPendentes = new System.Windows.Forms.DataGridView();
            this.tpEntregas = new System.Windows.Forms.TabPage();
            this.dgvEntregas = new System.Windows.Forms.DataGridView();
            this.tpHistorico = new System.Windows.Forms.TabPage();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpPendentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendentes)).BeginInit();
            this.tpEntregas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregas)).BeginInit();
            this.tpHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnEntregue);
            this.panel1.Controls.Add(this.btnRecusar);
            this.panel1.Controls.Add(this.btnAceitar);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.lblHour);
            this.panel1.Controls.Add(this.lblDay);
            this.panel1.Location = new System.Drawing.Point(53, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 441);
            this.panel1.TabIndex = 3;
            // 
            // btnEntregue
            // 
            this.btnEntregue.BackColor = System.Drawing.Color.Green;
            this.btnEntregue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntregue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntregue.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnEntregue.Location = new System.Drawing.Point(578, 63);
            this.btnEntregue.Name = "btnEntregue";
            this.btnEntregue.Size = new System.Drawing.Size(80, 37);
            this.btnEntregue.TabIndex = 24;
            this.btnEntregue.Text = "Entregue";
            this.btnEntregue.UseVisualStyleBackColor = false;
            this.btnEntregue.Click += new System.EventHandler(this.btnEntregue_Click);
            // 
            // btnRecusar
            // 
            this.btnRecusar.BackColor = System.Drawing.Color.Red;
            this.btnRecusar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecusar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecusar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnRecusar.Location = new System.Drawing.Point(578, 63);
            this.btnRecusar.Name = "btnRecusar";
            this.btnRecusar.Size = new System.Drawing.Size(80, 37);
            this.btnRecusar.TabIndex = 23;
            this.btnRecusar.Text = "Recusar";
            this.btnRecusar.UseVisualStyleBackColor = false;
            this.btnRecusar.Click += new System.EventHandler(this.btnRecusar_Click);
            // 
            // btnAceitar
            // 
            this.btnAceitar.BackColor = System.Drawing.Color.Green;
            this.btnAceitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceitar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnAceitar.Location = new System.Drawing.Point(490, 63);
            this.btnAceitar.Name = "btnAceitar";
            this.btnAceitar.Size = new System.Drawing.Size(73, 37);
            this.btnAceitar.TabIndex = 22;
            this.btnAceitar.Text = "Aceitar";
            this.btnAceitar.UseVisualStyleBackColor = false;
            this.btnAceitar.Click += new System.EventHandler(this.btnAceitar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPendentes);
            this.tabControl1.Controls.Add(this.tpEntregas);
            this.tabControl1.Controls.Add(this.tpHistorico);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(17, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(643, 335);
            this.tabControl1.TabIndex = 21;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpPendentes
            // 
            this.tpPendentes.Controls.Add(this.dgvPendentes);
            this.tpPendentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpPendentes.Location = new System.Drawing.Point(4, 29);
            this.tpPendentes.Name = "tpPendentes";
            this.tpPendentes.Padding = new System.Windows.Forms.Padding(3);
            this.tpPendentes.Size = new System.Drawing.Size(635, 302);
            this.tpPendentes.TabIndex = 0;
            this.tpPendentes.Text = "Pendentes";
            this.tpPendentes.UseVisualStyleBackColor = true;
            // 
            // dgvPendentes
            // 
            this.dgvPendentes.AllowUserToAddRows = false;
            this.dgvPendentes.AllowUserToDeleteRows = false;
            this.dgvPendentes.AllowUserToResizeColumns = false;
            this.dgvPendentes.AllowUserToResizeRows = false;
            this.dgvPendentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendentes.Location = new System.Drawing.Point(6, 6);
            this.dgvPendentes.Name = "dgvPendentes";
            this.dgvPendentes.ReadOnly = true;
            this.dgvPendentes.ShowCellErrors = false;
            this.dgvPendentes.ShowCellToolTips = false;
            this.dgvPendentes.ShowEditingIcon = false;
            this.dgvPendentes.ShowRowErrors = false;
            this.dgvPendentes.Size = new System.Drawing.Size(623, 290);
            this.dgvPendentes.TabIndex = 22;
            // 
            // tpEntregas
            // 
            this.tpEntregas.Controls.Add(this.dgvEntregas);
            this.tpEntregas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpEntregas.Location = new System.Drawing.Point(4, 29);
            this.tpEntregas.Name = "tpEntregas";
            this.tpEntregas.Padding = new System.Windows.Forms.Padding(3);
            this.tpEntregas.Size = new System.Drawing.Size(635, 302);
            this.tpEntregas.TabIndex = 1;
            this.tpEntregas.Text = "Entregas";
            this.tpEntregas.UseVisualStyleBackColor = true;
            // 
            // dgvEntregas
            // 
            this.dgvEntregas.AllowUserToAddRows = false;
            this.dgvEntregas.AllowUserToDeleteRows = false;
            this.dgvEntregas.AllowUserToResizeColumns = false;
            this.dgvEntregas.AllowUserToResizeRows = false;
            this.dgvEntregas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntregas.Location = new System.Drawing.Point(6, 6);
            this.dgvEntregas.Name = "dgvEntregas";
            this.dgvEntregas.ReadOnly = true;
            this.dgvEntregas.ShowCellErrors = false;
            this.dgvEntregas.ShowCellToolTips = false;
            this.dgvEntregas.ShowEditingIcon = false;
            this.dgvEntregas.ShowRowErrors = false;
            this.dgvEntregas.Size = new System.Drawing.Size(623, 290);
            this.dgvEntregas.TabIndex = 23;
            // 
            // tpHistorico
            // 
            this.tpHistorico.Controls.Add(this.dgvHistorico);
            this.tpHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHistorico.Location = new System.Drawing.Point(4, 29);
            this.tpHistorico.Name = "tpHistorico";
            this.tpHistorico.Size = new System.Drawing.Size(635, 302);
            this.tpHistorico.TabIndex = 2;
            this.tpHistorico.Text = "Histórico";
            this.tpHistorico.UseVisualStyleBackColor = true;
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AllowUserToDeleteRows = false;
            this.dgvHistorico.AllowUserToResizeColumns = false;
            this.dgvHistorico.AllowUserToResizeRows = false;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Location = new System.Drawing.Point(6, 6);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.ReadOnly = true;
            this.dgvHistorico.ShowCellErrors = false;
            this.dgvHistorico.ShowCellToolTips = false;
            this.dgvHistorico.ShowEditingIcon = false;
            this.dgvHistorico.ShowRowErrors = false;
            this.dgvHistorico.Size = new System.Drawing.Size(623, 290);
            this.dgvHistorico.TabIndex = 23;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Black;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnVoltar.Location = new System.Drawing.Point(17, 15);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(57, 27);
            this.btnVoltar.TabIndex = 20;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHour.Location = new System.Drawing.Point(477, 412);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(41, 18);
            this.lblHour.TabIndex = 17;
            this.lblHour.Text = "Hora";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.Location = new System.Drawing.Point(110, 412);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(39, 18);
            this.lblDay.TabIndex = 16;
            this.lblDay.Text = "Data";
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(782, 497);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Notifications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Library";
            this.Load += new System.EventHandler(this.Notifications_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpPendentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendentes)).EndInit();
            this.tpEntregas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregas)).EndInit();
            this.tpHistorico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPendentes;
        private System.Windows.Forms.TabPage tpEntregas;
        private System.Windows.Forms.DataGridView dgvPendentes;
        private System.Windows.Forms.Button btnRecusar;
        private System.Windows.Forms.Button btnAceitar;
        private System.Windows.Forms.Button btnEntregue;
        private System.Windows.Forms.DataGridView dgvEntregas;
        private System.Windows.Forms.TabPage tpHistorico;
        private System.Windows.Forms.DataGridView dgvHistorico;
    }
}