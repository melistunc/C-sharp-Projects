namespace AgendaSystem
{
    partial class Guncellecs
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
            this.pctexit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tarih = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmesaj = new System.Windows.Forms.RichTextBox();
            this.btnguncellee = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pctexit)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctexit
            // 
            this.pctexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(206)))));
            this.pctexit.Image = global::AgendaSystem.Properties.Resources.icons8_close_50;
            this.pctexit.Location = new System.Drawing.Point(765, 21);
            this.pctexit.Margin = new System.Windows.Forms.Padding(2);
            this.pctexit.Name = "pctexit";
            this.pctexit.Size = new System.Drawing.Size(45, 41);
            this.pctexit.TabIndex = 4;
            this.pctexit.TabStop = false;
            this.pctexit.Click += new System.EventHandler(this.pctexit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(206)))));
            this.label1.Location = new System.Drawing.Point(83, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bitiş Tarihi:";
            // 
            // tarih
            // 
            this.tarih.CustomFormat = "dd.MM.yyyy HH:mm";
            this.tarih.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tarih.Location = new System.Drawing.Point(292, 65);
            this.tarih.Margin = new System.Windows.Forms.Padding(2);
            this.tarih.Name = "tarih";
            this.tarih.Size = new System.Drawing.Size(390, 44);
            this.tarih.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(206)))));
            this.label2.Location = new System.Drawing.Point(83, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mesaj:";
            // 
            // txtmesaj
            // 
            this.txtmesaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.txtmesaj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmesaj.Location = new System.Drawing.Point(60, 172);
            this.txtmesaj.Margin = new System.Windows.Forms.Padding(2);
            this.txtmesaj.Name = "txtmesaj";
            this.txtmesaj.Size = new System.Drawing.Size(703, 306);
            this.txtmesaj.TabIndex = 0;
            this.txtmesaj.Text = "";
            // 
            // btnguncellee
            // 
            this.btnguncellee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(206)))));
            this.btnguncellee.FlatAppearance.BorderSize = 4;
            this.btnguncellee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguncellee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(206)))));
            this.btnguncellee.Location = new System.Drawing.Point(277, 482);
            this.btnguncellee.Margin = new System.Windows.Forms.Padding(2);
            this.btnguncellee.Name = "btnguncellee";
            this.btnguncellee.Size = new System.Drawing.Size(284, 74);
            this.btnguncellee.TabIndex = 2;
            this.btnguncellee.Text = "Güncelle";
            this.btnguncellee.UseVisualStyleBackColor = true;
            this.btnguncellee.Click += new System.EventHandler(this.btnguncellee_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumPurple;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 8);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumPurple;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 8);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumPurple;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(830, 8);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumPurple;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(830, 8);
            this.panel4.TabIndex = 11;
            // 
            // Guncellecs
            // 
            this.AcceptButton = this.btnguncellee;
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(830, 587);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnguncellee);
            this.Controls.Add(this.txtmesaj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tarih);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pctexit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Guncellecs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guncellecs";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Guncellecs_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Guncellecs_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pctexit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctexit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker tarih;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtmesaj;
        private System.Windows.Forms.Button btnguncellee;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}