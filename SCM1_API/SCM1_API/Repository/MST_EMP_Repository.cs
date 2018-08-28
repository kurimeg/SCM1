﻿using SCM1_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Repository
{
    public class MST_EMP_Repository
    {
        private const string SQL_FILE_NM = "MST_EMP";


        /// <summary>
        /// 社員情報取得
        /// </summary>
        /// <param name="TargetEMP_NO">絞込条件に使用する社員番号</param>
        /// <returns></returns>
        public static IEnumerable<MST_EMP> FetchEMPInfo_Repository(dynamic TargetEMP_NO)
        {
            //                                                         ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            return DataAccess.DataAccess.SELECT_Model<MST_EMP>(SQL_FILE_NM, "FetchEmpInfo", TargetEMP_NO);
            //                                                                       ↑左のxmlファイル内の実際に呼び出すSQLのID
        }

        /// <summary>
        /// 社員情報取得_ログイン用
        /// </summary>
        /// <param name="TargetEMP_NO">絞込条件に使用する社員番号</param>
        /// <returns></returns>
        public static IEnumerable<MST_EMP> FetchEMPInfo_ToAuth_Repository(dynamic TargetEMP_NO)
        {
            //                                                         ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            return DataAccess.DataAccess.SELECT_Model<MST_EMP>(SQL_FILE_NM, "FetchEmpInfo_auth", TargetEMP_NO);
            //                                                                       ↑左のxmlファイル内の実際に呼び出すSQLのID
        }

        /// <summary>
        /// 社員情報全件取得
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<MST_EMP> FetchAllEMPInfo_Repository()
        {
            //                                                      ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            return DataAccess.DataAccess.SELECT_Model<MST_EMP>(SQL_FILE_NM, "FetchAllEmpInfo");
            //                                                                       ↑左のxmlファイル内の実際に呼び出すSQLのID
        }

        /// <summary>
        /// 社員情報を登録、更新する
        /// </summary>
        /// <param name="dbmodel">登録/更新する社員情報</param>
        /// <returns></returns>
        public static int UpdateEMPInfo_Repository(dynamic dbmodel)
        {
            return DataAccess.DataAccess.ExecuteSQL(SQL_FILE_NM, "UpdateEMPInfo",dbmodel,Model.constants.DBAccessType.Update);
        }

        /// <summary>
        /// 社員情報を削除する
        /// </summary>
        /// <param name="TargetEMP_NO">削除する社員番号</param>
        /// <returns></returns>
        public static int ClearEMPInfo_Repository(dynamic TargetEMP_NO)
        {
            return DataAccess.DataAccess.ExecuteSQL(SQL_FILE_NM, "ClearEMPInfo", TargetEMP_NO, Model.constants.DBAccessType.Delete);
        }

        /// <summary>
        /// アクセストークン保存
        /// </summary>
        /// <param name="AccessToken_and_TargetEMP_NO">アクセストークンと絞込条件に使用する社員番号</param>
        /// <returns></returns>
        public static void StoreAccessToken_Repository(dynamic AccessToken_and_TargetEMP_NO)
        {
            //                                 ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            DataAccess.DataAccess.ExecuteSQL(SQL_FILE_NM, "StoreAccessToken", AccessToken_and_TargetEMP_NO,Model.constants.DBAccessType.Update);
            //                                                ↑左のxmlファイル内の実際に呼び出すSQLのID
        }

        /// <summary>
        /// アクセストークン取得
        /// </summary>
        /// <param name="AccessToken_and_TargetEMP_NO">アクセストークンと絞込条件に使用する社員番号</param>
        /// <returns></returns>
        public static IEnumerable<MST_EMP> FetchAccessToken_Repository(dynamic TargetEMP_NO)
        {
            //                                                   ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
            return DataAccess.DataAccess.SELECT_Model<MST_EMP>(SQL_FILE_NM, "FetchAccessToken", TargetEMP_NO);
            //                                                                    ↑左のxmlファイル内の実際に呼び出すSQLのID
        }

        /// <summary>
        /// アクセストークン整合性チェック
        /// </summary>
        /// <param name="AccessToken_and_TargetEMP_NO">アクセストークンと絞込条件に使用する社員番号</param>
        /// <returns></returns>
        public static string InspectAccessToken_Repository(dynamic RecievedAccessToken)
        {
            //                                                           ↓DataAccess\SQLフォルダ内のSQLを記述したxmlファイル名
             var returnobject = DataAccess.DataAccess.ExecuteSQL(SQL_FILE_NM, "FetchAccessToken_Direct", RecievedAccessToken);
            //                                                                            ↑左のxmlファイル内の実際に呼び出すSQLのID
            return returnobject.Count > 0? "Valid": "Invalid";
        }
    }
}