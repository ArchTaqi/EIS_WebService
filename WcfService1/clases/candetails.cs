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
   public class candetails
    {

        [DataMember]
         public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string DateofBirth { get; set; }
        [DataMember]
        public string OfficeAddress { get; set; }
          [DataMember]
        public string City { get; set; }
      [DataMember]
          public string Proivnce { get; set; }
      [DataMember]
      public string WorkPhone { get; set; }
         
     }
}
