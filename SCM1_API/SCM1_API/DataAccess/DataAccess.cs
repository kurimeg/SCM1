using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;

namespace SCM1_API.DataAccess
{
    public static class DataAccess
    {
        //SQLの格納フォルダは固定なのでコンストで切る
        const string sqlFilePath = @"DataAccess\SQL";


        /// <summary>
        /// 接続文字列取得メソッド
        /// </summary>
        /// <returns></returns>
        public static string FetchConnectionString()
        {
            //既定の構成ファイルとは別のファイルを構成ファイルとして読み込む
            var configFile = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\DataAccess\DataAccess.config";
            var exeFileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            var config = ConfigurationManager.OpenMappedExeConfiguration(exeFileMap, ConfigurationUserLevel.None);

            return config.ConnectionStrings.ConnectionStrings["DBServerConnectionString"].ConnectionString;
        }


        /// <summary>
        /// SQLServer_SQL実行メソッド
        /// </summary>
        public static IEnumerable<dynamic> ThrowSQL(string sqlFileId, string sqlId, dynamic parameter = null)
        {
            //接続文字列の取得
            var ConnectionString = FetchConnectionString();
            //SQLの取得
            var SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery();

            IEnumerable<dynamic> returnObject;

            //データベース接続の準備
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    // データベースの接続開始
                    connection.Open();

                    // 実行するSQLの準備
                    returnObject = parameter == null? connection.Query(SQL).ToList() : connection.Query(SQL,(Object)parameter).ToList();
                    //★★↑返り値はList<object>で、一つのobjectの実体はDictionary型となっており、
                    //Keyにカラム名(物理名)、Valueに値が入っている
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    throw;
                }
            }
            return returnObject;
        }


        /// <summary>
        /// SQLServer_SQL実行メソッド_返り値をモデル指定
        /// </summary>
        public static List<T> ThrowSQLModel<T>(string sqlFileId, string sqlId, dynamic parameter = null)
        {
            //接続文字列の取得
            var ConnectionString = FetchConnectionString();
            //SQLの取得
            var SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery();

            List<T> returnObject;

            //データベース接続の準備
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    // データベースの接続開始
                    connection.Open();

                    // 実行するSQLの準備
                    returnObject = parameter == null ? connection.Query<T>(SQL).ToList() : connection.Query<T>(SQL, (Object)parameter).ToList();
                    //★★↑返り値はList<T>になるので、普通にモデルクラス
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    throw;
                }
            }
            return returnObject;
        }

    }
}