using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SCM1_API.Model.ScreenModel;

namespace SCM1_API.Model.ScreenModel.EmpLocationInfo
{

    [DataContract]
    public class EmpLocationRequest : ScmApiBaseParameter.Request
    {
        [DataMember]
        public string EmpNo { get; set; }
        [DataMember]
        public string seatNo { get; set; }
        [DataMember]
        public bool FixedFlg { get; set; }
    }

    public class EmpLocationResponse : ScmApiBaseParameter.Response
    {
        public IEnumerable<T_EMP_LOCATION> EmpLocation { get; set; }
    }

}