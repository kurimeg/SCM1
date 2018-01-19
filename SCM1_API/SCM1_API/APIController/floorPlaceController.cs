using Newtonsoft.Json.Linq;
using SCM1_API.PresentationService;
using SCM1_API.Util;
using SCM1_API.Model.ScreenModel.FloorPlace;
using SCM1_API.Model.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Cors;
using Swashbuckle.Swagger.Annotations;

namespace SCM1_API.APIController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // <-- CORSを有効化（クロスドメイン対策）
    public class floorPlaceController : ApiController
    {

        private FLOOR_PLACE_PresentationService presentationService;
        public floorPlaceController()
        {
            presentationService = new FLOOR_PLACE_PresentationService();
        }


        /// <summary>
        /// GET _事業所区分/区分名を全件取得する<controller> 
        /// </summary>
        /// <param name="reqJson">POSTされたJSON形式の値</param>
        /// <returns></returns>
        [SwaggerOperation("FetchAllFloorPlace")]
        [LoggingFilter("api/floorplace")] // <-- AOP（処理開始、終了時のロギング処理）
        public JsonResult<object> Post(JToken reqJson)
        {
            try
            {
                var req = JsonUtil.Deserialize<FloorPlaceRequest>(reqJson.ToString());

                if (!Service.TokenHandling.InspectToken_direct(req.Token))
                    return Json((object)new FloorPlaceResponse()
                    {
                        ProcessStatus = STATUS.TOKEN_ER,
                        ResponseMessage = MESSAGE.MSG_TOKEN_ER
                    });

                var res = presentationService.FetchAllFloorPlace();

                return Json((object)res);
            }
            catch (Exception ex)
            {
                Logger.WriteException(MESSAGE.MSG_ER, ex);
                return Json((object)new FloorPlaceResponse() { ProcessStatus = STATUS.ER, ResponseMessage = MESSAGE.MSG_ER });
            }
        }

    }
}
