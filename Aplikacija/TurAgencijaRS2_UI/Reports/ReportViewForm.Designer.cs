namespace TurAgencijaRS2_UI.Reports
{
    partial class ReportViewForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.regijeBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
          
            this.RegijeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.regijeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
          
            this.regijeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
         
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
      
            this.najboljiKlijenti2BindingSource = new System.Windows.Forms.BindingSource(this.components);
    
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.turistickaAgencija_RS2DataSet8 = new TurAgencijaRS2_UI.TuristickaAgencija_RS2DataSet8();
            this.najboljiKlijenti3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.najboljiKlijenti3TableAdapter = new TurAgencijaRS2_UI.TuristickaAgencija_RS2DataSet8TableAdapters.NajboljiKlijenti3TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.regijeBindingSource3)).BeginInit();
         
            ((System.ComponentModel.ISupportInitialize)(this.RegijeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regijeBindingSource1)).BeginInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.regijeBindingSource2)).BeginInit();
            this.panel2.SuspendLayout();
        
            ((System.ComponentModel.ISupportInitialize)(this.najboljiKlijenti2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turistickaAgencija_RS2DataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.najboljiKlijenti3BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // regijeBindingSource3
            // 
            this.regijeBindingSource3.DataMember = "Regije";
          
            // 
            // turistickaAgencija_RS2DataSet2
            // 
       
            // 
            // RegijeBindingSource
            // 
            this.RegijeBindingSource.DataSource = typeof(TurAgencijaRS2_Model.Regije);
            // 
            // regijeBindingSource1
            // 
            this.regijeBindingSource1.DataSource = typeof(TurAgencijaRS2_Model.Regije);
            // 
            // turistickaAgencija_RS2DataSet1
            // 
         
            // 
            // regijeBindingSource2
            // 
            this.regijeBindingSource2.DataMember = "Regije";
         
            // 
            // regijeTableAdapter
            // 
         
            // 
            // regijeTableAdapter1
            // 
        
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.SkyBlue;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(644, 15);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(-2, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 47);
            this.panel2.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 3);
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
            this.label5.Location = new System.Drawing.Point(602, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 24);
            this.label5.TabIndex = 13;
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
            this.label4.Location = new System.Drawing.Point(620, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "X";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(252, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Najbolji klijenti";
            // 
            // turistickaAgencija_RS2DataSet5
            // 
           
            // najboljiKlijenti2BindingSource
            // 
            this.najboljiKlijenti2BindingSource.DataMember = "NajboljiKlijenti2";
         
            // 
            // najboljiKlijenti2TableAdapter
            // 
       
            // 
            // reportViewer1
            // 
            reportDataSource6.Name = "DataSet1";
            reportDataSource6.Value = this.najboljiKlijenti3BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TurAgencijaRS2_UI.Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-2, 112);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(666, 422);
            this.reportViewer1.TabIndex = 16;
            // 
            // turistickaAgencija_RS2DataSet8
            // 
            this.turistickaAgencija_RS2DataSet8.DataSetName = "TuristickaAgencija_RS2DataSet8";
            this.turistickaAgencija_RS2DataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // najboljiKlijenti3BindingSource
            // 
            this.najboljiKlijenti3BindingSource.DataMember = "NajboljiKlijenti3";
            this.najboljiKlijenti3BindingSource.DataSource = this.turistickaAgencija_RS2DataSet8;
            // 
            // najboljiKlijenti3TableAdapter
            // 
            this.najboljiKlijenti3TableAdapter.ClearBeforeFill = true;
            // 
            // ReportViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 535);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportViewForm";
            this.Load += new System.EventHandler(this.ReportViewForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ReportViewForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ReportViewForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ReportViewForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.regijeBindingSource3)).EndInit();
         
            ((System.ComponentModel.ISupportInitialize)(this.RegijeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regijeBindingSource1)).EndInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.regijeBindingSource2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
           
            ((System.ComponentModel.ISupportInitialize)(this.najboljiKlijenti2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turistickaAgencija_RS2DataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.najboljiKlijenti3BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource RegijeBindingSource;
        private System.Windows.Forms.BindingSource regijeBindingSource1;
      
        private System.Windows.Forms.BindingSource regijeBindingSource2;
      
        private System.Windows.Forms.BindingSource regijeBindingSource3;
      
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
     
        private System.Windows.Forms.BindingSource najboljiKlijenti2BindingSource;
        
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private TuristickaAgencija_RS2DataSet8 turistickaAgencija_RS2DataSet8;
        private System.Windows.Forms.BindingSource najboljiKlijenti3BindingSource;
        private TuristickaAgencija_RS2DataSet8TableAdapters.NajboljiKlijenti3TableAdapter najboljiKlijenti3TableAdapter;
    }
}