using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TurAgencijaRS2_Mobile1.Models;
using TurAgencijaRS2_Model;
using Xamarin.Forms;


namespace TurAgencijaRS2_Mobile1.ViewModels
{
  public  class PonudeViewModel:BaseViewModel
    {

        private readonly APIService ponudeService = new APIService("Ponude");

        private readonly APIService putovanjaService = new APIService("Putovanja");

        private readonly APIService gradoviService = new APIService("Gradovi");
        public PonudeViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ICommand InitCommand { get; set; }

        public ObservableCollection<TurAgencijaRS2_Mobile1.Models.Ponude> ponudeList { get; set; } = new ObservableCollection<TurAgencijaRS2_Mobile1.Models.Ponude>();

      

        public async  Task Init()
        {
            var listPonude = await ponudeService.Get<IEnumerable<TurAgencijaRS2_Mobile1.Models.Ponude>>(null);
            ponudeList.Clear();

            var svaPutovanja = await putovanjaService.Get<List<Putovanja>>(null);
            var counter = 0;

            foreach (var x in listPonude)
            {
                var dodano = false;
                var slika = false;
                foreach (var y in svaPutovanja)
                {
                    if(y.PonudaId==x.PonudaId)
                    {

                        var ponudaLokal = await ponudeService.GetById<TurAgencijaRS2_Mobile1.Models.Ponude>(y.PonudaId);
                        ponudaLokal.brojPutovanja += 1;

                        var sviGradovi = await gradoviService.Get<List<Gradovi>>(null);
                        var grad = new Gradovi();

                        foreach (var m in svaPutovanja)
                        {
                            if (m.PonudaId == x.PonudaId) { 
                            foreach (var n in sviGradovi)
                            {
                                if (m.GradId == n.GradId)
                                {
                                     grad = await gradoviService.GetById<Gradovi>(m.GradId);
                                    ponudaLokal.Slika = grad.Slika;
                                    slika = true;
                                    break;
                                  

                                }
                            

                        }
                            }
                            if (slika)
                                break;
                        }



                     
                        if (!dodano)
                        {
                            ponudaLokal.brojPutovanja += 1;
                            
                            ponudeList.Add(ponudaLokal);
                            dodano = true;
                        }
                      


                    }
                }
                if(!dodano)
                ponudeList.Add(x);
                counter++;
            }


        }


        public async Task<byte[]>  TraziSliku(int putovanjeId)
        {
            var svaPutovanja = await putovanjaService.Get<List<Putovanja>>(null);
            var sviGradovi = await gradoviService.Get<List<Gradovi>>(null);

            foreach (var x in svaPutovanja)
            {
                foreach (var y in sviGradovi)
                {
                    if(y.GradId==x.GradId)
                    {
                        var grad = await gradoviService.GetById<Gradovi>(y.GradId);
                        return grad.Slika;
                    }
                }

            }

            return null;
        }

    }
}
