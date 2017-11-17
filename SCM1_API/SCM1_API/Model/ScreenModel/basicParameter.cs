using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model.ScreenModel
{
    public class basicParameter
    {
        /// <summary>
        /// トークン
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// クライント所属事業所区分
        /// </summary>
        public string ClientAreaDv { get; set; }
    }
}