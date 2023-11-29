namespace PayRollPor
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.RegisterBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.UserTb = new System.Windows.Forms.TextBox();
            this.PasswordTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.ShowPasswordCb = new System.Windows.Forms.CheckBox();
            this.Close = new System.Windows.Forms.PictureBox();
            this.ConfirmPassTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ClearBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label4 = new System.Windows.Forms.Label();
            this.BackLoginLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).BeginInit();
            this.SuspendLayout();
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.ActiveBorderThickness = 1;
            this.RegisterBtn.ActiveCornerRadius = 20;
            this.RegisterBtn.ActiveFillColor = System.Drawing.Color.Olive;
            this.RegisterBtn.ActiveForecolor = System.Drawing.SystemColors.WindowFrame;
            this.RegisterBtn.ActiveLineColor = System.Drawing.Color.Silver;
            this.RegisterBtn.BackColor = System.Drawing.Color.White;
            this.RegisterBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RegisterBtn.BackgroundImage")));
            this.RegisterBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RegisterBtn.ButtonText = "Registrar";
            this.RegisterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterBtn.ForeColor = System.Drawing.Color.Black;
            this.RegisterBtn.IdleBorderThickness = 1;
            this.RegisterBtn.IdleCornerRadius = 20;
            this.RegisterBtn.IdleFillColor = System.Drawing.Color.DarkOrange;
            this.RegisterBtn.IdleForecolor = System.Drawing.Color.SeaShell;
            this.RegisterBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.RegisterBtn.Location = new System.Drawing.Point(334, 307);
            this.RegisterBtn.Margin = new System.Windows.Forms.Padding(5);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(106, 40);
            this.RegisterBtn.TabIndex = 51;
            this.RegisterBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // UserTb
            // 
            this.UserTb.Location = new System.Drawing.Point(239, 144);
            this.UserTb.Name = "UserTb";
            this.UserTb.Size = new System.Drawing.Size(296, 20);
            this.UserTb.TabIndex = 50;
            // 
            // PasswordTb
            // 
            this.PasswordTb.Location = new System.Drawing.Point(239, 199);
            this.PasswordTb.Name = "PasswordTb";
            this.PasswordTb.Size = new System.Drawing.Size(296, 20);
            this.PasswordTb.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Adobe Heiti Std R", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(235, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "Senha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Adobe Heiti Std R", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(235, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 47;
            this.label2.Text = "Usuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(360, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Heiti Std R", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(319, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 30);
            this.label1.TabIndex = 45;
            this.label1.Text = "PayRollPro";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 463);
            this.panel1.TabIndex = 44;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // ShowPasswordCb
            // 
            this.ShowPasswordCb.AutoSize = true;
            this.ShowPasswordCb.Location = new System.Drawing.Point(239, 225);
            this.ShowPasswordCb.Name = "ShowPasswordCb";
            this.ShowPasswordCb.Size = new System.Drawing.Size(95, 17);
            this.ShowPasswordCb.TabIndex = 53;
            this.ShowPasswordCb.Text = "Mostrar Senha";
            this.ShowPasswordCb.UseVisualStyleBackColor = true;
            this.ShowPasswordCb.CheckedChanged += new System.EventHandler(this.ShowPasswordCb_CheckedChanged);
            // 
            // Close
            // 
            this.Close.Image = ((System.Drawing.Image)(resources.GetObject("Close.Image")));
            this.Close.Location = new System.Drawing.Point(536, 12);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(51, 31);
            this.Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Close.TabIndex = 52;
            this.Close.TabStop = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // ConfirmPassTb
            // 
            this.ConfirmPassTb.Location = new System.Drawing.Point(239, 274);
            this.ConfirmPassTb.Name = "ConfirmPassTb";
            this.ConfirmPassTb.Size = new System.Drawing.Size(296, 20);
            this.ConfirmPassTb.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Adobe Heiti Std R", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(235, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 20);
            this.label5.TabIndex = 54;
            this.label5.Text = "Confirmar Senha";
            // 
            // ClearBtn
            // 
            this.ClearBtn.ActiveBorderThickness = 1;
            this.ClearBtn.ActiveCornerRadius = 20;
            this.ClearBtn.ActiveFillColor = System.Drawing.Color.Olive;
            this.ClearBtn.ActiveForecolor = System.Drawing.SystemColors.WindowFrame;
            this.ClearBtn.ActiveLineColor = System.Drawing.Color.Silver;
            this.ClearBtn.BackColor = System.Drawing.Color.White;
            this.ClearBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ClearBtn.BackgroundImage")));
            this.ClearBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClearBtn.ButtonText = "Limpar";
            this.ClearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.Black;
            this.ClearBtn.IdleBorderThickness = 1;
            this.ClearBtn.IdleCornerRadius = 20;
            this.ClearBtn.IdleFillColor = System.Drawing.Color.DarkOrange;
            this.ClearBtn.IdleForecolor = System.Drawing.Color.SeaShell;
            this.ClearBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClearBtn.Location = new System.Drawing.Point(334, 357);
            this.ClearBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(106, 40);
            this.ClearBtn.TabIndex = 58;
            this.ClearBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Ja possui uma conta?";
            // 
            // BackLoginLbl
            // 
            this.BackLoginLbl.AutoSize = true;
            this.BackLoginLbl.BackColor = System.Drawing.SystemColors.Window;
            this.BackLoginLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackLoginLbl.ForeColor = System.Drawing.Color.DarkOrange;
            this.BackLoginLbl.Location = new System.Drawing.Point(308, 434);
            this.BackLoginLbl.Name = "BackLoginLbl";
            this.BackLoginLbl.Size = new System.Drawing.Size(158, 13);
            this.BackLoginLbl.TabIndex = 60;
            this.BackLoginLbl.Text = "Voltar para a tela de Login";
            this.BackLoginLbl.Click += new System.EventHandler(this.BackLoginLbl_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 463);
            this.Controls.Add(this.BackLoginLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.ConfirmPassTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RegisterBtn);
            this.Controls.Add(this.UserTb);
            this.Controls.Add(this.PasswordTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ShowPasswordCb);
            this.Controls.Add(this.Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuThinButton2 RegisterBtn;
        private System.Windows.Forms.TextBox UserTb;
        private System.Windows.Forms.TextBox PasswordTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.CheckBox ShowPasswordCb;
        private System.Windows.Forms.PictureBox Close;
        private System.Windows.Forms.TextBox ConfirmPassTb;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuThinButton2 ClearBtn;
        private System.Windows.Forms.Label BackLoginLbl;
        private System.Windows.Forms.Label label4;
    }
}