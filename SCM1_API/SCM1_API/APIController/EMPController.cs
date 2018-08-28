using Newtonsoft.Json.Linq;
using SCM1_API.Model.constants;
using SCM1_API.Model.ScreenModel.EmpInfo;
using SCM1_API.Model.ScreenModel.EmpLocationInfo;
using SCM1_API.PresentationService;
using SCM1_API.Util;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace SCM1_API.APIController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // <-- CORSを有効化（クロスドメイン対策）
    public class empController : ApiController
    {
        private EMP_PresentationService presentationService;
        private EMP_LOCATION_PresentationService presentationServiceEmpLocation;
        public empController()
        {   
            presentationService = new EMP_PresentationService();
            presentationServiceEmpLocation = new EMP_LOCATION_PresentationService();
        }


        /// <summary>
        /// GET _社員番号をキーに社員マスタの情報を取得する<controller> 
        /// </summary>
        /// <param name="reqJson">POSTされたJSON形式の値</param>
        /// <returns></returns>
        [SwaggerOperation("FetchEmpInfo")]
        [LoggingFilter("api/emp")] // <-- AOP（処理開始、終了時のロギング処理）
        public JsonResult<object> Post(JToken reqJson) // <-- ActionResultのJsonResultを戻り値とする
        {
            try
            {
                EmpInfoRequest req = JsonUtil.Deserialize<EmpInfoRequest>(reqJson.ToString()); // <-- JSONをモデルに変換

                //トークンを検証
                if (!Service.TokenHandling.InspectToken_direct(req.Token))
                    return Json((object)new EmpInfoResponse()
                    {
                        ProcessStatus = STATUS.TOKEN_ER,
                        ResponseMessage = MESSAGE.MSG_TOKEN_ER
                    });

                //社員番号が無ければ全件取得
                if (string.IsNullOrEmpty(req.EmpNo))
                {
                    EmpInfoResponse res = presentationService.FetchAllEMPInfo();
                    return Json((object)res);
                }
                else
                {
                    EmpInfoResponse res = presentationService.FetchEMPInfo(req);
                    return Json((object)res);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(MESSAGE.MSG_ER, ex);
                return Json((object)new EmpInfoResponse() { ProcessStatus = STATUS.ER, ResponseMessage = MESSAGE.MSG_ER });
            }
        }

        /// <summary>
        /// PUT_ 社員情報を登録、更新する
        /// </summary>
        /// <param name="reqJson">POSTされたJSON形式の値</param>
        /// <returns>処理結果</returns>
        [SwaggerOperation("UpdateEmpinfo")]
        [LoggingFilter("api/emp")]
        public JsonResult<object> Put(JToken reqJson)
        {
            try
            {
                EmpInfoRequest req = JsonUtil.Deserialize<EmpInfoRequest>(reqJson.ToString()); // <-- JSONをモデルに変換

                //トークンを検証
                if (!Service.TokenHandling.InspectToken_direct(req.Token))
                    return Json((object)new EmpInfoResponse()
                    {
                        ProcessStatus = STATUS.TOKEN_ER,
                        ResponseMessage = MESSAGE.MSG_TOKEN_ER
                    });

                EmpInfoResponse res = presentationService.UpdateEMPInfo(req);
                return Json((object)res);

            }
            catch (Exception ex)
            {
                Logger.WriteException(MESSAGE.MSG_ER, ex);
                return Json((object)new EmpInfoResponse() { ProcessStatus = STATUS.ER, ResponseMessage = MESSAGE.MSG_ER });
            }
        }

        /// <summary>
        /// DELETE_ 社員情報を削除する
        /// </summary>
        /// <param name="reqJson">POSTされたJSON形式の値</param>
        /// <returns>処理結果</returns>
        [SwaggerOperation("ClearEmpinfo")]
        [LoggingFilter("api/emp")]
        public JsonResult<object> Delete(JToken reqJson)
        {
            try
            {
                EmpInfoRequest req = JsonUtil.Deserialize<EmpInfoRequest>(reqJson.ToString()); // <-- JSONをモデルに変換
                    
                //トークンを検証
                if (!Service.TokenHandling.InspectToken_direct(req.Token))
                    return Json((object)new EmpInfoResponse()
                    {
                        ProcessStatus = STATUS.TOKEN_ER,
                        ResponseMessage = MESSAGE.MSG_TOKEN_ER
                    });

                // ユーザ位置情報解除APIの呼び出し
                var empLocationReq = new EmpLocationRequest();
                empLocationReq.EmpNo = req.EmpNo;
                empLocationReq.ClientAreaDv = req.ClientAreaDv;

                var empLocationRes = presentationServiceEmpLocation.ClearEmpLocationInfo(empLocationReq);

                //todo ユーザ情報削除処理作成

                EmpInfoResponse res = presentationService.ClearEMPInfo(req);
                return Json((object)res);

            }
            catch (Exception ex)
            {
                Logger.WriteException(MESSAGE.MSG_ER, ex);
                return Json((object)new EmpInfoResponse() { ProcessStatus = STATUS.ER, ResponseMessage = MESSAGE.MSG_ER });
            }
        }
    }
}