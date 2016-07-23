using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace WcfService1
{
     [DataContract(Namespace = "")]
    public class candidate
    {
         [DataMember]
         public string UserId { get; set; }
        [DataMember]
        public string canname { get; set; }
        [DataMember]
        public string canpic { get; set; }
        [DataMember]
        public string canparty { get; set; }
    }
}
