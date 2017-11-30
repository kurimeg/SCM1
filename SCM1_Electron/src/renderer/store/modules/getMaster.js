import router from '@/router'
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const state = {
    empInfo: []
}

const mutations = {
    fetchEmpInfo (state , empInfo) {
        state.empInfo = empInfo
    }
}

const getters = {
    searchEmp: (state, getters) => (seachText) => {
        if(!seachText) return []
        return state.empInfo.filter(emp => emp.EMP_NM.replace(/\s+/g, "").startsWith(seachText) || emp.EMP_KANA_NM.replace(/\s+/g, "").startsWith(seachText))
    }
  }

const actions = {
    firstview ({ commit }, token) {
        Vue.http.post('/seat/FetchSeatInfo', token)
        .then((data) =>{
            if(data.ProcessStatus === constants.STATUS_OK && data.Authenticated)
            {
                commit('login', data.SeatInfo)
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