using SCM1_API.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCM1_API.Model.ScreenModel.FloorPlace
{
    [DataContract]
    public class FloorPlaceRequest : ScmApiBaseParameter.Request
    {
        //追加項目なし
    }

    public class FloorPlaceResponse : ScmApiBaseParameter.Response
    {
        public IEnumerable<MST_FLOOR_PLACE_DV> FloorPlaces { get; set; }
    }
}