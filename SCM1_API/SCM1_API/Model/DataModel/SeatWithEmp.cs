using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model.DataModel
{
    public class SeatWithEmp
    {
        /// <summary>
        /// 座席番号
        /// </summary>
        public string SEAT_NO
        {
            get; set;
        }

        /// <summary>
        /// 固定席フラグ
        /// </summary>
        public bool FIXED_SEAT_FLG
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
        /// コンテンツ区分
        /// </summary>
        public string CONTENTS_DV
        {
            get; set;
        }

        /// <summary>
        /// 描画座標X
        /// </summary>
        public string CONTENT_POSITION_X
        {
            get; set;
        }

        /// <summary>
        /// 描画座標Y
        /// </summary>
        public string CONTENT_POSITION_Y
        {
            get; set;
        }

        /// <summary>
        /// 縦フラグ
        /// </summary>
        public bool VERTICAL_FLG
        {
            get; set;
        }
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
        /// 社員表示名
        /// </summary>
        public string DISPLAY_EMP_NM
        {
            get; set;
        }
        

        /// <summary>
        /// 内線番号
        /// </summary>
        public string EXTENSION_LINE_NO
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