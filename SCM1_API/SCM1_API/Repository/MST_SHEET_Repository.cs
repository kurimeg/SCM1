using SCM1_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Repository
{
    public class MST_SHEET_Repository
    {
        private const string SQL_FILE_NM = "MST_SHEET";


        /// <summary>
        /// 座席情報取得
        /// </summary>
        /// <param name="TargetEMP_NO">絞込条件に使用する社員番号</param>
        /// <returns></returns>
        public static IEnumerable<MST_SHEET> FetchSheetInfo_Repository(dynamic TargetAreaDv)
        {
            //                                                         ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            return DataAccess.DataAccess.SELECT_Model<MST_SHEET>(SQL_FILE_NM, "FetchSheetInfo", TargetAreaDv);
            //                                                                       ↑左のxmlファイル内の実際に呼び出すSQLのID
        }
    }
}