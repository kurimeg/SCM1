using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SCM1_API.PresentationService;
using SCM1_API.Model;

namespace SCM1_API.APIController
{
    public class empController : ApiController
    {

        /// <summary>
        /// GET _社員番号をキーに社員マスタの情報を取得する<controller> 
        /// </summary>
        /// <param name="empno"></param>
        /// <returns></returns>
        public System.Web.Http.Results.JsonResult<object> Get([FromUri]string searchempno)
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
        public System.Web.Http.Results.JsonResult<object> Get([FromUri]string id, [FromUri]string areadv)
        {
            return Json((object)new Tuple<String, object>("OK", id));
        }

        // POST api/<controller>
        public System.Web.Http.Results.JsonResult<object> Post([FromUri]MST_EMP_MODEL insertempdata)
        {
            return Json((object)new Tuple<String, object>("OK",insertempdata));
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