using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model
{
    public class MST_SHEET : MST_CONTENT_VIEW
    {
        /// <summary>
        /// 座席番号
        /// </summary>
        public string SHEET_NO
        {
            get; set;
        }

        /// <summary>
        /// 固定席フラグ
        /// </summary>
        public bool FIXED_SHEET_FLG
        {
            get; set;
        }

        /// <summary>
        /// 事業所区分
        /// </summary>
        public string FLOOR_PLACE_DV
        {
            get; set;
        }
    }
}