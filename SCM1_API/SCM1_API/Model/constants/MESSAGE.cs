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
        public const string MSG_ER = "予期せぬエラーが発生しました。サポートに問い合わせて下さい。";

        /// <summary>
        /// アクセストークン認証失敗
        /// </summary>
        public const string MSG_TOKEN_ER = "アクセストークンの認証に失敗しました。";

        /// <summary>
        /// ログイン失敗
        /// </summary>
        public const string MSG_LOGIN_NG = "ログインに失敗しました。";

        /// <summary>
        /// 社番＆パスワード組み合わせエラー
        /// </summary>
        public const string MSG_IDPASSWORNG_ER = "社員番号/パスワードの組み合わせが適切ではありません。";

        /// <summary>
        /// トークン生成エラー
        /// </summary>
        public const string MSG_TOKEN_CREATE_ER = "トークンの生成に失敗しました。";

        /// <summary>
        /// ユーザー情報取得失敗
        /// </summary>
        public const string MSG_FETCH_EMP_INFO_NG = "対象のユーザーは現在、座席を登録していません。";

        /// <summary>
        /// ユーザー情報取得失敗_全件
        /// </summary>
        public const string MSG_FETCH_ALL_EMP_INFO_NG = "全ユーザーの座席情報取得に失敗しました。";

        /// <summary>
        /// 内線情報取得失敗
        /// </summary>
        public const string MSG_FETCH_PHONE_NG = "内線子機情報の取得に失敗しました。";

        /// <summary>
        /// 座席情報取得失敗
        /// </summary>
        public const string MSG_FETCH_SEAT_NG = "座席情報の取得に失敗しました。";

        /// <summary>
        /// ユーザー位置情報取得失敗
        /// </summary>
        public const string MSG_FETCH_EMP_LOCATION_NG = "ユーザー位置情報の取得に失敗しました。";

        /// <summary>
        /// ユーザー位置情報登録失敗
        /// </summary>
        public const string MSG_REG_EMP_LOCATION_NG = "ユーザー位置情報の登録に失敗しました。";

        /// <summary>
        /// ユーザー位置情報登録失敗_排他制御
        /// </summary>
        public const string MSG_GET_EMP_LOCATION_NG = "選択された座席は既に利用されています。";

        /// <summary>
        /// ユーザー位置情報解除失敗
        /// </summary>
        public const string MSG_CLEAR_EMP_LOCATION_NG = "ユーザー位置情報の解除に失敗しました。";

    }
}