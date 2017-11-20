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
    }

    public class EmpInfoResponse : ScmApiBaseParameter.Response
    {
        public IEnumerable<MST_EMP> EmpInfo { get; set; }
    }

}