namespace TurAgencijaRS2_UI
{
    partial class GradoviAdd
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
            this.GradoviGrid = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.slikaInput = new System.Windows.Forms.TextBox();
            this.regijeList = new System.Windows.Forms.ComboBox();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dodajSlikubutton = new System.Windows.Forms.Button();
            this.snimi = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GradoviGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // GradoviGrid
            // 
            this.GradoviGrid.AllowUserToAddRows = false;
            this.GradoviGrid.AllowUserToDeleteRows = false;
            this.GradoviGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GradoviGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GradoviGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GradoviGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Slika});
            this.GradoviGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GradoviGrid.Location = new System.Drawing.Point(0, 294);
            this.GradoviGrid.Name = "GradoviGrid";
            this.GradoviGrid.ReadOnly = true;
            this.GradoviGrid.RowTemplate.Height = 100;
            this.GradoviGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GradoviGrid.Size = new System.Drawing.Size(800, 156);
            this.GradoviGrid.TabIndex = 71;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Slika
            // 
            this.Slika.DataPropertyName = "SlikaThumb";
            this.Slika.HeaderText = "Slika";
            this.Slika.Name = "Slika";
            this.Slika.ReadOnly = true;
            this.Slika.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Slika.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(469, 50);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(287, 186);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 69;
            this.pictureBox.TabStop = false;
            // 
            // slikaInput
            // 
            this.slikaInput.Location = new System.Drawing.Point(106, 213);
            this.slikaInput.Name = "slikaInput";
            this.slikaInput.Size = new System.Drawing.Size(171, 20);
            this.slikaInput.TabIndex = 68;
            this.slikaInput.TabStop = false;
            this.slikaInput.Validating += new System.ComponentModel.CancelEventHandler(this.slikaInput_Validating);
            // 
            // regijeList
            // 
            this.regijeList.FormattingEnabled = true;
            this.regijeList.Location = new System.Drawing.Point(106, 146);
            this.regijeList.Name = "regijeList";
            this.regijeList.Size = new System.Drawing.Size(171, 21);
            this.regijeList.TabIndex = 66;
            this.regijeList.SelectedIndexChanged += new System.EventHandler(this.regijeList_SelectedIndexChanged);
            this.regijeList.Validating += new System.ComponentModel.CancelEventHandler(this.regijeList_Validating);
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(106, 83);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(171, 20);
            this.nazivInput.TabIndex = 65;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.nazivInput_Validating);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 75;
            this.label2.Text = "Ime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 76;
            this.label3.Text = "Regije";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 77;
            this.label1.Text = "Slika";
            // 
            // dodajSlikubutton
            // 
            this.dodajSlikubutton.BackColor = System.Drawing.Color.SkyBlue;
            this.dodajSlikubutton.FlatAppearance.BorderSize = 0;
            this.dodajSlikubutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dodajSlikubutton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajSlikubutton.ForeColor = System.Drawing.Color.White;
            this.dodajSlikubutton.Location = new System.Drawing.Point(308, 211);
            this.dodajSlikubutton.Name = "dodajSlikubutton";
            this.dodajSlikubutton.Size = new System.Drawing.Size(63, 27);
            this.dodajSlikubutton.TabIndex = 78;
            this.dodajSlikubutton.Text = "Dodaj";
            this.dodajSlikubutton.UseVisualStyleBackColor = false;
            this.dodajSlikubutton.Click += new System.EventHandler(this.dodajSlikubutton_Click_1);
            // 
            // snimi
            // 
            this.snimi.BackColor = System.Drawing.Color.SkyBlue;
            this.snimi.FlatAppearance.BorderSize = 0;
            this.snimi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.snimi.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snimi.ForeColor = System.Drawing.Color.White;
            this.snimi.Location = new System.Drawing.Point(469, 252);
            this.snimi.Name = "snimi";
            this.snimi.Size = new System.Drawing.Size(80, 30);
            this.snimi.TabIndex = 79;
            this.snimi.Text = "Snimi";
            this.snimi.UseVisualStyleBackColor = false;
            this.snimi.Click += new System.EventHandler(this.snimi_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.SkyBlue;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 15);
            this.flowLayoutPanel1.TabIndex = 81;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(-1, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 47);
            this.panel2.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(11, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 38);
            this.label7.TabIndex = 7;
            this.label7.Text = "WT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.SkyBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(759, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 24);
            this.label5.TabIndex = 83;
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
            this.label4.Location = new System.Drawing.Point(776, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 24);
            this.label4.TabIndex = 82;
            this.label4.Text = "X";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // GradoviAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.snimi);
            this.Controls.Add(this.dodajSlikubutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GradoviGrid);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.slikaInput);
            this.Controls.Add(this.regijeList);
            this.Controls.Add(this.nazivInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GradoviAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GradoviAdd";
            this.Load += new System.EventHandler(this.GradoviAdd_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GradoviAdd_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GradoviAdd_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GradoviAdd_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.GradoviGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView GradoviGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox slikaInput;
        private System.Windows.Forms.ComboBox regijeList;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button dodajSlikubutton;
        private System.Windows.Forms.Button snimi;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}