using SCM1_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Repository
{
    public class T_EMP_LOCATION_Repository
    {
        private const string SQL_FILE_NM = "T_EMP_LOCATION";


        /// <summary>
        /// ユーザー位置情報全件取得
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T_EMP_LOCATION> FetchAllEmpLocationInfo_Repository(dynamic TargetAreaDv)
        {
            //                                                         ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            return DataAccess.DataAccess.ThrowSQLModel<T_EMP_LOCATION>(SQL_FILE_NM, "FetchAllEmpLocationInfo", TargetAreaDv);
            //                                                                       ↑左のxmlファイル内の実際に呼び出すSQLのID
        }
    }
}