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
    public class confilter
    {
        [DataMember]
        public string conname { get; set; }
        [DataMember]
        public string concode { get; set; }
        [DataMember]
        public string conpopulace { get; set; }
        [DataMember]
        public string confemalevoter { get; set; }
          [DataMember]
        public string conmalevoter { get; set; }
           [DataMember]
          public string conid { get; set; }
           [DataMember]
           public List<candidate> canlist;

    }
        



        
        
    }



