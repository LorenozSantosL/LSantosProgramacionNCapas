using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace SL_WCF
{
    
    public class Result
    {
        [DataMember]
        public bool Correct { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Exception EX { get; set; }
        [DataMember]
      
        public Object Object { get; set; }
        [DataMember]
        
        public List<object> Objects { get; set; }
    }
}