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
        const string SCMIssuer = "SCMIssuer";

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
            var dateKeyString = DateTime.Now.ToString();
            var keyString = dateKeyString + FetchTokenPublicKeyString() + empid;
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
                Issuer = SCMIssuer,
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
                var param = new { ACCESS_TOKEN = tokenString, TOKEN_CREATE_DATE = dateKeyString, EMP_NO = empid };
                MST_EMP_Repository.StoreAccessToken_Repository(param);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 共通鍵で署名されたトークンを検証するメソッド_test
        /// トークンの内容は
        /// aud: 空
        /// iss: empno(社員のID)
        /// exp: 期限切れ
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public static bool InspectToken(string empid)
        {
            //DBよりトークン文字列とトークン生成日付を取得
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { EMP_NO = empid };
            var resultModelData = MST_EMP_Repository.FetchAccessToken_Repository(param).First();
            // 復号鍵文字列
            var keyString = resultModelData.TOKEN_CREATE_DATE.ToString() + FetchTokenPublicKeyString() + empid;
            // 検証用正解トークン文字列
            var tokenString = resultModelData.ACCESS_TOKEN;

            var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            // トークン操作用のクラス
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();          

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



        /// <summary>
        /// 渡されたトークンを検証するメソッド
        /// トークンの内容は
        /// aud: 空
        /// iss: empno(社員のID)
        /// exp: 期限切れ
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public static bool InspectToken_direct(string token)
        {
            if (string.IsNullOrEmpty(token)) return false; 

            //DBよりトークン文字列とトークン生成日付を取得
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { ACCESS_TOKEN = token };
            string Inspectresult = MST_EMP_Repository.InspectAccessToken_Repository(param);
            return Inspectresult ==  "Valid"? true : false; 
        }
    }
}