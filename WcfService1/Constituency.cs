using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfService1
{
    [DataContract(Namespace="")]
    public class Constituency
    {
        [DataMember]
        public string conname { get; set;}
        [DataMember]
        public string connumb { get; set; }
        
    }
}