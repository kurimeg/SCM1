﻿using Newtonsoft.Json.Linq;
using SCM1_API.PresentationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace SCM1_API.APIController
{
    public class emplocationController : ApiController
    {
        /// <summary>
        /// GET _事業所別にユーザー位置情報を取得する<controller> 
        /// </summary>
        /// <param name="empno"></param>
        /// <returns></returns>
        public JsonResult<object> Get(JToken reqJson)
        {
            //PresentationService
            var PresentationService = new SHEET_PresentationService();
            String ResultStatus = string.Empty;

            try
            {
                var ProcessResult = PresentationService.FetchSheetInfo(searchareadv);
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