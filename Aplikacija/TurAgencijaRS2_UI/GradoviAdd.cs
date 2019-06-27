using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurAgencijaRS2_Model.Requests;

namespace TurAgencijaRS2_UI
{
    public partial class GradoviAdd : Form
    {

        private readonly APIService _regijeService = new APIService("Regije");


        private readonly APIService _gradoviService = new APIService("Gradovi");
        GradoviUpsertRequest request = new GradoviUpsertRequest();


        public GradoviAdd()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private async Task LoadRegije()
        {
            var result = await _regijeService.Get<List<TurAgencijaRS2_Model.Regije>>(null);

            result.Insert(0, new TurAgencijaRS2_Model.Regije());

            regijeList.DataSource = result;
            regijeList.DisplayMember = "Naziv";
            regijeList.ValueMember = "RegijaId";

        }


        private async Task LoadGradovi(int regijaId)
        {
            var result =await _gradoviService.Get<List<TurAgencijaRS2_Model.Gradovi>>(new GradoviSearchRequest()
            {
                RegijaId=regijaId
            });
            GradoviGrid.DataSource = result;
        }





        private async void GradoviAdd_Load(object sender, EventArgs e)
        {
            await LoadRegije();
           
        }

        private async void regijeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = regijeList.SelectedValue;

            if(int.TryParse(idObj.ToString(),out int id))//ako je ispravno selektovano dobijemo id parametar
            {
                await LoadGradovi(id);
            }

        }

    

     

        private void dodajSlikubutton_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                slikaInput.Text = openFileDialog1.FileName;

                Image originalImage = Image.FromFile(openFileDialog1.FileName);
                MemoryStream ms = new MemoryStream();
                originalImage.Save(ms, ImageFormat.Jpeg);


                request.Slika = ms.ToArray();
                request.SlikaThumb = ms.ToArray();




                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);

                request.Slika = file;
                slikaInput.Text = fileName;

                Image image = Image.FromFile(fileName);
                pictureBox.Image = image;


            }


        }

        private  async void snimi_Click(object sender, EventArgs e)
        {

            if(this.ValidateChildren())
            { 

            var idObj = regijeList.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int RegijaId))//ako je ispravno selektovano dobijemo id parametar
            {
                request.RegijaId = RegijaId;
            }

            request.Naziv = nazivInput.Text;

            await _gradoviService.Insert<TurAgencijaRS2_Model.Gradovi>(request);

            MessageBox.Show("Grad uspjesno doddan");
            this.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nazivInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nazivInput.Text))
            {
                errorProvider.SetError(nazivInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(nazivInput, null);
            }

            if (nazivInput.Text.Length < 3)
            {
                errorProvider.SetError(nazivInput, Properties.Resources.Min_char);
                e.Cancel = true;
            }
        }

        private void regijeList_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(regijeList.Text))
            {
                errorProvider.SetError(regijeList, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(regijeList, null);
            }
        }

        private void slikaInput_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(slikaInput.Text))
            {
                errorProvider.SetError(slikaInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(slikaInput, null);
            }
        }

        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);


        private void GradoviAdd_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void GradoviAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void GradoviAdd_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }   
}
