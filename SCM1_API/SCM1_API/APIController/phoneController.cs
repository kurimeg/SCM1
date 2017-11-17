using SCM1_API.PresentationService;
using SCM1_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace SCM1_API.APIController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class phoneController : ApiController
    {
        /// <summary>
        /// GET _事業所別に内線マスタの情報を取得する<controller> 
        /// </summary>
        /// <param name="empno"></param>
        /// <returns></returns>
        public JsonResult<object> Get([FromUri]int searchareadv)
        {
            //PresentationService
            var PresentationService = new PHONE_PresentationService();
            String ResultStatus = string.Empty;
            try
            {
                var ProcessResult = PresentationService.FetchPhoneInfo(int.Parse(searchareadv));
                ResultStatus = ProcessResult.Item1 == true ? "OK" : "NG";
                return Json((object)new Tuple<String, object>(ResultStatus, ProcessResult.Item2));
            }
            catch (Exception ex)
            {
                ResultStatus = "ER";
                return Json((object)(ResultStatus));
            }
        }
    }
}
