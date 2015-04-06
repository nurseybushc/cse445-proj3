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


namespace ServiceTests
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!(TextBox1.Text.Equals(" "))){
                ServiceReference1.Service1Client proxy1 = new ServiceReference1.Service1Client();
                TextBox3.Text = proxy1.WordFilter(TextBox1.Text);
                TextBox1.Text = "";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!(TextBox2.Text.Equals(" ")))
            {
                TextBox3.Text = "";
                ServiceReference2.Service1Client proxy2 = new ServiceReference2.Service1Client();
                string[] output = proxy2.topTen(TextBox2.Text);
                foreach (string word in output)
                {
                    TextBox3.Text += word + " ";
                }
                TextBox2.Text = "";
            }
        }
        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
        }

        public class OpeningHours
        {
            public bool open_now { get; set; }
        }

        public class Photo
        {
            public int height { get; set; }
            public List<object> html_attributions { get; set; }
            public string photo_reference { get; set; }
            public int width { get; set; }
        }

        public class AltId
        {
            public string place_id { get; set; }
            public string scope { get; set; }
        }

        public class Result
        {
            public Geometry geometry { get; set; }
            public string icon { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public OpeningHours opening_hours { get; set; }
            public List<Photo> photos { get; set; }
            public string place_id { get; set; }
            public string scope { get; set; }
            public List<AltId> alt_ids { get; set; }
            public string reference { get; set; }
            public List<string> types { get; set; }
            public string vicinity { get; set; }
        }

        public class RootObject
        {
            public List<object> html_attributions { get; set; }
            public List<Result> results { get; set; }
            public string status { get; set; }
                
        }
        
        
        protected void Button3_Click(object sender, EventArgs e)
        {
            
            string query = TextBox4.Text;
            string URL = "https://maps.googleapis.com/maps/api/place/textsearch/json";

            string keyAPI = "AIzaSyCMcvEBMsrgKM3xGA1saqaQfXxGLcnlwsU";
            string parameters = "?query=" + query + "&key=" + keyAPI;
 
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(parameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    RootObject Jsonstuff = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);

                    if (Jsonstuff.results.Count != 0)
                    {
                        TextBox3.Text = "Your search of: \"" + query + "\"\treturned these stores\n";
                        foreach (var result in Jsonstuff.results)
                        {                            
                            TextBox3.Text += result.name +"\n";
                        }
                    }
                    TextBox4.Text = "";
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }           
         }        
    }
}