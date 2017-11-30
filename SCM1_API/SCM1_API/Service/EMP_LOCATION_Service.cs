using SCM1_API.Model;
using SCM1_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Service
{
    public class EMP_LOCATION_Service
    {
        private const int DefaultAreadv = (int)Model.constants.FLOOR_PLACE_DV.SINURA;

        /// <summary>
        /// ユーザー位置情報を取得する
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_EMP_LOCATION> FetchEmpLocationInfo_Service(string PostedEmpNo,int postedAreaDv = DefaultAreadv)
        {
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { EMP_NO = PostedEmpNo, FLOOR_PLACE_DV = postedAreaDv };
            return T_EMP_LOCATION_Repository.FetchEmpLocationInfo_Repository(param);
        }

        /// <summary>
        /// ユーザー位置情報を全件取得する
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_EMP_LOCATION> FetchAllEmpLocationInfo_Service(int postedAreaDv = DefaultAreadv)
        {
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { FLOOR_PLACE_DV = postedAreaDv };
            return T_EMP_LOCATION_Repository.FetchAllEmpLocationInfo_Repository(param);
        }

        /// <summary>
        /// ユーザー位置情報を消去する
        /// </summary>
        /// <returns></returns>
        public bool ClearEmpLocationInfo_Service(string PostedEmpNo, int postedAreaDv = DefaultAreadv)
        {
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { EMP_NO = PostedEmpNo, FLOOR_PLACE_DV = postedAreaDv };
            return T_EMP_LOCATION_Repository.ClearEmpLocationInfo_Repository(param);
        }

        /// <summary>
        /// ユーザー位置情報を固定席以外全件消去する
        /// </summary>
        /// <returns></returns>
        public bool ClearAllEmpLocationInfo_Service(int postedAreaDv = DefaultAreadv)
        {
            //                ↓はxml内に記述されたSQLの「#」で括られた部分
            var param = new { FLOOR_PLACE_DV = postedAreaDv };
            return T_EMP_LOCATION_Repository.ClearAllEmpLocationInfo_Repository(param);
        }

        /// <summary>
        /// ユーザー位置情報のステータスを取得する
        /// </summary>
        /// <param name="seatNo"></param>
        /// <returns></returns>
        public IEnumerable<T_EMP_LOCATION> FetchLocationStatus_Service(string seatNo)
        {
            var param = new { seat_NO = seatNo };
            return T_EMP_LOCATION_Repository.FetchLocationStatus(param);
        }

        /// <summary>
        /// 対象ユーザーが席をすでに席をとっているかチェック
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public int? hasLocationCheckByEmpId_Service(int empId)
        {
            var param = new { EMP_NO = empId };
            return T_EMP_LOCATION_Repository.hasLocationCheckByEmpId(param);
        }

        /// <summary>
        /// 対象ユーザーの席情報を登録する
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="seatNo"></param>
        public bool RegisterEmpLocation_Service(int empId, string seatNo, string phoneNo = null)
        {
            var param = new { EMP_NO = empId, seat_NO = seatNo, EXTENSION_LINE_NO  = phoneNo};
            return T_EMP_LOCATION_Repository.RegisterEmpLocation(param) > 0? true: false;
        }

        /// <summary>
        /// 対象ユーザーの席情報を更新する
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="seatNo"></param>
        public bool ReRegiseterEmpLocation_Service(int empId, string seatNo)
        {
            var param = new { EMP_NO = empId, seat_NO = seatNo };
            return T_EMP_LOCATION_Repository.ReRegisterEmpLocation(param) > 0 ? true : false;
        }
    }
}