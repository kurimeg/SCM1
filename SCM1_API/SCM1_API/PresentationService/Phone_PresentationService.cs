using SCM1_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.PresentationService
{
    public class Phone_PresentationService
    {
        private Phone_Service phone_Service;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Phone_PresentationService()
        {
            phone_Service = new Phone_Service();
        }

        /// <summary>
        /// 内線情報を取得する
        /// </summary>
        /// <returns></returns>
        public Tuple<bool, object> FetchPhoneInfo(string postedAreaDv)
        {
            //内線情報の取得
            var FetchedPhoneInfo = phone_Service.FetchPhoneInfo_Service(postedAreaDv);

            //処理ステータスと取得結果を返す
            var returnValue = new Tuple<bool, object>(FetchedPhoneInfo.Count() != 0 ? true : false, FetchedPhoneInfo);
            return returnValue;
        }
    }
}