using Newtonsoft.Json.Linq;
using SCM1_API.PresentationService;
using SCM1_API.Util;
using SCM1_API.Model.ScreenModel.EmpLocationInfo;
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
    public class emplocationController : ApiController
    {

        private const string BatchPassword = "DailyClearBatch"; 
        private EMP_LOCATION_PresentationService presentationService;
        public emplocationController()
        {
            presentationService = new EMP_LOCATION_PresentationService();
        }


        /// <summary>
        /// GET _事業所別にユーザー位置情報を取得する<controller> 
        /// </summary>
        /// <param name="reqJson">POSTされたJSON形式の値</param>
        /// <returns></returns>
        [SwaggerOperation("FetchAllEmpLocationInfo")]
        [LoggingFilter("api/emplocation")] // <-- AOP（処理開始、終了時のロギング処理）
        public JsonResult<object> Post(JToken reqJson) // <-- ActionResultのJsonResultを戻り値とする
        {
            try
            {
                var req = JsonUtil.Deserialize<EmpLocationRequest>(reqJson.ToString()); // <-- JSONをモデルに変換

                //トークンを検証
                if (!Service.TokenHandling.InspectToken_direct(req.Token))
                    return Json((object)new EmpLocationResponse()
                    {
                        ProcessStatus = STATUS.TOKEN_ER,
                        ResponseMessage = MESSAGE.MSG_TOKEN_ER
                    });

                //社員番号が無ければ全件取得
                if (string.IsNullOrEmpty(req.EmpNo))
                {
                    var res = presentationService.FetchAllEmpLocationInfo(req);
                    return Json((object)res);
                }
                else
                {
                    var res = presentationService.FetchEmpLocationInfo(req);
                    return Json((object)res);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(MESSAGE.MSG_ER, ex);
                return Json((object)new EmpLocationResponse() { ProcessStatus = STATUS.ER, ResponseMessage = MESSAGE.MSG_ER });
            }
        }

        // PUT api/<controller>/5
        /// <summary>
        /// PUT_ユーザー位置情報を登録する
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [SwaggerOperation("RegisterEmpLocation")]
        [LoggingFilter("api/emplocation")] // <-- AOP（処理開始、終了時のロギング処理）
        public JsonResult<object> Put(JToken reqJson) // <-- ActionResultのJsonResultを戻り値とする
        {
            try
            {
                var req = JsonUtil.Deserialize<EmpLocationRequest>(reqJson.ToString()); // <-- JSONをモデルに変換

                //トークンを検証
                if (!Service.TokenHandling.InspectToken_direct(req.Token))
                    return Json((object)new EmpLocationResponse()
                    {
                        ProcessStatus = STATUS.TOKEN_ER,
                        ResponseMessage = MESSAGE.MSG_TOKEN_ER
                    });

                //座席情報を登録
                var res = presentationService.RegisterLocation(req);
                return Json((object)res);
            }
            catch (Exception ex)
            {
                Logger.WriteException(MESSAGE.MSG_ER, ex);
                return Json((object)new EmpLocationResponse() { ProcessStatus = STATUS.ER, ResponseMessage = MESSAGE.MSG_ER });
            }
        }


        // DELETE api/<controller>/5
        [SwaggerOperation("ClearEmpLocationInfo")]
        [LoggingFilter("api/emplocation")] // <-- AOP（処理開始、終了時のロギング処理）
        public JsonResult<object> Delete(JToken reqJson)
        {
            try
            {
                var req = JsonUtil.Deserialize<EmpLocationRequest>(reqJson.ToString()); // <-- JSONをモデルに変換

                //社員番号がバッチ処理パスワードと一致した場合は、固定席以外全件消去
                if (req.EmpNo == BatchPassword)
                {
                    var res = presentationService.ClearAllEmpLocationInfo(req);
                    return Json((object)res);
                }
                else
                {
                    //トークンを検証
                    if (!Service.TokenHandling.InspectToken_direct(req.Token))
                        return Json((object)new EmpLocationResponse()
                        {
                            ProcessStatus = STATUS.TOKEN_ER,
                            ResponseMessage = MESSAGE.MSG_TOKEN_ER
                        });

                    var res = presentationService.ClearEmpLocationInfo(req);
                    return Json((object)res);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(MESSAGE.MSG_ER, ex);
                return Json((object)new EmpLocationResponse() { ProcessStatus = STATUS.ER, ResponseMessage = MESSAGE.MSG_ER });
            }
        }
    }
}
