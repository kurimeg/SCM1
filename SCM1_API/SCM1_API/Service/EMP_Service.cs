using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCM1_API.Model;
using SCM1_API.Repository;

namespace SCM1_API.Service
{
    public class EMP_Service
    {
        /// <summary>
        /// 社員情報を取得する
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MST_EMP> FetchEMPInfo_Service(string postedEMP_NO)
        {
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { EMP_NO = postedEMP_NO };
            return MST_EMP_Repository.FetchEMPInfo_Repository(param);
            
        }

        /// <summary>
        /// 社員情報を取得する_ログイン用
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MST_EMP> FetchEMPInfo_ToAuth_Service(string postedEMP_NO)
        {
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { EMP_NO = postedEMP_NO };
            return MST_EMP_Repository.FetchEMPInfo_ToAuth_Repository(param);

        }

        /// <summary>
        /// 社員情報を全件取得する
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MST_EMP> FetchAllEMPInfo_Service()
        {
            return MST_EMP_Repository.FetchAllEMPInfo_Repository();

        }
    }
}