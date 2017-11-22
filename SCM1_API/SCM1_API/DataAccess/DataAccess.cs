using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using SCM1_API.Model.constants;
using SCM1_API.Util;

namespace SCM1_API.DataAccess
{
    public static class DataAccess
    {
        //SQLの格納フォルダは固定なのでコンストで切る
        const string sqlFilePath = @"DataAccess\SQL";
        const string DAconfigFilePath = @"\DataAccess\DataAccess.config";

        /// <summary>
        /// 接続文字列取得メソッド
        /// </summary>
        /// <returns></returns>
        public static string FetchConnectionString()
        {
            //既定の構成ファイルとは別のファイルを構成ファイルとして読み込む
            var configFile = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + DAconfigFilePath;
            var exeFileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            var config = ConfigurationManager.OpenMappedExeConfiguration(exeFileMap, ConfigurationUserLevel.None);

            return config.ConnectionStrings.ConnectionStrings["DBServerConnectionString"].ConnectionString;
        }


        /// <summary>
        /// SQLServer_SQL実行メソッド
        /// </summary>
        public static IEnumerable<dynamic> ThrowSQL(string sqlFileId, string sqlId, dynamic parameter = null,DBAccessType dbAccessType = DBAccessType.Select)
        {
            //接続文字列の取得
            var ConnectionString = FetchConnectionString();
            //SQLの取得
            string SQL = string.Empty;
            switch(dbAccessType)
            {
                case DBAccessType.Select:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery();
                    break;
                case DBAccessType.Insert:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery(SqlType.insert);
                    break;
                case DBAccessType.Update:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery(SqlType.update);
                    break;
                case DBAccessType.Delete:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery(SqlType.delete);
                    break;
            }

            IEnumerable<dynamic> returnObject;

            //データベース接続の準備
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    Logger.Write(string.Format("[SQL]{0} Params:{1}", SQL, Convert.ToString((object)parameter)));
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
        public static List<T> ThrowSQLModel<T>(string sqlFileId, string sqlId, dynamic parameter = null, DBAccessType dbAccessType = DBAccessType.Select)
        {
            //接続文字列の取得
            var ConnectionString = FetchConnectionString();
            //SQLの取得
            string SQL = string.Empty;
            switch (dbAccessType)
            {
                case DBAccessType.Select:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery();
                    break;
                case DBAccessType.Insert:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery(SqlType.insert);
                    break;
                case DBAccessType.Update:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery(SqlType.update);
                    break;
                case DBAccessType.Delete:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery(SqlType.delete);
                    break;
            }

            List<T> returnObject;

            //データベース接続の準備
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    Logger.Write(string.Format("[SQL]{0} Params:{1}", SQL, Convert.ToString((object)parameter)));
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

        public static dynamic ThrowSQLModelFirst<T>(string sqlFileId, string sqlId, dynamic parameter = null, DBAccessType dbAccessType = DBAccessType.Select)
        {
            //接続文字列の取得
            var ConnectionString = FetchConnectionString();
            //SQLの取得
            string SQL = string.Empty;
            switch (dbAccessType)
            {
                case DBAccessType.Select:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery();
                    break;
                case DBAccessType.Insert:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery(SqlType.insert);
                    break;
                case DBAccessType.Update:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery(SqlType.update);
                    break;
                case DBAccessType.Delete:
                    SQL = new QueryXmlBuilder<dynamic>(sqlFilePath, sqlFileId, sqlId, parameter).GetQuery(SqlType.delete);
                    break;
            }

            dynamic returnObject;

            //データベース接続の準備
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    Logger.Write(string.Format("[SQL]{0} Params:{1}", SQL, Convert.ToString((object)parameter)));
                    // データベースの接続開始
                    connection.Open();

                    // 実行するSQLの準備
                    returnObject = parameter == null ? connection.Query<T>(SQL).ToList() : connection.Query<T>(SQL, (Object)parameter).ToList();
                    //★★↑返り値はList<T>になるので、普通にモデルクラス
                    if(returnObject.Count == 0)
                    {
                        return null;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    throw;
                }
            }
            return returnObject.First();
        }

    }
}