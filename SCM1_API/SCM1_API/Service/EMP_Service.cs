using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCM1_API.Model;
using SCM1_API.Model.ScreenModel.EmpInfo;
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

        /// <summary>
        /// 社員情報を登録、更新する
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public int UpdateEMPInfo_Service(EmpInfoRequest req)
        {
            var param = new {
                EMP_NO =req.EmpNo
                ,LOGIN_PASSWORD =req.Password
                ,ACCESS_TOKEN =req.Token
                ,CAN_SIT_FIXED_SEAT_FLG =req.FixedFlg
                ,EMP_NM =req.EmpNm
                ,EMP_KANA_NM =req.EmpKana
                ,CREATE_EMP_NO = ""
                ,LAST_UPDATE_EMP_NO = "",
                DISPLAY_EMP_NM =req.DisplayNm
            };
           
            return MST_EMP_Repository.UpdateEMPInfo_Repository(param);
        }

        /// <summary>
        /// 社員情報を削除する
        /// </summary>
        /// <returns></returns>
        public int ClearEMPInfo_Service(EmpInfoRequest req)
        {
            var param = new { EMP_NO = req.EmpNo };
            return MST_EMP_Repository.ClearEMPInfo_Repository(param);
        }
    }
}