using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SCM1_API.PresentationService;
using SCM1_API.Model;
using SCM1_API.Service;
using Swashbuckle.Swagger.Annotations;

namespace SCM1_API.APIController
{
    public class empController : ApiController
    {

        /// <summary>
        /// GET _社員番号をキーに社員マスタの情報を取得する<controller> 
        /// </summary>
        /// <param name="empno"></param>
        /// <returns></returns>
        public HttpResponseMessage Get([FromUri]string searchempno)
        {
            //PresentationService
            var PresentationService = new EMP_PresentationService();
            String ResultStatus = string.Empty;
            try
            { 
                var ProcessResult = PresentationService.FetchEMPInfo(searchempno);
                ResultStatus = ProcessResult.Item1 == true ? "OK" : "NG";
                return JsonUtil.ReturnJson((object)new Tuple<String, object>(ResultStatus, ProcessResult.Item2));
            }
            catch (Exception ex)
            {
                ResultStatus = "ER";
                return JsonUtil.ReturnJson((object)(ResultStatus));
            }
        }

        // GET api/<controller>/5
        public System.Web.Http.Results.JsonResult<object> Get([FromUri]string id, [FromUri]string areadv)
        {
            return Json((object)new Tuple<String, object>("OK", id));
        }


        // POST api/<controller>
        [SwaggerOperation("InspectToken")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public HttpResponseMessage Post([FromBody]string value)
        {
            //値がNullの場合(テスト用)
            if (value == null)  return JsonUtil.ReturnJson((object)("値がNUllです(ノД`)・゜・。\r\nなので処理は行っていません。"));

            //PresentationService
            var PresentationService = new EMP_PresentationService();
            String ResultStatus = string.Empty;
            try
            {
                var ProcessResult = PresentationService.InspectAccessToken(value);
                //return JsonUtil.ReturnJson((object)(ProcessResult));
                return JsonUtil.ReturnJson((object)new Tuple<String, object>("OK", value));
            }
            catch (Exception ex)
            {
                ResultStatus = "ER";
                //return JsonUtil.ReturnJson((object)(ResultStatus));
                return JsonUtil.ReturnJson((object)new Tuple<String, object>("ER", value));
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