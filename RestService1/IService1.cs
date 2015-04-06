using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Xml)]	// Add this HTTP GET attribute/directive
        double PiValue();
        
        [OperationContract]
        [WebGet]	// Add this HTTP GET attribute/directive
        int absValue(int x);
        
        [OperationContract]
        [WebGet(UriTemplate = "add2?x={x}&y={y}", ResponseFormat = WebMessageFormat.Json)]
        // Add this HTTP GET attribute/directive
        int addition(int x, int y);
    }
}
