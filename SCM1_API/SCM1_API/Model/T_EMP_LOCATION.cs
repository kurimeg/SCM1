using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model
{
    public class T_EMP_LOCATION: footerColumns
    {
        /// <summary>
        /// 位置データSEQ
        /// </summary>
        public int LOCATION_DATA_SEQ
        {
            get; set;
        }
        
        /// <summary>
        /// 社員番号
        /// </summary>
        public string EMP_NO
        {
            get; set;
        }

        /// <summary>
        /// コンテンツID
        /// </summary>
        public string CONTENTS_ID
        {
            get; set;
        }

        /// <summary>
        /// 座席番号
        /// </summary>
        public string SEAT_NO
        {
            get; set;
        }

        /// <summary>
        /// 内線番号
        /// </summary>
        public string EXT_LINE_NO
        {
            get; set;
        }

        /// <summary>
        /// 社員ステータス
        /// </summary>
        public string EMP_STATUS_DV
        {
            get; set;
        }

        /// <summary>
        /// 固定済フラグ
        /// </summary>
        public bool FIXED_FLG
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