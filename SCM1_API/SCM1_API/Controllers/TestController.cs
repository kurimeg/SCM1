using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using SCM1_API.DataAccess;

namespace SCM1_API.Controllers
{
    public class TestController : ApiController
    {
        public System.Web.Http.Results.JsonResult<object> Get()
        {
            ////list data
            //List<object> objList = new List<object>();
            //objList.Add(new { id = 1, name = "hoge" });
            //objList.Add(new { id = 2, name = "foo" });

            ////response
            //object obj = new { status = "OK", data = objList };

            ////return
            //return Json(obj);

            var param = new { JISEKI_SEQ_NO = "00000" };
            //object resultData = DataAccess.DataAccess.ThrowSQL(@"DataAccess\SQL","Sample","test",param);
            object resultData = DataAccess.DataAccess.ThrowSQL(@"DataAccess\SQL", "Sample", "test");

            return Json(resultData);

        }


    }
}
