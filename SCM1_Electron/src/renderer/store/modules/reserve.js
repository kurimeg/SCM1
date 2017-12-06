import router from '@/router'
// TODO: main.jsでimport済。各moduleでそれを使うには？
import Vue from 'vue'
import axios from 'axios'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const state = {
    isReserved: false,
    reservedSeatNo: ''
}

const mutations = {
    reserve (state , reserve) {
        state.isReserved = reserve.isReserved
        state.reservedSeatNo = reserve.seatNo
    }
}

const actions = {
    reserve ({ commit }, reserveInfo) {
        if(!state.isReserved){
            //登録処理
            Vue.http.put('/emplocation/RegisterEmpLocation',reserveInfo)
            .then((data) =>{
                if(data.ProcessStatus === constants.STATUS_OK)
                {
                    commit('reserve', { isReserved: true, seatNo: reserveInfo.seatNo })
                }
            })
        }else{
            //解除処理
            Vue.http.delete('/emplocation/ClearEmpLocationInfo', {
                data: reserveInfo
            })
            .then((data) =>{
                if(data.ProcessStatus === constants.STATUS_OK)
                {
                    commit('reserve', { isReserved: false, seatNo: '' })
                }
            })
        }
    },
    // メッセージを出力させない為に共通を使用しない
    getIsReserved ({ commit }, empInfo) {
        axios.post('http://scm1test.azurewebsites.net/api/emplocation/FetchAllEmpLocationInfo', empInfo)
        .then((response) => {
            if(response.data.ProcessStatus === constants.STATUS_OK)
            {
                commit('reserve', { isReserved: true, seatNo: response.data.EmpLocation[0].SEAT_NO })
            }
        })
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}