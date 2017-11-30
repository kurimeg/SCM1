import router from '@/router'
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const state = {
    empInfo: [],
    seatInfo: []
}

const mutations = {
    fetchEmpInfo (state , empInfo) {
        state.empInfo = empInfo
    },
    initialize (state , seatInfo){
        state.seatInfo = seatInfo
    }
}

const getters = {
    searchEmp: (state, getters) => (seachText) => {
      return state.empInfo.filter(emp => emp.EMP_NM === seachText)
    }
  }

const actions = {
    firstview ({ commit }, token) {
        Vue.http.post('/seat/FetchSeatInfo', token)
        .then((data) =>{
            if(data.ProcessStatus === constants.STATUS_OK && data.Authenticated)
            {
                commit('initialize', data.SeatInfo)
            } 
        })
    },
    fetchEmpInfo({ commit }, token) {
        Vue.http.post('/emp/FetchEmpInfo', token)
        .then((data) =>{          
            if(data.ProcessStatus === constants.STATUS_OK)
            {
                commit('fetchEmpInfo', data.EmpInfo)
            } 
        })
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions,
    getters
}