namespace TurAgencijaRS2_UI.Zaposlenik
{
    partial class zaduzenjaDetailZaposlenik
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
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PutovanjaInput = new System.Windows.Forms.ComboBox();
            this.zaposlenikInput = new System.Windows.Forms.ComboBox();
            this.Zaposlenik = new System.Windows.Forms.Label();
            this.opisInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.odgođeno = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.snimi = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 38);
            this.label7.TabIndex = 15;
            this.label7.Text = "WT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.SkyBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(346, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "_";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SkyBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(363, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "X";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.SkyBlue;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(387, 15);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 47);
            this.panel2.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "WT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Putovanje";
            // 
            // PutovanjaInput
            // 
            this.PutovanjaInput.FormattingEnabled = true;
            this.PutovanjaInput.Location = new System.Drawing.Point(119, 121);
            this.PutovanjaInput.Name = "PutovanjaInput";
            this.PutovanjaInput.Size = new System.Drawing.Size(188, 21);
            this.PutovanjaInput.TabIndex = 73;
            this.PutovanjaInput.Validating += new System.ComponentModel.CancelEventHandler(this.PutovanjaInput_Validating);
            // 
            // zaposlenikInput
            // 
            this.zaposlenikInput.FormattingEnabled = true;
            this.zaposlenikInput.Location = new System.Drawing.Point(119, 197);
            this.zaposlenikInput.Name = "zaposlenikInput";
            this.zaposlenikInput.Size = new System.Drawing.Size(188, 21);
            this.zaposlenikInput.TabIndex = 75;
            this.zaposlenikInput.Validating += new System.ComponentModel.CancelEventHandler(this.zaposlenikInput_Validating);
            // 
            // Zaposlenik
            // 
            this.Zaposlenik.AutoSize = true;
            this.Zaposlenik.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zaposlenik.Location = new System.Drawing.Point(16, 197);
            this.Zaposlenik.Name = "Zaposlenik";
            this.Zaposlenik.Size = new System.Drawing.Size(75, 17);
            this.Zaposlenik.TabIndex = 74;
            this.Zaposlenik.Text = "Zaposlenik";
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(119, 256);
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(188, 20);
            this.opisInput.TabIndex = 76;
            this.opisInput.Validating += new System.ComponentModel.CancelEventHandler(this.opisInput_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 77;
            this.label3.Text = "Opis";
            // 
            // odgođeno
            // 
            this.odgođeno.AutoSize = true;
            this.odgođeno.Location = new System.Drawing.Point(119, 314);
            this.odgođeno.Name = "odgođeno";
            this.odgođeno.Size = new System.Drawing.Size(15, 14);
            this.odgođeno.TabIndex = 78;
            this.odgođeno.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 79;
            this.label6.Text = "Odgođeno";
            // 
            // snimi
            // 
            this.snimi.BackColor = System.Drawing.Color.SkyBlue;
            this.snimi.FlatAppearance.BorderSize = 0;
            this.snimi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.snimi.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snimi.ForeColor = System.Drawing.Color.White;
            this.snimi.Location = new System.Drawing.Point(227, 385);
            this.snimi.Name = "snimi";
            this.snimi.Size = new System.Drawing.Size(80, 30);
            this.snimi.TabIndex = 82;
            this.snimi.Text = "Snimi";
            this.snimi.UseVisualStyleBackColor = false;
            this.snimi.Click += new System.EventHandler(this.snimi_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // zaduzenjaDetailZaposlenik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(387, 450);
            this.Controls.Add(this.snimi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.odgođeno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.opisInput);
            this.Controls.Add(this.zaposlenikInput);
            this.Controls.Add(this.Zaposlenik);
            this.Controls.Add(this.PutovanjaInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "zaduzenjaDetailZaposlenik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "zaduzenjaDetailZaposlenik";
            this.Load += new System.EventHandler(this.zaduzenjaDetailZaposlenik_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zaduzenjaDetailZaposlenik_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.zaduzenjaDetailZaposlenik_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zaduzenjaDetailZaposlenik_MouseUp);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PutovanjaInput;
        private System.Windows.Forms.ComboBox zaposlenikInput;
        private System.Windows.Forms.Label Zaposlenik;
        private System.Windows.Forms.TextBox opisInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox odgođeno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button snimi;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}