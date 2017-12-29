import Vue from 'vue'
import * as constants from '@/assets/constants'

const state = {
  seatInfo: [],
  empInfo: [],
  loginEmpName: ''
}

const getters = {
  // filterEmp: (state, getters) => (seachText) => {
  //   if (!seachText) return []

  //   let filteredEmp = state.seatInfo.filter(emp => {
  //     let knj = false
  //     let kana = false
  //     if (emp.EMP_NM) knj = emp.EMP_NM.replace(/\s+/g, '').startsWith(seachText)
  //     if (emp.EMP_KANA_NM) kana = emp.EMP_KANA_NM.replace(/\s+/g, '').startsWith(seachText)

  //     return knj || kana
  //   })
  // }
}

const mutations = {
  initialize (state, seatInfo) {
    state.seatInfo = seatInfo
  },
  fetchEmpInfo (state, empInfo) {
    state.empInfo = empInfo.empInfo
    state.loginEmpName = empInfo.loginEmpName
  },
  reset (state) {
    state.seatInfo = []
    state.empInfo = []
    state.loginEmpName = ''
  }
}

const actions = {
  firstview ({ commit }, token) {
    Vue.http.post('/seatwithemp/FetchSeatWithEmpInfo', token)
      .then((data) => {
        if (data.ProcessStatus === constants.STATUS_OK) {
          commit('initialize', data.SeatWithEmpInfo)
        }
      })
  },
  fetchEmpInfo ({ commit }, authInfo) {
    Vue.http.post('/emp/FetchEmpInfo', authInfo.token)
      .then((data) => {
        if (data.ProcessStatus === constants.STATUS_OK) {
          let loginEmpName = data.EmpInfo.find(emp => emp.EMP_NO === authInfo.loginEmpNO).DISPLAY_EMP_NM
          commit('fetchEmpInfo', { empInfo: data.EmpInfo, loginEmpName: loginEmpName })
        }
      })
  }
}

export default {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
}
