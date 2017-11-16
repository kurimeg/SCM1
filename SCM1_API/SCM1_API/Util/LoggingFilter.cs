using System.Diagnostics;
using System.Web.Http.Filters;

namespace SCM1_API.Util
{
    public class LoggingFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        private readonly string message;

        public LoggingFilter(string message = "デフォルト")
        {
            this.message = message;
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            Logger.Write("[API処理-START]" + message);
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Logger.Write("[API処理-END]" + message);
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}