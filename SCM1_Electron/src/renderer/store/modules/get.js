import router from '@/router'
// TODO: main.jsでimport済。各moduleでそれを使うには？
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

// TODO: localStateとしたい。
const state = {
    isLogged: !!localStorage.getItem('authInfo'),
    token: ''
}

// TODO: もっときれいになるはず。
const mutations = {
    login (state , data) {
        state.isLogged = true
        state.token = data
    }
}

const actions = {
    firstview ({ commit }, token) {
        Vue.http.post('/seat/FetchSeatInfo', token)
        .then((data) =>{
            console.log(token)
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