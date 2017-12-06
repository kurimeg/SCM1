using SCM1_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCM1_API.Model.ScreenModel.EmpLocationInfo;
using SCM1_API.Model.constants;

namespace SCM1_API.PresentationService
{
    public class EMP_LOCATION_PresentationService
    {
        private EMP_LOCATION_Service empLocation_Service;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EMP_LOCATION_PresentationService()
        {
            empLocation_Service = new EMP_LOCATION_Service();
        }

        /// <summary>
        /// ユーザー位置情報を取得する
        /// </summary>
        /// <returns></returns>
        public EmpLocationResponse FetchEmpLocationInfo(EmpLocationRequest req)
        {
            var ReturnModel = new EmpLocationResponse();

            //ユーザー位置情報の取得
            ReturnModel.EmpLocation = empLocation_Service.FetchEmpLocationInfo_Service(req.EmpNo, req.ClientAreaDv);

            //処理ステータスと取得結果を返す
            ReturnModel.ProcessStatus = ReturnModel.EmpLocation.Count() != 0 ? STATUS.OK : STATUS.NG;
            //NGの場合はメッセージを設定
            if (ReturnModel.ProcessStatus == STATUS.NG) ReturnModel.ResponseMessage = MESSAGE.MSG_FETCH_EMP_LOCATION_NG;
            return ReturnModel;
        }

        /// <summary>
        /// ユーザー位置情報を全件取得する
        /// </summary>
        /// <returns></returns>
        public EmpLocationResponse FetchAllEmpLocationInfo(EmpLocationRequest req)
        {
            var ReturnModel = new EmpLocationResponse();

            //ユーザー位置情報の全件取得
            ReturnModel.EmpLocation = empLocation_Service.FetchAllEmpLocationInfo_Service(req.ClientAreaDv);

            //処理ステータスと取得結果を返す
            ReturnModel.ProcessStatus = ReturnModel.EmpLocation.Count() != 0 ? STATUS.OK : STATUS.NG;
            //NGの場合はメッセージを設定
            if (ReturnModel.ProcessStatus == STATUS.NG) ReturnModel.ResponseMessage = MESSAGE.MSG_FETCH_EMP_LOCATION_NG;
            return ReturnModel;
        }

        /// <summary>
        /// ユーザー位置情報を消去する
        /// </summary>
        /// <returns></returns>
        public EmpLocationResponse ClearEmpLocationInfo(EmpLocationRequest req)
        {
            var ReturnModel = new EmpLocationResponse();

            //ユーザー位置情報の消去
            //処理ステータスと取得結果を返す
            ReturnModel.ProcessStatus = empLocation_Service.ClearEmpLocationInfo_Service(req.EmpNo, req.ClientAreaDv) ? STATUS.OK : STATUS.NG;
            //NGの場合はメッセージを設定
            if (ReturnModel.ProcessStatus == STATUS.NG) ReturnModel.ResponseMessage = MESSAGE.MSG_FETCH_EMP_LOCATION_NG;
            return ReturnModel;
        }

        /// <summary>
        /// ユーザー位置情報を固定席以外全件消去する
        /// </summary>
        /// <returns></returns>
        public EmpLocationResponse ClearAllEmpLocationInfo(EmpLocationRequest req)
        {
            var ReturnModel = new EmpLocationResponse();

            //ユーザー位置情報の全件消去
            //処理ステータスと取得結果を返す
            ReturnModel.ProcessStatus = empLocation_Service.ClearAllEmpLocationInfo_Service(req.ClientAreaDv) ? STATUS.OK : STATUS.NG;
            //NGの場合はメッセージを設定
            if (ReturnModel.ProcessStatus == STATUS.NG) ReturnModel.ResponseMessage = MESSAGE.MSG_FETCH_EMP_LOCATION_NG;
            return ReturnModel;
        }


        /// <summary>
        /// ユーザー位置情報を登録する
        /// </summary>
        /// <returns></returns>
        public EmpLocationResponse RegisterLocation(EmpLocationRequest req)
        {

            //座席が空いてなければ終了
            var isVacant = empLocation_Service.FetchLocationStatus_Service(req.seatNo);
            if (isVacant.Count() > 0 )
            {

                return new EmpLocationResponse()
                {
                    ProcessStatus = STATUS.NG,
                    ResponseMessage = MESSAGE.MSG_GET_EMP_LOCATION_NG,
                };
            }

            //その人にとって最初の席かチェック
            int? onLocationEmpId = empLocation_Service.hasLocationCheckByEmpId_Service(int.Parse(req.EmpNo));

            if (onLocationEmpId == 0)
            {
                //最初の席だったら登録して終了
                empLocation_Service.RegisterEmpLocation_Service(int.Parse(req.EmpNo), req.seatNo, fixedFlg:req.FixedFlg);
            }
            else
            {
                //最初の席じゃないなら更新
                empLocation_Service.ReRegiseterEmpLocation_Service(int.Parse(req.EmpNo), req.seatNo, fixedFlg: req.FixedFlg);
            }

            return new EmpLocationResponse()
            {
                ProcessStatus = STATUS.OK,
                ResponseMessage = MESSAGE.MSG_OK,
            };
        }
    }
}