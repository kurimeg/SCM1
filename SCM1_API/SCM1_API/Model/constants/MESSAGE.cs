using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Model.constants
{
    public class MESSAGE
    {
        /// <summary>
        /// 処理成功
        /// </summary>
        public const string MSG_OK = "処理に成功しました。";
        /// <summary>
        /// 処理失敗
        /// </summary>
        public const string MSG_NG = "処理に失敗しました。";
        /// <summary>
        /// 異常終了（予期せぬエラー）
        /// </summary>
        public const string MSG_ER = "予期せぬエラーが発生しました。";

        /// <summary>
        /// アクセストークン認証失敗
        /// </summary>
        public const string MSG_TOKEN_ER = "アクセストークンの認証に失敗しました。";

        /// <summary>
        /// ログイン失敗
        /// </summary>
        public const string MSG_LOGIN_NG = "ログインに失敗しました。";

        /// <summary>
        /// ユーザー情報取得失敗
        /// </summary>
        public const string MSG_FETCH_EMP_INFO_NG = "ユーザー情報の取得に失敗しました。";

        /// <summary>
        /// 内線情報取得失敗
        /// </summary>
        public const string MSG_FETCH_PHONE_NG = "内線子機情報の取得に失敗しました。";

        /// <summary>
        /// 座席情報取得失敗
        /// </summary>
        public const string MSG_FETCH_SHEET_NG = "座席子機情報の取得に失敗しました。";

        /// <summary>
        /// ユーザー位置情報取得失敗
        /// </summary>
        public const string MSG_FETCH_EMP_LOCATION_NG = "ユーザー位置情報の取得に失敗しました。";

        /// <summary>
        /// ユーザー位置情報登録失敗
        /// </summary>
        public const string MSG_REG_EMP_LOCATION_NG = "ユーザー位置情報の登録に失敗しました。";

        /// <summary>
        /// ユーザー位置情報登録失敗
        /// </summary>
        public const string MSG_GET_EMP_LOCATION_NG = "選択された座席は既に利用されています。";
        
    }
}