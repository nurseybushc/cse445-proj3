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
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace storeLocatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "locate?name={name}&area={area}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        RootObject storeLocate(string name, string area);

    }
        [DataContract]
        public class Location
        {
            [DataMember]
            public double lat { get; set; }
            [DataMember]
            public double lng { get; set; }
        }

        [DataContract]
        public class Geometry
        {
            [DataMember]
            public Location location { get; set; }
        }

        [DataContract]
        public class OpeningHours
        {
            [DataMember]
            public bool open_now { get; set; }
        }

        [DataContract]
        public class Photo
        {
            [DataMember]
            public int height { get; set; }
            [DataMember]
            public List<object> html_attributions { get; set; }
            [DataMember]
            public string photo_reference { get; set; }
            [DataMember]
            public int width { get; set; }
        }

        [DataContract]
        public class AltId
        {
            [DataMember]
            public string place_id { get; set; }
            [DataMember]
            public string scope { get; set; }
        }

        [DataContract]
        public class Result
        {
            [DataMember]
            public Geometry geometry { get; set; }
            [DataMember]
            public string icon { get; set; }
            [DataMember]
            public string id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public OpeningHours opening_hours { get; set; }
            [DataMember]
            public List<Photo> photos { get; set; }
            [DataMember]
            public string place_id { get; set; }
            [DataMember]
            public string scope { get; set; }
            [DataMember]
            public List<AltId> alt_ids { get; set; }
            [DataMember]
            public string reference { get; set; }
            [DataMember]
            public List<string> types { get; set; }
            [DataMember]
            public string vicinity { get; set; }
        }

        [DataContract]
        public class RootObject
        {
            [DataMember]
            public List<object> html_attributions { get; set; }
            [DataMember]
            public List<Result> results { get; set; }
            [DataMember]
            public string status { get; set; }

        }
     
}
