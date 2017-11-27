using SCM1_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCM1_API.Model.ScreenModel.seat;
using SCM1_API.Model.constants;

namespace SCM1_API.PresentationService
{
    public class SHEAT_PresentationService
    {
        private SEAT_Service seat_Service;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SHEAT_PresentationService()
        {
            seat_Service = new SEAT_Service();
        }

        /// <summary>
        /// 座席情報を取得する
        /// </summary>
        /// <returns></returns>
        public SeatResponse FetchSeatInfo(SeatRequest req)
        {
            var returnModel = new SeatResponse();

            //座席情報の取得
            returnModel.SeatInfo = seat_Service.FetchSeatInfo_Service(req.ClientAreaDv);

            //処理ステータスと取得結果を返す
            returnModel.ProcessStatus = returnModel.SeatInfo.Count() != 0 ? STATUS.OK : STATUS.NG;
            //NGの場合はメッセージを設定
            if (returnModel.ProcessStatus == STATUS.NG) returnModel.ResponseMessage = MESSAGE.MSG_FETCH_SEAT_NG;
            return returnModel;
        }
    }
}