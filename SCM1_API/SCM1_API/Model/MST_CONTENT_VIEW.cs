using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model
{
    public class MST_CONTENT_VIEW
    {
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
        /// 縦フラグ_廃止項目
        /// </summary>
        public bool VERTICAL_FLG
        {
            get; set;
        }

        /// <summary>
        /// CSSクラス名
        /// </summary>
        public string CSS_CLASS_NM
        {
            get; set;
        }
    }
}