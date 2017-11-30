using SCM1_API.Model.constants;
using SCM1_API.Model.ScreenModel.Phone;
using SCM1_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.PresentationService
{
    public class PHONE_PresentationService
    {
        private PHONE_Service phone_Service;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PHONE_PresentationService()
        {
            phone_Service = new PHONE_Service();
        }

        /// <summary>
        /// 内線情報を取得する
        /// </summary>
        /// <returns></returns>
        public PhoneResponse FetchPhoneInfo(PhoneRequest req)
        {
            var returnModel = new PhoneResponse();

            //内線情報の取得
            returnModel.PhoneInfo = phone_Service.FetchPhoneInfo_Service(req.ClientAreaDv);

            //処理ステータスと取得結果を返す
            returnModel.ProcessStatus = returnModel.PhoneInfo.Count() != 0 ? STATUS.OK : STATUS.NG;
            //NGの場合はメッセージを設定
            if (returnModel.ProcessStatus == STATUS.NG) returnModel.ResponseMessage = MESSAGE.MSG_FETCH_PHONE_NG;
            return returnModel;
        }
    }
}