import router from '@/router'
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const state = {
    empInfo: []
}

// TODO: もっときれいになるはず。
const mutations = {
    fetchEmpInfo (state , empInfo) {
        state.empInfo = [{EMP_NO: 47003, EMP_NM: "栗原萌実"}]
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
        Vue.http.post('/seat/FetchEmpInfo', token)
        .then((data) =>{
            commit('fetchEmpInfo', data.SeatInfo)
            if(data.ProcessStatus === constants.STATUS_OK && data.Authenticated)
            {
                
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