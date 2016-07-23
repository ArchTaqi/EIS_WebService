using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace WcfService1
{
    public class Notification
    {
        [DataMember]
        public string NotificationText { get; set; }
        [DataMember]
        public string CreatedOn { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string countlikes { get; set; }
        
    }
}