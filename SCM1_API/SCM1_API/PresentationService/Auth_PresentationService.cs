using SCM1_API.Model.ScreenModel.Auth;
using SCM1_API.Service;
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

        public Response Auth(Request req)
        {
            var resModel = new Response()
            {
                Authenticated = false,
                Token = ""
            };
            var empInfo = empService.FetchEMPInfo_Service(req.EmpNo);

            if (empInfo == null || empInfo.Count() > 1)
                return resModel;

            if (req.Password != empInfo.First().LOGIN_PASSWORD)
                return resModel;

            if (TokenHandling.CreateToken(req.EmpNo))
            {
                resModel.Token = empService.FetchEMPInfo_Service(req.EmpNo).First().ACCESS_TOKEN;
                resModel.Authenticated = true;
            }
            return resModel;
        }
    }
}