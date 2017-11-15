using SCM1_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.PresentationService
{
    public class SHEET_PresentationService
    {
        private SHEET_Service sheet_Service;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SHEET_PresentationService()
        {
            sheet_Service = new SHEET_Service();
        }

        /// <summary>
        /// 座席情報を取得する
        /// </summary>
        /// <returns></returns>
        public Tuple<bool, object> FetchSheetInfo(int postedAreaDv)
        {
            //座席情報の取得
            var FetchedSheetInfo = sheet_Service.FetchSheetInfo_Service(postedAreaDv);

            //処理ステータスと取得結果を返す
            var returnValue = new Tuple<bool, object>(FetchedSheetInfo.Count() != 0 ? true : false, FetchedSheetInfo);
            return returnValue;
        }
    }
}