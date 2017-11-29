using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model
{
    public class MST_EMP
    {
        /// <summary>
        /// 社員番号
        /// </summary>
        public int EMP_NO
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
    }
}