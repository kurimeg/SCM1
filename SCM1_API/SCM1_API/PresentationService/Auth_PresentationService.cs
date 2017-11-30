using SCM1_API.Model.constants;
using SCM1_API.Model.ScreenModel.Auth;
using SCM1_API.Service;
using SCM1_API.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.PresentationService
{
    public class Auth_PresentationService
    {

        private EMP_Service empService;

        public Auth_PresentationService()
        {
            empService = new EMP_Service();
        }

        public AuthResponse Auth(AuthRequest req)
        {
            var resModel = new AuthResponse()
            {
                ProcessStatus = STATUS.NG,
                Authenticated = false,
                Token = ""
            };
            var empInfo = empService.FetchEMPInfo_ToAuth_Service(req.EmpNo);

            if (empInfo == null || empInfo.Count() > 1)
            {
                Logger.WriteError("社員情報の取得件数が正しくありません。");
                return resModel;
            }

            if (req.Password != empInfo.First().LOGIN_PASSWORD)
            {
                Logger.WriteError("社員番号/パスワードの組み合わせが適切ではありません。");
                return resModel;
            }

            if (TokenHandling.CreateToken(req.EmpNo))
            {
                resModel.ProcessStatus = STATUS.OK;
                resModel.Token = empService.FetchEMPInfo_ToAuth_Service(req.EmpNo).First().ACCESS_TOKEN;
                resModel.Authenticated = true;
            }
            else
            {
                Logger.WriteError("トークンの生成に失敗しました。");
                return resModel;
            }
            return resModel;
        }
    }
}