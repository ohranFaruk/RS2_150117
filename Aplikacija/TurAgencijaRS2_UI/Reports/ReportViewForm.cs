using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurAgencijaRS2_Model;

namespace TurAgencijaRS2_UI.Reports
{
    public partial class ReportViewForm : Form
    {
        public ReportViewForm()
        {
            InitializeComponent();
        }
      
        private  void ReportViewForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'turistickaAgencija_RS2DataSet8.NajboljiKlijenti3' table. You can move, or remove it, as needed.
            this.najboljiKlijenti3TableAdapter.Fill(this.turistickaAgencija_RS2DataSet8.NajboljiKlijenti3);
            // TODO: This line of code loads data into the 'turistickaAgencija_RS2DataSet5.NajboljiKlijenti2' table. You can move, or remove it, as needed.
       
            // TODO: This line of code loads data into the 'turistickaAgencija_RS2DataSet2.Regije' table. You can move, or remove it, as needed.
         
            // TODO: This line of code loads data into the 'turistickaAgencija_RS2DataSet1.Regije' table. You can move, or remove it, as needed.
       




         

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }


        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);
        private void ReportViewForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);

        }

        private void ReportViewForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void ReportViewForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
