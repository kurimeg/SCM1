const state = {
    hasError: false,
    errorMessage: ''
}

const mutations = {
    success (state) {
        state.hasError = false
        state.errorMessage = ''
    },
    error (state, errorMessage) {
        state.hasError = true
        state.errorMessage = errorMessage
    }
}

const actions = {
    success ({ commit }) {
        commit('success')
    },
    error ({ commit }, errorMessage) {
        commit('error', errorMessage)
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}