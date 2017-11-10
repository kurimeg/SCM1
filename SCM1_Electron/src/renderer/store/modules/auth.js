const state = {
    loggedIn: false
}

const mutations = {
    login (state) {
        state.loggedIn = true
      }
    //   logout (state) {
    //     state.loggedIn = false
    //   }
}
  
const actions = {
    login ({ commit }, payload) {
        commit('login')
        payload.router.push('/chart')
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}