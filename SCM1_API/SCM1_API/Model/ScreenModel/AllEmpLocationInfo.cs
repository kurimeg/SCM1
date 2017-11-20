using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SCM1_API.Model.ScreenModel;

namespace SCM1_API.Model.ScreenModel.AllEmpLocationInfo
{

    [DataContract]
    public class AllEmpLocationRequest : ScmApiBaseParameter.Request
    {
        //追加項目なし
    }

    public class AllEmpLocationResponse : ScmApiBaseParameter.Response
    {
        public IEnumerable<T_EMP_LOCATION> EmpLocation { get; set; }
    }

}