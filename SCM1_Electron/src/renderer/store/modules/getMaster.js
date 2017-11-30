import router from '@/router'
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const state = {
    
}

const mutations = {

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
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}