using Newtonsoft.Json.Linq;
using SCM1_API.Model.constants;
using SCM1_API.PresentationService;
using SCM1_API.Service;
using SCM1_API.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using SCM1_API.Model.ScreenModel.Sheet;
using Swashbuckle.Swagger.Annotations;

namespace SCM1_API.APIController
{
    public class sheetController : ApiController
    {
        private SHEET_PresentationService presentationService;
        public sheetController()
        {
            presentationService = new SHEET_PresentationService();
        }


        /// <summary>
        /// GET _事業所別に座席マスタの情報を取得する<controller> 
        /// </summary>
        /// <param name="empno"></param>
        /// <returns></returns>
        [SwaggerOperation("FetchSheetInfo")]
        [LoggingFilter("api/sheet")] // <-- AOP（処理開始、終了時のロギング処理）
        public JsonResult<object> Post(JToken reqJson)
        {
            try
            {
                SheetRequest req = JsonUtil.Deserialize<SheetRequest>(reqJson.ToString()); // <-- JSONをモデルに変換

                //トークンを検証
                if (!SCM1_API.Service.TokenHandling.InspectToken_direct(req.Token)) return Json((object)new SheetResponse() { ProcessStatus = STATUS.TOKEN_ER, ResponseMessage = MESSAGE.MSG_TOKEN_ER });

                SheetResponse res = presentationService.FetchSheetInfo(req);
                return Json((object)res);
            }
            catch (Exception ex)
            {
                Logger.WriteException(MESSAGE.MSG_ER, ex);
                return Json((object)new SheetResponse() { ProcessStatus = STATUS.ER, ResponseMessage = MESSAGE.MSG_ER });
            }
        }
    }
}
