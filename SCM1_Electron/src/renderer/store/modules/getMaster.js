import router from '@/router'
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const state = {
    seatInfo: [],
    empInfo: []
}

const mutations = {
    initialize (state , seatInfo){
        state.seatInfo = seatInfo
    },
    fetchEmpInfo (state , empInfo) {
        state.empInfo = empInfo
    }
}

const actions = {
    firstview ({ commit }, token) {
        Vue.http.post('/seatwithemp/FetchSeatWithEmpInfo', token)
        .then((data) =>{
            if(data.ProcessStatus === constants.STATUS_OK)
            {
                commit('initialize', data.SeatWithEmpInfo)
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
    actions
}