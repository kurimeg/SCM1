using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCM1_API.Model.ScreenModel.Phone
{
    [DataContract]
    public class PhoneRequest : ScmApiBaseParameter.Request
    {
        //追加項目無し
    }

    public class PhoneResponse : ScmApiBaseParameter.Response
    {
        public IEnumerable<MST_EXTENSION_LINE> PhoneInfo { get; set; }
    }
}