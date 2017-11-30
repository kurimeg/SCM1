using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model
{
    public class footerColumns
    {
        /// <summary>
        /// 作成社員番号
        /// </summary>
        public string CREATE_EMP_NO
        {
            get; set;
        }

        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime CREATE_DT
        {
            get; set;
        }

        /// <summary>
        /// 更新社員番号
        /// </summary>
        public string LAST_UPDATE_EMP_NO
        {
            get; set;
        }

        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime LAST_UPDATE_DT
        {
            get; set;
        }
    }
}