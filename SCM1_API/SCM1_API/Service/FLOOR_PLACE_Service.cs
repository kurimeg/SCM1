using SCM1_API.Model;
using SCM1_API.Model.DataModel;
using SCM1_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Service
{
    public class FLOOR_PLACE_Service
    {
        /// <summary>
        /// 事業所区分/区分名を全件取得する
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MST_FLOOR_PLACE_DV> FetchAllFloorPlace_Service()
        {
            return MST_FLOOR_PLACE_DV_Repository.FetchAllFloorPlace_Repository();
        }
    }
}