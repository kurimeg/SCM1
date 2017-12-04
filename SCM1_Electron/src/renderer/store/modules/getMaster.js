import router from '@/router'
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const state = {
    seatInfo: [],
    empInfo: [],
    allEmpLocationInfo: []
}

const mutations = {
    initialize (state , seatInfo){
        state.seatInfo = seatInfo
    },
    fetchEmpInfo (state , empInfo) {
        state.empInfo = empInfo
    },
    fetchAllEmpLocationInfo (state , allEmpLocationInfo) {
        state.allEmpLocationInfo = allEmpLocationInfo
    }
}

const actions = {
    firstview ({ commit }, token) {
        Vue.http.post('/seat/FetchSeatInfo', token)
        .then((data) =>{
            if(data.ProcessStatus === constants.STATUS_OK)
            {
                commit('initialize', data.SeatInfo)
            } 
        })
    },
    fetchAllEmpLocationInfo({ commit }, token) {
        Vue.http.post('/emplocation/FetchAllEmpLocationInfo', token)
        .then((data) =>{          
            if(data.ProcessStatus === constants.STATUS_OK)
            {
                commit('fetchAllEmpLocationInfo', data.EmpLocation)
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