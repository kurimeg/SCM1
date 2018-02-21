using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SCM1_API.Model.ScreenModel
{
    public class ScmApiBaseParameter
    {
        /// <summary>
        /// リクエストのベースクラス
        /// </summary>
        [DataContract]
        public class Request
        {
            /// <summary>
            /// アクセストークン
            /// </summary>
            [DataMember]
            public string Token { get; set; }

            /// <summary>
            /// クライント所属事業所区分
            /// </summary>
            [DataMember]
            public string ClientAreaDv { get; set; }
        };


        /// <summary>
        /// レスポンスのベースクラス
        /// </summary>
        public class Response
        {
            /// <summary>
            /// 処理ステータス
            /// </summary>
            public string ProcessStatus { get; set; }

            /// <summary>
            /// メッセージ
            /// </summary>
            public string ResponseMessage { get; set; }
        };


    }
}
