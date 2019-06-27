namespace TurAgencijaRS2_UI.Zaposlenik
{
    partial class ponudaDetailZaposlenik
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.Naziv = new System.Windows.Forms.Label();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pocetak = new System.Windows.Forms.DateTimePicker();
            this.zavrsetak = new System.Windows.Forms.DateTimePicker();
            this.Putovanja = new System.Windows.Forms.Label();
            this.snimiPonude = new System.Windows.Forms.Button();
            this.dodajPutovanje = new System.Windows.Forms.Button();
            this.putovanjaGrid1 = new System.Windows.Forms.DataGridView();
            this.PutovanjeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Putovanje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumPolaska = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datumpovratka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Popust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Obrisi = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.putovanjaGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.SkyBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(751, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "_";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SkyBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(863, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "X";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.SkyBlue;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 15);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(777, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 29);
            this.label1.TabIndex = 14;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(0, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 47);
            this.panel2.TabIndex = 15;
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
            // Naziv
            // 
            this.Naziv.AutoSize = true;
            this.Naziv.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Naziv.Location = new System.Drawing.Point(65, 103);
            this.Naziv.Name = "Naziv";
            this.Naziv.Size = new System.Drawing.Size(44, 17);
            this.Naziv.TabIndex = 17;
            this.Naziv.Text = "Naziv";
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(174, 103);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(200, 20);
            this.nazivInput.TabIndex = 18;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.nazivInput_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Datum pocetka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Datum zavrsetka";
            // 
            // pocetak
            // 
            this.pocetak.Location = new System.Drawing.Point(174, 151);
            this.pocetak.Name = "pocetak";
            this.pocetak.Size = new System.Drawing.Size(200, 20);
            this.pocetak.TabIndex = 21;
            // 
            // zavrsetak
            // 
            this.zavrsetak.Location = new System.Drawing.Point(174, 198);
            this.zavrsetak.Name = "zavrsetak";
            this.zavrsetak.Size = new System.Drawing.Size(200, 20);
            this.zavrsetak.TabIndex = 22;
            // 
            // Putovanja
            // 
            this.Putovanja.AutoSize = true;
            this.Putovanja.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Putovanja.Location = new System.Drawing.Point(65, 241);
            this.Putovanja.Name = "Putovanja";
            this.Putovanja.Size = new System.Drawing.Size(75, 17);
            this.Putovanja.TabIndex = 23;
            this.Putovanja.Text = "Putovanja";
            // 
            // snimiPonude
            // 
            this.snimiPonude.BackColor = System.Drawing.Color.SkyBlue;
            this.snimiPonude.FlatAppearance.BorderSize = 0;
            this.snimiPonude.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.snimiPonude.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snimiPonude.ForeColor = System.Drawing.Color.White;
            this.snimiPonude.Location = new System.Drawing.Point(401, 234);
            this.snimiPonude.Name = "snimiPonude";
            this.snimiPonude.Size = new System.Drawing.Size(88, 30);
            this.snimiPonude.TabIndex = 25;
            this.snimiPonude.Text = "Snimi";
            this.snimiPonude.UseVisualStyleBackColor = false;
            this.snimiPonude.Click += new System.EventHandler(this.snimiPonude_Click);
            // 
            // dodajPutovanje
            // 
            this.dodajPutovanje.BackColor = System.Drawing.Color.SkyBlue;
            this.dodajPutovanje.FlatAppearance.BorderSize = 0;
            this.dodajPutovanje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dodajPutovanje.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajPutovanje.ForeColor = System.Drawing.Color.White;
            this.dodajPutovanje.Location = new System.Drawing.Point(511, 234);
            this.dodajPutovanje.Name = "dodajPutovanje";
            this.dodajPutovanje.Size = new System.Drawing.Size(134, 30);
            this.dodajPutovanje.TabIndex = 26;
            this.dodajPutovanje.Text = "Dodaj putovanje";
            this.dodajPutovanje.UseVisualStyleBackColor = false;
            this.dodajPutovanje.Click += new System.EventHandler(this.dodajPutovanje_Click);
            // 
            // putovanjaGrid1
            // 
            this.putovanjaGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.putovanjaGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.putovanjaGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PutovanjeId,
            this.Putovanje,
            this.Cijena,
            this.DatumPolaska,
            this.Datumpovratka,
            this.Opis,
            this.Popust});
            this.putovanjaGrid1.Location = new System.Drawing.Point(0, 296);
            this.putovanjaGrid1.Name = "putovanjaGrid1";
            this.putovanjaGrid1.Size = new System.Drawing.Size(814, 158);
            this.putovanjaGrid1.TabIndex = 27;
            // 
            // PutovanjeId
            // 
            this.PutovanjeId.DataPropertyName = "PutovanjeId";
            this.PutovanjeId.HeaderText = "PutovanjeId";
            this.PutovanjeId.Name = "PutovanjeId";
            this.PutovanjeId.Visible = false;
            // 
            // Putovanje
            // 
            this.Putovanje.HeaderText = "Putovanje";
            this.Putovanje.Name = "Putovanje";
            // 
            // Cijena
            // 
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            // 
            // DatumPolaska
            // 
            this.DatumPolaska.HeaderText = "Datum polaska";
            this.DatumPolaska.Name = "DatumPolaska";
            // 
            // Datumpovratka
            // 
            this.Datumpovratka.HeaderText = "Datum povratka";
            this.Datumpovratka.Name = "Datumpovratka";
            // 
            // Opis
            // 
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            // 
            // Popust
            // 
            this.Popust.HeaderText = "Popust";
            this.Popust.Name = "Popust";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Obrisi
            // 
            this.Obrisi.BackColor = System.Drawing.Color.SkyBlue;
            this.Obrisi.FlatAppearance.BorderSize = 0;
            this.Obrisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Obrisi.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Obrisi.ForeColor = System.Drawing.Color.White;
            this.Obrisi.Location = new System.Drawing.Point(672, 234);
            this.Obrisi.Name = "Obrisi";
            this.Obrisi.Size = new System.Drawing.Size(88, 30);
            this.Obrisi.TabIndex = 28;
            this.Obrisi.Text = "Obrisi";
            this.Obrisi.UseVisualStyleBackColor = false;
            this.Obrisi.Click += new System.EventHandler(this.Obrisi_Click);
            // 
            // ponudaDetailZaposlenik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Obrisi);
            this.Controls.Add(this.putovanjaGrid1);
            this.Controls.Add(this.dodajPutovanje);
            this.Controls.Add(this.snimiPonude);
            this.Controls.Add(this.Putovanja);
            this.Controls.Add(this.zavrsetak);
            this.Controls.Add(this.pocetak);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.Naziv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ponudaDetailZaposlenik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ponudaDetailZaposlenik";
            this.Load += new System.EventHandler(this.ponudaDetailZaposlenik_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ponudaDetailZaposlenik_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ponudaDetailZaposlenik_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ponudaDetailZaposlenik_MouseUp);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.putovanjaGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Naziv;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker pocetak;
        private System.Windows.Forms.DateTimePicker zavrsetak;
        private System.Windows.Forms.Label Putovanja;
        private System.Windows.Forms.Button snimiPonude;
        private System.Windows.Forms.Button dodajPutovanje;
        private System.Windows.Forms.DataGridView putovanjaGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PutovanjeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Putovanje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumPolaska;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datumpovratka;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Popust;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button Obrisi;
    }
}