using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TurAgencijaRS2_Model;

using System.Windows.Input;
using TurAgencijaRS2_Mobile1.Views;
using Xamarin.Forms;

namespace TurAgencijaRS2_Mobile1
{
    public class APIService
    {

        public static string Username { get; set; }
        public static string Password { get; set; }

        private string _route = null;


#if DEBUG

        string _apiUrl = "http://localhost:59019/api";

#endif


#if RELEASE
          string _apiUrl = "https://mywebsite:44342/api";
#endif





        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {


            var url = $"{_apiUrl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    //MessageBox.Show("Niste authentificirani");
                    await Application.Current.MainPage.DisplayAlert("Greška", "Pogrešno korisnicko ime  ili Lozinka", "OK");
                }
                throw;
            }
        }


        public async Task<T> GetById<T>(object id)
        {


            var url = $"{ _apiUrl}/{ _route}/{id}";



            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }


        public async Task<T> Insert<T>(object request)
        {


            var url = $"{ _apiUrl}/{ _route}";



            return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
        }


        public async Task<T> Update<T>(object id, object request)
        {


            var url = $"{ _apiUrl}/{ _route}/{id}";



            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Delete<T>(object id)
        {


            var url = $"{ _apiUrl}/{ _route}/{id}";



            return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
        }



    }

}
