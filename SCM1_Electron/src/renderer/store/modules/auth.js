import router from '@/router'
// TODO: main.jsでimport済。各moduleでそれを使うには？
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

// TODO: localStateとしたい。
const state = {
    isLogged: !!localStorage.getItem('authInfo'),
    token: '',
    isGuest: false
}

// TODO: もっときれいになるはず。
const mutations = {
    login (state , auth) {
        state.isLogged = true
        state.token = auth.token
        state.isGuest = auth.isGuest
    },
    logout (state) {
        state.isLogged = false
        state.token = ''
        state.isGuest = false
    }
}

const actions = {
    login ({ commit }, authInfo) {
        Vue.http.post('/auth',authInfo)
        .then((data) =>{
            if(data.ProcessStatus === constants.STATUS_OK && data.Authenticated)
            {
                localStorage.setItem('authInfo', JSON.stringify(authInfo))
                commit('login', { token: data.Token, isGuest: false })
                router.replace('chart')
            } 
        })
    },
    guestLogin ({ commit }, authInfo) {
        localStorage.setItem('authInfo', JSON.stringify(authInfo.authInfo))
        commit('login', { token: authInfo.token, isGuest: true })
        router.replace('chart')
    },
    logout ({ commit }) {
        localStorage.removeItem('authInfo')
        commit('logout')
        router.replace('/')
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}