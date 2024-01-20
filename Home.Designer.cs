
namespace SchoolLibrary
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNotifications = new System.Windows.Forms.Label();
            this.btnNotification = new System.Windows.Forms.Button();
            this.btnRequisitar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtvLivros = new System.Windows.Forms.DataGridView();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblSaudacao = new System.Windows.Forms.Label();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtvLivros)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnNotification);
            this.panel1.Controls.Add(this.btnRequisitar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.dtvLivros);
            this.panel1.Controls.Add(this.lblHour);
            this.panel1.Controls.Add(this.lblDay);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.lblSaudacao);
            this.panel1.Location = new System.Drawing.Point(55, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 441);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Controls.Add(this.lblNotifications);
            this.panel2.Location = new System.Drawing.Point(585, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 20);
            this.panel2.TabIndex = 23;
            // 
            // lblNotifications
            // 
            this.lblNotifications.AutoSize = true;
            this.lblNotifications.BackColor = System.Drawing.Color.Red;
            this.lblNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifications.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblNotifications.Location = new System.Drawing.Point(2, 2);
            this.lblNotifications.Name = "lblNotifications";
            this.lblNotifications.Size = new System.Drawing.Size(0, 16);
            this.lblNotifications.TabIndex = 23;
            // 
            // btnNotification
            // 
            this.btnNotification.FlatAppearance.BorderSize = 0;
            this.btnNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotification.Image = ((System.Drawing.Image)(resources.GetObject("btnNotification.Image")));
            this.btnNotification.Location = new System.Drawing.Point(566, 16);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(34, 32);
            this.btnNotification.TabIndex = 22;
            this.btnNotification.UseVisualStyleBackColor = true;
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // btnRequisitar
            // 
            this.btnRequisitar.BackColor = System.Drawing.Color.Black;
            this.btnRequisitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequisitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequisitar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnRequisitar.Location = new System.Drawing.Point(546, 58);
            this.btnRequisitar.Name = "btnRequisitar";
            this.btnRequisitar.Size = new System.Drawing.Size(108, 26);
            this.btnRequisitar.TabIndex = 21;
            this.btnRequisitar.Text = "Requisitar";
            this.btnRequisitar.UseVisualStyleBackColor = false;
            this.btnRequisitar.Click += new System.EventHandler(this.btnRequisitar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(506, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 18);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Silver;
            this.txtSearch.Location = new System.Drawing.Point(26, 60);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(503, 24);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.Text = "Procure por título ou autor";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // dtvLivros
            // 
            this.dtvLivros.AllowUserToAddRows = false;
            this.dtvLivros.AllowUserToDeleteRows = false;
            this.dtvLivros.AllowUserToResizeColumns = false;
            this.dtvLivros.AllowUserToResizeRows = false;
            this.dtvLivros.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtvLivros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvLivros.Location = new System.Drawing.Point(26, 93);
            this.dtvLivros.Name = "dtvLivros";
            this.dtvLivros.ReadOnly = true;
            this.dtvLivros.RowHeadersVisible = false;
            this.dtvLivros.ShowCellErrors = false;
            this.dtvLivros.ShowCellToolTips = false;
            this.dtvLivros.ShowEditingIcon = false;
            this.dtvLivros.ShowRowErrors = false;
            this.dtvLivros.Size = new System.Drawing.Size(628, 307);
            this.dtvLivros.TabIndex = 18;
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
            // btnLogOut
            // 
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.Location = new System.Drawing.Point(620, 18);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(34, 30);
            this.btnLogOut.TabIndex = 15;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblSaudacao
            // 
            this.lblSaudacao.AutoSize = true;
            this.lblSaudacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaudacao.Location = new System.Drawing.Point(21, 23);
            this.lblSaudacao.Name = "lblSaudacao";
            this.lblSaudacao.Size = new System.Drawing.Size(160, 25);
            this.lblSaudacao.TabIndex = 0;
            this.lblSaudacao.Text = "Bom dia User,";
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(782, 497);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Library";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtvLivros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSaudacao;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.DataGridView dtvLivros;
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRequisitar;
        private System.Windows.Forms.Button btnNotification;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNotifications;
    }
}