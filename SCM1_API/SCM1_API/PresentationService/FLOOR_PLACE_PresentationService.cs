using SCM1_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCM1_API.Model.ScreenModel.FloorPlace;
using SCM1_API.Model.constants;

namespace SCM1_API.PresentationService
{
    public class FLOOR_PLACE_PresentationService
    {
        private FLOOR_PLACE_Service floorPlace_Service;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FLOOR_PLACE_PresentationService()
        {
            floorPlace_Service = new FLOOR_PLACE_Service();
        }

        /// <summary>
        /// 事業所区分/区分名を全件取得する
        /// </summary>
        /// <returns></returns>
        public FloorPlaceResponse FetchAllFloorPlace()
        {
            var returnModel = new FloorPlaceResponse();
            returnModel.floorPlaces = floorPlace_Service.FetchAllFloorPlace_Service();

            returnModel.ProcessStatus = returnModel.floorPlaces.Count() != 0 ? STATUS.OK : STATUS.NG;
            if (returnModel.ProcessStatus == STATUS.NG) returnModel.ResponseMessage = MESSAGE.MSG_FETCH_ALL_FLOOR_PLACE;

            return returnModel;
        }
    }
}