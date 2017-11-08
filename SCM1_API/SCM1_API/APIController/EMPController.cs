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
        // GET api/<controller>
        public System.Web.Http.Results.JsonResult<object> Get(string empno)
        {
            //PresentationService
            var PresentationService = new EMP_PresentationService();
            var ProcessResult = PresentationService.FetchEMPInfo(empno);
            var ResultStatus = ProcessResult.Item1 == true ? "OK" : "NG";

            return Json((object)new Tuple<String,object>(ResultStatus, ProcessResult.Item2));
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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