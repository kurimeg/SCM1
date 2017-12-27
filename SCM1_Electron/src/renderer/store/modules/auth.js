import Vue from 'vue'
import router from '@/router'
import * as constants from '@/assets/constants'

const state = {
  isLogged: !!localStorage.getItem('authInfo'),
  token: '',
  isGuest: false
}

const mutations = {
  login (state, auth) {
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
    Vue.http.post('/auth', authInfo)
      .then((data) => {
        if (data.ProcessStatus === constants.STATUS_OK && data.Authenticated) {
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
  logout ({ commit, rootState }) {
    localStorage.removeItem('authInfo')
    // TODO: まとめてstateを初期化したい
    commit('getMaster/reset', null, { root: true })
    commit('getUserPath/reset', null, { root: true })
    commit('reserve/reset', null, { root: true })
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
