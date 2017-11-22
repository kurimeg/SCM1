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
        /// ユーザー位置情報取得
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T_EMP_LOCATION> FetchEmpLocationInfo_Repository(dynamic EmpNo_TargetAreaDv)
        {
            //                                                         ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            return DataAccess.DataAccess.SELECT_Model<T_EMP_LOCATION>(SQL_FILE_NM, "FetchEmpLocationInfo", EmpNo_TargetAreaDv);
            //                                                                       ↑左のxmlファイル内の実際に呼び出すSQLのID
        }

        /// <summary>
        /// ユーザー位置情報全件取得
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T_EMP_LOCATION> FetchAllEmpLocationInfo_Repository(dynamic TargetAreaDv)
        {
            //                                                         ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            return DataAccess.DataAccess.SELECT_Model<T_EMP_LOCATION>(SQL_FILE_NM, "FetchAllEmpLocationInfo", TargetAreaDv);
            //                                                                       ↑左のxmlファイル内の実際に呼び出すSQLのID
        }

        /// <summary>
        /// ユーザー位置情報消去
        /// </summary>
        /// <returns></returns>
        public static bool ClearEmpLocationInfo_Repository(dynamic EmpNo_TargetAreaDv)
        {
            //                                                         ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            int executeRowCnt = DataAccess.DataAccess.ExecuteSQL(SQL_FILE_NM, "ClearEmpLocationInfo", EmpNo_TargetAreaDv, Model.constants.DBAccessType.Delete);
            //                                                                       ↑左のxmlファイル内の実際に呼び出すSQLのID
            return executeRowCnt > 0 ? true : false;
        }

        /// <summary>
        /// ユーザー位置情報固定席以外全件消去
        /// </summary>
        /// <returns></returns>
        public static bool ClearAllEmpLocationInfo_Repository(dynamic TargetAreaDv)
        {
            //                                                         ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            int executeRowCnt = DataAccess.DataAccess.ExecuteSQL(SQL_FILE_NM, "ClearAllEmpLocationInfo", TargetAreaDv, Model.constants.DBAccessType.Delete);
            //                                                                       ↑左のxmlファイル内の実際に呼び出すSQLのID
            return executeRowCnt > 0 ? true : false;
        }
    }
}