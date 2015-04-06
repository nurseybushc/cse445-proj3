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

namespace freebaseService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "freebaseSearch?query={query}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        RootObject freebaseSearch(string query);
        
    }

    [DataContract]
    public class Notable
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string id { get; set; }
    }

    [DataContract]
    public class Result
    {
        [DataMember]
        public string mid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public Notable notable { get; set; }
        [DataMember]
        public double score { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public List<Result> result { get; set; }
        [DataMember]
        public int cost { get; set; }
        [DataMember]
        public int hits { get; set; }
    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    
    
}
