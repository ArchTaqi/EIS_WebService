using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace WcfService1
{
    public class article
    {

        [DataMember]
        public string ArticlesId { get; set; }

       [DataMember]
        public string ArticleTitle { get; set; }

        [DataMember]

        public string CreatedOn { get; set; }
        [DataMember]

        public string CreatedBy { get; set; }
     
        [DataMember]
      
        public string countlikes { get; set; }
     
        [DataMember]

        public string Articlledetails { get; set; }
        [DataMember]

        public string ArticleAuthor { get; set; }
        [DataMember]

        public string Articlecatagory { get; set; }
    
    }
}
