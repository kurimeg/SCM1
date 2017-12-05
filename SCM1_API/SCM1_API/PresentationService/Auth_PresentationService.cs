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
            
            //暫定的にサーバー側で必須チェック_＠2017/12/05
            if (string.IsNullOrEmpty(req.EmpNo) || string.IsNullOrEmpty(req.Password))
            {
                Logger.WriteError(MESSAGE.MSG_IDPASSWORNG_ER);
                resModel.ResponseMessage = MESSAGE.MSG_IDPASSWORNG_ER;
                return resModel;
            }

            var empInfo = empService.FetchEMPInfo_ToAuth_Service(req.EmpNo);

            if (empInfo == null || empInfo.Count() != 1)
            {
                Logger.WriteError(MESSAGE.MSG_IDPASSWORNG_ER);
                resModel.ResponseMessage = MESSAGE.MSG_IDPASSWORNG_ER;
                return resModel;
            }

            if (req.Password != empInfo.First().LOGIN_PASSWORD)
            {
                Logger.WriteError(MESSAGE.MSG_IDPASSWORNG_ER);
                resModel.ResponseMessage = MESSAGE.MSG_IDPASSWORNG_ER;
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
                Logger.WriteError(MESSAGE.MSG_TOKEN_CREATE_ER);
                resModel.ResponseMessage = MESSAGE.MSG_TOKEN_CREATE_ER;
                return resModel;
            }
            return resModel;
        }
    }
}