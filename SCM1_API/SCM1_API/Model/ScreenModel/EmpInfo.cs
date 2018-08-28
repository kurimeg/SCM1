using SCM1_API.Model.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCM1_API.Model.ScreenModel.EmpInfo
{
    [DataContract]
    public class EmpInfoRequest : ScmApiBaseParameter.Request
    {
        [DataMember]
        public string EmpNo { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string EmpNm { get; set; }
        [DataMember]
        public string EmpKana { get; set; }
        [DataMember]
        public string Company { get; set; }
        [DataMember]
        public string AdminFlg { get; set; }
        [DataMember]
        public string DisplayNm { get; set; }
        [DataMember]
        public string FixedFlg { get; set; }
    }

    public class EmpInfoResponse : ScmApiBaseParameter.Response
    {
        public IEnumerable<MST_EMP> EmpInfo { get; set; }
    }

}