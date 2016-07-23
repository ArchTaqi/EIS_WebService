using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]

    public interface IService1
    {

        //fetching articles

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Articles/{candidateid}/{conid}")]
        article[] getarticle(String candidateid, String conid);

        ////fetching events
       
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "Events/{candidateid}/{conid}")]
        events[] getevents(String candidateid, String conid);



        //fetching videos
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "videos/{candidatid}/{conid}")]
        videos[] getvideos(String candidatid, String conid);



        //fetching  notification
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "notification/{candidatename}/{conid}")]
        Notification[] getnotification(String candidatename,String conid);

        //conandidate searching--->>>> Search Buutton on 2nd screen
        
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Filter/{candidateetail}")]
        candidate[] getcandidateetail(String candidateetail);
        
        //constituency searching--->>>> Search Buutton on 2nd screen

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Search/{condetail}")]
        confilter[] getconfilter(String condetail);
  



        // COnstituency displying --------->>> first Sccreen
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Assembly/{name}")]
        Constituency[] getConstituency(String name);

        
        //Candidate displaying 
            [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "findcan/{canid}")]
        candetails[] getdetails(String canid);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}
