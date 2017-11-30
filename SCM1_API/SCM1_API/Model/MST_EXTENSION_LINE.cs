using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model
{
    public class MST_EXTENSION_LINE : MST_CONTENT_VIEW
    {
        /// <summary>
        /// 内線番号
        /// </summary>
        public string EXT_LINE_NO
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