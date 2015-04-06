using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Text;//for Encoding 
namespace freebaseService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public RootObject freebaseSearch(string query)
        {
            string parameters = "?query=" + query;
            string url = "https://www.googleapis.com/freebase/v1/search";
            RootObject Jsonstuff = new RootObject();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                Jsonstuff = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);

                if (Jsonstuff.result.Count != 0)
                {
                    //TextBox3.Text = "Your search of: \"" + query + "\"\treturned these Freebase Items\n";
                    foreach (var result in Jsonstuff.result)
                    {
                        if (result.notable != null)
                        {
                            //TextBox3.Text += "The name of a " + result.notable.name + "\n";
                        }
                    }
                }
                //TextBox5.Text = "";
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return Jsonstuff;
        }
    }
}
