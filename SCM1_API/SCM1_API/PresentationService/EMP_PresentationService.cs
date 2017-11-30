using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCM1_API.Service;
using SCM1_API.Model.ScreenModel.EmpInfo;
using SCM1_API.Model.constants;

namespace SCM1_API.PresentationService
{
    public class EMP_PresentationService
    {
        private EMP_Service emp_Service; 

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EMP_PresentationService()
        {
            emp_Service = new EMP_Service();
        }

        /// <summary>
        /// 社員情報を取得する
        /// </summary>
        /// <returns></returns>
        public EmpInfoResponse FetchEMPInfo(EmpInfoRequest req)
        {
            var returnModel = new EmpInfoResponse();
            //社員情報の取得
            returnModel.EmpInfo = emp_Service.FetchEMPInfo_Service(req.EmpNo);

            //処理ステータスと取得結果を返す
            returnModel.ProcessStatus = returnModel.EmpInfo.Count() != 0 ? STATUS.OK : STATUS.NG;
            //NGの場合はメッセージを設定
            if (returnModel.ProcessStatus == STATUS.NG) returnModel.ResponseMessage = MESSAGE.MSG_FETCH_EMP_INFO_NG;
            return returnModel;
        }

        /// <summary>
        /// 社員情報を全件取得する
        /// </summary>
        /// <returns></returns>
        public EmpInfoResponse FetchAllEMPInfo()
        {
            var returnModel = new EmpInfoResponse();
            //社員情報の取得
            returnModel.EmpInfo = emp_Service.FetchAllEMPInfo_Service();

            //処理ステータスと取得結果を返す
            returnModel.ProcessStatus = returnModel.EmpInfo.Count() != 0 ? STATUS.OK : STATUS.NG;
            //NGの場合はメッセージを設定
            if (returnModel.ProcessStatus == STATUS.NG) returnModel.ResponseMessage = MESSAGE.MSG_FETCH_EMP_INFO_NG;
            return returnModel;
        }

        /// <summary>
        /// アクセストークンを検証
        /// </summary>
        /// <returns></returns>
        public bool InspectAccessToken(string postedAccessToken)
        {
            //アクセストークンを検証する
            var tokenInspectResult = TokenHandling.InspectToken_direct(postedAccessToken);

            //処理ステータスを返す
            return tokenInspectResult;
        }
    }
}