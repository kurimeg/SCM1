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
using SCM1_API.Model.ScreenModel.seat;
using Swashbuckle.Swagger.Annotations;

namespace SCM1_API.APIController
{
    public class seatWithEmpController : ApiController
    {
        private SEAT_PresentationService presentationService;
        public seatWithEmpController()
        {
            presentationService = new SEAT_PresentationService();
        }
        /// <summary>
        /// POST_事業所別に座席マスタと登録済み社員の情報を取得する<controller> 
        /// </summary>
        /// <param name="empno"></param>
        /// <returns></returns>
        [SwaggerOperation("FetchSeatWithEmpInfo")]
        [LoggingFilter("api/seatwithemp")]
        public JsonResult<object> Post(JToken reqJson)
        {
            try
            {
                SeatRequest req = JsonUtil.Deserialize<SeatRequest>(reqJson.ToString());

                //トークンを検証
                if (!Service.TokenHandling.InspectToken_direct(req.Token))
                    return Json((object)new SeatResponse()
                    {
                        ProcessStatus = STATUS.TOKEN_ER,
                        ResponseMessage = MESSAGE.MSG_TOKEN_ER
                    });

                SeatWithEmpResponse res = presentationService.FetchSeatWithEmpInfo(req);
                return Json((object)res);
            }
            catch (Exception ex)
            {
                Logger.WriteException(MESSAGE.MSG_ER, ex);
                return Json((object)new SeatResponse() { ProcessStatus = STATUS.ER, ResponseMessage = MESSAGE.MSG_ER });
            }
        }
    }
}
