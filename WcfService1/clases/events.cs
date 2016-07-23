using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfService1
{
   public class events
    {
        [DataMember]
        public string EventId { get; set; }
        [DataMember]
        public string EventTitle {get;set;}
        [DataMember]
        public string EventDescription { get; set; }
        [DataMember]
        public string Eventimg { get; set; }
        [DataMember]
        public string Eventstarttime { get; set; }
        [DataMember]
        public string Eventendtime { get; set; }
        [DataMember]
        public string Eventstartdate { get; set; }
        [DataMember]
        public string Eventenddate { get; set; }
        [DataMember]
        public string Eventtiming { get; set; }
        [DataMember]
        public string countlikes { get; set; }
        [DataMember]
        public string Venue { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Contact { get; set; }
   

   }
}
