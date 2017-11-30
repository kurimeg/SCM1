using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model
{
    public class MST_EMP: footerColumns
    {
        /// <summary>
        /// 社員番号
        /// </summary>
        public string EMP_NO
        {
            get;set;
        }

        /// <summary>
        /// パスワード
        /// </summary>
        public string LOGIN_PASSWORD
        {
            get;set;
        }

        /// <summary>
        /// アクセストークン
        /// </summary>
        public string ACCESS_TOKEN
        {
            get; set;
        }

        /// <summary>
        /// アクセストークン作成日付
        /// </summary>
        public DateTime TOKEN_CREATE_DATE
        {
            get; set;
        }

        /// <summary>
        /// 固定席利用可能フラグ
        /// </summary>
        public bool CAN_SIT_FIXED_seat_FLG
        {
            get; set;
        }

        /// <summary>
        /// 表示社員名
        /// </summary>
        public string DISPLAY_EMP_NM
        {
            get; set;
        }

        /// <summary>
        /// 社員名
        /// </summary>
        public string EMP_NM
        {
            get; set;
        }

        /// <summary>
        /// 社員名_かな
        /// </summary>
        public string EMP_KANA_NM
        {
            get; set;
        }
    }
}