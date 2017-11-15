﻿using Newtonsoft.Json.Linq;
using SCM1_API.PresentationService;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace SCM1_API.APIController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class empController : ApiController
    {

        /// <summary>
        /// GET _社員番号をキーに社員マスタの情報を取得する<controller> 
        /// </summary>
        /// <param name="empno"></param>
        /// <returns></returns>
        public JsonResult<object> Get([FromUri]string searchempno)
        {
            //PresentationService
            var PresentationService = new EMP_PresentationService();
            String ResultStatus = string.Empty;
            try
            { 
                var ProcessResult = PresentationService.FetchEMPInfo(searchempno);
                ResultStatus = ProcessResult.Item1 == true ? "OK" : "NG";
                return Json((object)new Tuple<String, object>(ResultStatus, ProcessResult.Item2));
            }
            catch (Exception ex)
            {
                ResultStatus = "ER";
                return Json((object)(ResultStatus));
            }
        }

        // GET api/<controller>/5
        public JsonResult<object> Get([FromUri]string id, [FromUri]string areadv)
        {
            return Json((object)new Tuple<String, object>("OK", id));
        }


        // POST api/<controller>
        [SwaggerOperation("InspectToken")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public JsonResult<object> Post(JToken accesstoken)
        {
            //値がNullの場合(テスト用)
            if (accesstoken == null)  return Json((object)("値がNUllです(ノД`)・゜・。\r\nなので処理は行っていません。"));
            //request変数に移し替え
            dynamic request = accesstoken;

            //PresentationService

            var PresentationService = new EMP_PresentationService();
            String ResultStatus = string.Empty;
            try
            {
                var ProcessResult = PresentationService.InspectAccessToken((string)request.token);
                //return JsonUtil.ReturnJson((object)(ProcessResult));
                return Json((object)new Tuple<String, object>("OK", (string)request.token));
            }
            catch (Exception ex)
            {
                ResultStatus = "ER";
                //return JsonUtil.ReturnJson((object)(ResultStatus));
                return Json((object)new Tuple<String, object>("ER", (string)request.token));
            }
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