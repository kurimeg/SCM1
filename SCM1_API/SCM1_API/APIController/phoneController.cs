using Newtonsoft.Json.Linq;
using SCM1_API.PresentationService;
using SCM1_API.Service;
using SCM1_API.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using SCM1_API.Model.ScreenModel.Phone;
using SCM1_API.Model.constants;
using Swashbuckle.Swagger.Annotations;

namespace SCM1_API.APIController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class phoneController : ApiController
    {
        private PHONE_PresentationService presentationService;
        public phoneController()
        {
            presentationService = new PHONE_PresentationService();
        }


        /// <summary>
        /// GET _事業所別に内線マスタの情報を取得する<controller> 
        /// </summary>
        /// <param name="empno"></param>
        /// <returns></returns>
        [SwaggerOperation("FetchPhoneInfo")]
        [LoggingFilter("api/phone")] // <-- AOP（処理開始、終了時のロギング処理）
        public JsonResult<object> Post(JToken reqJson)
        {
            try
            {
                PhoneRequest req = JsonUtil.Deserialize<PhoneRequest>(reqJson.ToString()); // <-- JSONをモデルに変換

                //トークンを検証
                if (!SCM1_API.Service.TokenHandling.InspectToken_direct(req.Token)) return Json((object)new PhoneResponse() { ProcessStatus = STATUS.TOKEN_ER, ResponseMessage = MESSAGE.MSG_TOKEN_ER });

                PhoneResponse res = presentationService.FetchPhoneInfo(req);
                return Json((object)res);
            }
            catch (Exception ex)
            {
                Logger.WriteException(MESSAGE.MSG_ER, ex);
                return Json((object)new PhoneResponse() { ProcessStatus = STATUS.ER, ResponseMessage = MESSAGE.MSG_ER});
            }
        }
    }
}
