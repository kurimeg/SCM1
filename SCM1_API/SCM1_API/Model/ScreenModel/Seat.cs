using SCM1_API.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCM1_API.Model.ScreenModel.seat
{
    [DataContract]
    public class SeatRequest : ScmApiBaseParameter.Request
    {
        //追加項目なし
    }

    public class SeatResponse : ScmApiBaseParameter.Response
    {
        public IEnumerable<MST_SEAT> SeatInfo { get; set; }
    }

    public class SeatWithEmpResponse : ScmApiBaseParameter.Response
    {
        public IEnumerable<SeatWithEmp> SeatWithEmpInfo { get; set; }
    }
}