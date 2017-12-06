import router from '@/router'
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const state = {
    userPath:[]
}

const mutations = {
    setPath (state , userpath){
        state.userPath = userpath.EmpLocation
    }
}

const actions = {
    getuserpath ({ commit }, empNo , token) {
        Vue.http.post('/emplocation/FetchAllEmpLocationInfo', empNo , token)
        .then((data) =>{
            if(data.ProcessStatus === constants.STATUS_OK)
            {
                commit('setPath', { EmpLocation: data.EmpLocation, isSearched: true })
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