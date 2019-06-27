using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TurAgencijaRS2_Mobile1
{
   public class KorisniciService
    {

        private string _route = null;


#if DEBUG

        string _apiUrl = "http://localhost:59019/api";

#endif

        public KorisniciService(string route)
        {
            _route = route;
        }


        public async Task<T> Insert<T>(object request)
        {


            var url = $"{ _apiUrl}/{ _route}";



            return await url.WithBasicAuth("korisnik.korisnik", "test").PostJsonAsync(request).ReceiveJson<T>();
        }


    }
}
