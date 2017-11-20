using SCM1_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCM1_API.Model.ScreenModel.Sheet;
using SCM1_API.Model.constants;

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
        public SheetResponse FetchSheetInfo(SheetRequest req)
        {
            var returnModel = new SheetResponse();

            //座席情報の取得
            returnModel.SheetInfo = sheet_Service.FetchSheetInfo_Service(req.ClientAreaDv);

            //処理ステータスと取得結果を返す
            returnModel.ProcessStatus = returnModel.SheetInfo.Count() != 0 ? STATUS.OK : STATUS.NG;
            //NGの場合はメッセージを設定
            if (returnModel.ProcessStatus == STATUS.NG) returnModel.ResponseMessage = MESSAGE.MSG_FETCH_SHEET_NG;
            return returnModel;
        }
    }
}