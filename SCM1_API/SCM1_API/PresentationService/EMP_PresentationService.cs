using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCM1_API.Service;
using SCM1_API.Model.ScreenModel.Auth;

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
        public Response FetchEMPInfo(Request req)
        {
            //社員情報の取得
            var FetchedEmpInfo = emp_Service.FetchEMPInfo_Service(req.EmpNo);

            ////アクセストークンを保存する_@2017/11/13Test
            //var tokenStoreResult = TokenHandling.CreateToken(postedEMP_NO);

            ////アクセストークンを取得する_@2017/11/13Test
            //var tokenInspectResult = TokenHandling.InspectToken(postedEMP_NO);

            //処理ステータスと取得結果を返す
            var returnValue = new Tuple<bool, object>(FetchedEmpInfo.Count() != 0? true:false, FetchedEmpInfo);
            return returnValue;
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