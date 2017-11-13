using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using SCM1_API.Repository;

namespace SCM1_API.Service
{
    public class TokenHandling
    {
        const string DAconfigFilePath = @"\DataAccess\DataAccess.config";

        /// <summary>
        /// トークン生成共通鍵_文字列取得メソッド
        /// </summary>
        /// <returns></returns>
        private static string FetchTokenPublicKeyString()
        {
            //既定の構成ファイルとは別のファイルを構成ファイルとして読み込む
            var configFile = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + DAconfigFilePath;
            var exeFileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            var config = ConfigurationManager.OpenMappedExeConfiguration(exeFileMap, ConfigurationUserLevel.None);

            return config.ConnectionStrings.ConnectionStrings["TokenPublicKey"].ConnectionString;
        }



        /// <summary>
        /// トークン作成メソッド_issuerがSCM1_AdminのJWTを生成する
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public static bool CreateToken(string empid)
        {
            // 共通鍵を用意
            var keyString = FetchTokenPublicKeyString();
            // トークン操作用のクラスを用意
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            // 共通鍵なのでSymmetricSecurityKeyクラスを使う
            // 引数は鍵のバイト配列
            var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            // 署名情報クラスを生成
            // 共通鍵を使うのでアルゴリズムはHS256使っとけばいいはず
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, "HS256");
            // トークンの詳細情報クラス？を生成
            var descriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = empid,
                SigningCredentials = credentials,
            };
            // トークンの生成
            //SecurityTokenDescriptor使わずにhandler.CreateJwtSecurityToken("GHKEN", null, null, null, null, null, credentials)でもOK
            var token = handler.CreateJwtSecurityToken(descriptor);
            // トークンの文字列表現を取得
            var tokenString = handler.WriteToken(token);
            // トークンのDB保存
            try
            {
                //                ↓はxml内に記述されたSQLの「#」で括られた部分
                var param = new { ACCESS_TOKEN = tokenString, EMP_NO = empid };
                MST_EMP_Repository.StoreAccessToken_Repository(param);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 共通鍵で署名されたトークンを検証するメソッド
        /// トークンの内容は
        /// aud: 空
        /// iss: empno(社員のID)
        /// exp: 期限切れ
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public static bool InspectToken(string empid)
        {
            // 鍵
            var keyString = FetchTokenPublicKeyString();
            var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            // トークン操作用のクラス
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            // トークンの文字列表現
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { EMP_NO = empid };
            var tokenString = MST_EMP_Repository.FetchAccessToken_Repository(param).First().ACCESS_TOKEN; //"★★DBより取得！！@2017/11/13";

            // トークン検証用のパラメータを用意
            // Audience, Issuer, Lifetimeに関してはデフォルトで検証が有効になっている
            // audが空でexpが期限切れなのでValidateAudienceとValidateLifetimeはfalseにしておく
            var validationParams = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = empid,
                ValidateLifetime = false,
                IssuerSigningKey = key,
            };

            try
            {
                Microsoft.IdentityModel.Tokens.SecurityToken token;
                // 第三引数にSecurityToken型の変数を参照で渡しておくと、検証済みのトークンが出力される
                handler.ValidateToken(tokenString, validationParams, out token);

                return true;
            }
            catch (Exception e)
            {
                // ValidateTokenで検証に失敗した場合はここにやってくる
                return false;
                //("トークンが無効です: " + e.Message);
            }

        }
    }
}