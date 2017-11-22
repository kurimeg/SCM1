using SCM1_API.Model;
using SCM1_API.Model.constants;
using System.Collections.Generic;

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
            return DataAccess.DataAccess.ThrowSQLModel<T_EMP_LOCATION>(SQL_FILE_NM, "FetchEmpLocationInfo", EmpNo_TargetAreaDv);
            //                                                                       ↑左のxmlファイル内の実際に呼び出すSQLのID
        }

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

        public string GetLocationStatus(string sqlId, dynamic dbModel)
        {
            return DataAccess.DataAccess.ThrowSQLModelFirst<string>(SQL_FILE_NM, sqlId, dbModel);
        }

        public int? GetLocationEmpId(string sqlId, dynamic dbModel)
        {
            return DataAccess.DataAccess.ThrowSQLModelFirst<int>(SQL_FILE_NM, sqlId, dbModel);
        }

        public void RegisterEmpLocation(string sqlId, dynamic dbModel)
        {
            DataAccess.DataAccess.ThrowSQLModelFirst<dynamic>(SQL_FILE_NM, sqlId, dbModel);
        }

        public void ReRegisterEmpLocation(string sqlId, dynamic dbModel)
        {
            DataAccess.DataAccess.ThrowSQLModelFirst<dynamic>(SQL_FILE_NM, sqlId, dbModel);
        }
    }
}