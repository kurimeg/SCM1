const state = {
    show: false,
    alertMessage: '',
    isconfirmed: false
}

const mutations = {
    clearAlert (state) {
        state.show = false
        state.alertMessage = ''
    },
    showAlert (state, alertMessage) {
        state.show = true
        state.alertMessage = alertMessage
    }
}

const actions = {
    clearAlert ({ commit }) {
        commit('clearAlert')
    },
    showAlert ({ commit }, alertMessage) {
        commit('showAlert', alertMessage)
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}