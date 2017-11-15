using SCM1_API.Model;
using SCM1_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Service
{
    public class SHEET_Service
    {
        private const int DefaultAreadv = (int)Model.constants.FLOOR_PLACE_DV.SINURA;


        /// <summary>
        /// 座席情報を取得する
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MST_SHEET> FetchSheetInfo_Service(int postedAreaDv = DefaultAreadv)
        {
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { FLOOR_PLACE_DV = postedAreaDv };
            return MST_SHEET_Repository.FetchSheetInfo_Repository(param);
        }
    }
}