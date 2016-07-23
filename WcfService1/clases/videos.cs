using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace WcfService1
{
public class videos
    {
        [DataMember]
        public string VideoTitle { get; set;}
        [DataMember]
        public string VideoLink { get; set; }
        [DataMember]
        public string CreatedOn{get;set;}
        [DataMember]
        public string Details { get; set; } 
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string likes { get; set; }


    }
}
