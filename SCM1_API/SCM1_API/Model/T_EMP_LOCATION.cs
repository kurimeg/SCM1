using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model
{
    public class T_EMP_LOCATION
    {
        /// <summary>
        /// 位置データSEQ
        /// </summary>
        public int LOCATION_DATA_SEQ { get; set; }
        
        /// <summary>
        /// 社員番号
        /// </summary>
        public int EMP_NO { get; set; }

        /// <summary>
        /// 座席番号
        /// </summary>
        public string SHEET_NO { get; set; }

        /// <summary>
        /// 内線番号
        /// </summary>
        public int EXT_LINE_NO { get; set; }

        /// <summary>
        /// 社員ステータス
        /// </summary>
        public string EMP_STATUS_DV { get; set; }

        /// <summary>
        /// 固定済フラグ
        /// </summary>
        public bool FIXED_FLG { get; set; }
    }
}