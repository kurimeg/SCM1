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

        /// <summary>
        /// GETのテストメソッド
        /// </summary>
        /// <returns></returns>
        public System.Web.Http.Results.JsonResult<object> Get()
        {
            var isReturnDBData = true;

            //適当なデータをJSONで返す場合
            if (isReturnDBData)
            {
                //list data
                List<object> objList = new List<object>();
                objList.Add(new { id = 1, name = "hoge" });
                objList.Add(new { id = 2, name = "foo" });

                //response
                object obj = new { status = "OK", data = objList };

                //JSONに変換
                return Json(obj);
            }
            //DBデータを返す場合
            else
            {
                var isUsingParameter = false;
                object resultData;
                //パラメーターを使う場合
                if (isUsingParameter)
                {
                    //                ↓はxml内に記述されたSQLの「#」で括られた部分
                    var param = new { JISEKI_SEQ_NO = "00000" };
                    //                                           ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
                    resultData = DataAccess.DataAccess.ThrowSQL("Sample", "test", param);
                    //                                                     ↑左のxmlファイル内の実際に呼び出すSQLのID
                }
                //パラメーターを使わない場合
                else
                {
                    //                                           ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
                    resultData = DataAccess.DataAccess.ThrowSQL("Sample", "test");
                    //                                                     ↑左のxmlファイル内の実際に呼び出すSQLのID
                }
                return Json(resultData);
            }
        }


        /// <summary>
        /// POSTのテストメソッド
        /// </summary>
        /// <returns></returns>
        public System.Web.Http.Results.JsonResult<object> POST()
        {
            return Json((object)"OK");
        }


        /// <summary>
        /// PUTのテストメソッド
        /// </summary>
        /// <returns></returns>
        public System.Web.Http.Results.JsonResult<object> PUT()
        {
            return Json((object)"OK");
        }


        /// <summary>
        /// DELETEのテストメソッド
        /// </summary>
        /// <returns></returns>
        public System.Web.Http.Results.JsonResult<object> DELETE()
        {
            return Json((object)"OK");
        }


        /// <summary>
        /// PATCHのテストメソッド
        /// </summary>
        /// <returns></returns>
        public System.Web.Http.Results.JsonResult<object> PATCH()
        {
            return Json((object)"OK");
        }
    }
}
