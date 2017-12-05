import router from '@/router'
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const state = {
    userPath:[],
    isSearched:''
}

const mutations = {
    setPath (state , userpath , bool){
        state.userPath = userpath
        state.isSearched = bool
    }
}

const actions = {
    getuserpath ({ commit }, empNo , token) {
        Vue.http.post('/emplocation/FetchAllEmpLocationInfo', empNo , token)
        .then((data) =>{
            if(data.ProcessStatus === constants.STATUS_OK)
            {
                commit('setPath', data.EmpLocation, true)
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