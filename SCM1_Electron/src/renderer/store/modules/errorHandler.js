const state = {
    show: false,
    errorMessage: ''
}

const mutations = {
    clearError (state) {
        state.show = false
        state.errorMessage = ''
    },
    showError (state, errorMessage) {
        state.show = true
        state.errorMessage = errorMessage
    }
}

const actions = {
    clearError ({ commit }) {
        commit('clearError')
    },
    showError ({ commit }, errorMessage) {
        commit('showError', errorMessage)
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}