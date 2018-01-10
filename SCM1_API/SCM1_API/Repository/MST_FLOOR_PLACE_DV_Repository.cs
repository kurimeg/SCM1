using SCM1_API.Model;
using SCM1_API.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Repository
{
    public class MST_FLOOR_PLACE_DV_Repository
    {
        private const string SQL_FILE_NM = "MST_FLOOR_PLACE_DV";


        /// <summary>
        /// 事業所区分/区分名全件取得
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<MST_FLOOR_PLACE_DV> FetchAllFloorPlace_Repository()
        {
            return DataAccess.DataAccess.SELECT_Model<MST_FLOOR_PLACE_DV>(SQL_FILE_NM, "FetchAllFloorPlace");
        }
    }
}