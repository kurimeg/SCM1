using SCM1_API.PresentationService;
using SCM1_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCM1_API.APIController
{
    public class sheetController : ApiController
    {
        /// <summary>
        /// GET _事業所別に座席マスタの情報を取得する<controller> 
        /// </summary>
        /// <param name="empno"></param>
        /// <returns></returns>
        public HttpResponseMessage Get([FromUri]int searchareadv)
        {
            //PresentationService
            var PresentationService = new SHEET_PresentationService();
            String ResultStatus = string.Empty;

            try
            {
                var ProcessResult = PresentationService.FetchSheetInfo(searchareadv);
                ResultStatus = ProcessResult.Item1 == true ? "OK" : "NG";
                return JsonUtil.ReturnJson((object)new Tuple<String, object>(ResultStatus, ProcessResult.Item2));
            }
            catch (Exception ex)
            {
                ResultStatus = "ER";
                return JsonUtil.ReturnJson((object)(ResultStatus));
            }
        }
    }
}
