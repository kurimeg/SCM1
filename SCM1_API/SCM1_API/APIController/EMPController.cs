using Newtonsoft.Json.Linq;
using SCM1_API.Model.constants;
using SCM1_API.Model.ScreenModel.EmpInfo;
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
        public empController()
        {
            presentationService = new EMP_PresentationService();
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

       

        // GET api/<controller>/5
        public JsonResult<object> Get([FromUri]string id, [FromUri]string areadv)
        {
            return Json((object)new Tuple<String, object>("OK", id));
        }


        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}