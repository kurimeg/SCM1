using SCM1_API.Model;
using SCM1_API.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Repository
{
    public class MST_SEAT_Repository
    {
        private const string SQL_FILE_NM = "MST_SEAT";


        /// <summary>
        /// 座席情報取得
        /// </summary>
        /// <param name="TargetEMP_NO">絞込条件に使用する社員番号</param>
        /// <returns></returns>
        public static IEnumerable<MST_SEAT> FetchSeatInfo_Repository(dynamic TargetAreaDv)
        {
            //                                                         ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            return DataAccess.DataAccess.SELECT_Model<MST_SEAT>(SQL_FILE_NM, "FetchSeatInfo", TargetAreaDv);
            //                                                                       ↑左のxmlファイル内の実際に呼び出すSQLのID
        }

        /// <summary>
        /// 座席と登録済み社員情報取得
        /// </summary>
        /// <param name="TargetEMP_NO">絞込条件に使用する社員番号</param>
        /// <returns></returns>
        public static IEnumerable<SeatWithEmp> FetchSeatWithEmpInfo_Repository(dynamic TargetAreaDv)
        {
            return DataAccess.DataAccess.SELECT_Model<SeatWithEmp>(SQL_FILE_NM, "FetchSeatWithEmpInfo", TargetAreaDv);
        }
    }
}