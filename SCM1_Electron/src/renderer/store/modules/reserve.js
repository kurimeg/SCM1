import Vue from 'vue'
import axios from 'axios'
import * as constants from '@/assets/constants'

const state = {
  isReserved: false,
  reservedSeatNo: ''
}

const mutations = {
  reserve (state, reserve) {
    state.isReserved = reserve.isReserved
    state.reservedSeatNo = reserve.seatNo
  },
  reset (state) {
    state.isReserved = false
    state.reservedSeatNo = ''
  }
}

const actions = {
  reserve ({ commit }, reserveInfo) {
    // 登録処理
    Vue.http.put('/emplocation/RegisterEmpLocation', reserveInfo)
      .then((data) => {
        if (data.ProcessStatus === constants.STATUS_OK) {
          commit('reserve', { isReserved: true, seatNo: reserveInfo.seatNo })
        }
      })
  },
  release ({ commit }, reserveInfo) {
    // 解除処理
    Vue.http.delete('/emplocation/ClearEmpLocationInfo', {
      data: reserveInfo
    })
      .then((data) => {
        if (data.ProcessStatus === constants.STATUS_OK) {
          commit('reserve', { isReserved: false, seatNo: '' })
        }
      })
  },
  // メッセージを出力させない為に共通を使用しない
  getIsReserved ({ commit }, empInfo) {
    const baseUrl = process.env.NODE_ENV === 'development'
      ? `http://scm1test.azurewebsites.net/api`
      : 'http://scm1api.azurewebsites.net/api'

    axios.post(baseUrl + '/emplocation/FetchAllEmpLocationInfo', empInfo)
      .then((response) => {
        if (response.data.ProcessStatus === constants.STATUS_OK) {
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
