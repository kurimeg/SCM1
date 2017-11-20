using SCM1_API.Model;
using SCM1_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Service
{
    public class EMP_LOCATION_Service
    {
        private const int DefaultAreadv = (int)Model.constants.FLOOR_PLACE_DV.SINURA;

        /// <summary>
        /// ユーザー位置情報を取得する
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_EMP_LOCATION> FetchAllEmpLocationInfo_Service(string PostedEmpNo,int postedAreaDv = DefaultAreadv)
        {
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { EMP_NO = PostedEmpNo, FLOOR_PLACE_DV = postedAreaDv };
            return T_EMP_LOCATION_Repository.FetchEmpLocationInfo_Repository(param);
        }

        /// <summary>
        /// ユーザー位置情報を全件取得する
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_EMP_LOCATION> FetchAllEmpLocationInfo_Service(int postedAreaDv = DefaultAreadv)
        {
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { FLOOR_PLACE_DV = postedAreaDv };
            return T_EMP_LOCATION_Repository.FetchAllEmpLocationInfo_Repository(param);
        }
    }
}