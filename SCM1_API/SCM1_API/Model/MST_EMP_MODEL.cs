using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model
{
    public class MST_EMP_MODEL
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
        /// 固定席利用可能フラグ
        /// </summary>
        public char CAN_SIT_FIXED_SHEET_FLG
        {
            get; set;
        }
    }
}