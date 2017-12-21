const state = {
  show: false
}

const mutations = {
  showLoading (state, bool) {
    state.show = bool
  }
}

export default {
  namespaced: true,
  state,
  mutations
}
