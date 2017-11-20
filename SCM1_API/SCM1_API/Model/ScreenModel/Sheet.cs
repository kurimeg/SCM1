using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCM1_API.Model.ScreenModel.Sheet
{
    [DataContract]
    public class SheetRequest : ScmApiBaseParameter.Request
    {
        //追加項目なし
    }

    public class SheetResponse : ScmApiBaseParameter.Response
    {
        public IEnumerable<MST_SHEET> SheetInfo { get; set; }
    }
}