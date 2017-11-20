using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model.constants
{
    public class STATUS
    {
        /// <summary>
        /// 処理成功
        /// </summary>
        public const string OK = "OK";
        /// <summary>
        /// 処理失敗
        /// </summary>
        public const string NG = "NG";
        /// <summary>
        /// 異常終了（予期せぬエラー）
        /// </summary>
        public const string ER = "ER";

        /// <summary>
        /// アクセストークン認証失敗
        /// </summary>
        public const string TOKEN_ER = "TOKEN_ER";
    }
}