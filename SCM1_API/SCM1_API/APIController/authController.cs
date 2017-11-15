using Newtonsoft.Json.Linq;
using SCM1_API.Model.ScreenModel.Auth;
using SCM1_API.PresentationService;
using SCM1_API.Util;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace SCM1_API.APIController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // <-- CORSを有効化（クロスドメイン対策）
    public class authController : ApiController
    {
        #region const
        private Auth_PresentationService presentationService;
        public authController()
        {
            presentationService = new Auth_PresentationService();
        }
        #endregion

        #region api/auth(type:POST)
        public JsonResult<object> Post(JToken reqJson)　 // <-- ActionResultのJsonResultを戻り値とする
        {
            try
            {
                Request req = JsonUtil.Deserialize<Request>(reqJson.ToString()); // <-- JSONをモデルに変換
                Response res = presentationService.Auth(req);
                return Json((object)res);
            }
            catch (Exception e)
            {
                // TODO:ログを・・ログをはきたいんじゃ・・
                return Json((object)new Response() { Authenticated = false, Token = "" });
            }
        }
        #endregion
    }
}