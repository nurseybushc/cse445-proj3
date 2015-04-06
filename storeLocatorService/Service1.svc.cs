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

namespace storeLocatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        
        public RootObject storeLocate(string name, string area)
        {
            //string[] output;
            string query = name + " " + area;
            string URL = "https://maps.googleapis.com/maps/api/place/textsearch/json";

            string keyAPI = "AIzaSyCMcvEBMsrgKM3xGA1saqaQfXxGLcnlwsU";
            string parameters = "?query=" + query + "&key=" + keyAPI + "&radius=35200" + "&types=store" + "&opennow=true";
            RootObject Jsonstuff = new RootObject();
            string jsonString = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                Jsonstuff = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);
                //jsonString = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                if (Jsonstuff.results.Count != 0)
                {
                    //output = "Your search of: \"" + query + "\"\treturned these stores\n";
                    foreach (var result in Jsonstuff.results)
                    {
                        jsonString += result.name + "\n";
                    }
                }
                //output = Jsonstuff;
               
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                //output = "" + response.StatusCode + "(" + response.ReasonPhrase + ")";
                //return output;
            }
            return Jsonstuff;
            //response.Content = new StringContent(Jsonstuff, Encoding.UTF8, "application/json");
            
        }
    }
}
