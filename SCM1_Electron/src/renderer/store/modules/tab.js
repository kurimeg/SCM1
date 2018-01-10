
const state = {
  tabName: ''
}

const mutations = {
  setTab (state, tabName) {
    state.tabName = tabName
  }
}

export default {
  namespaced: true,
  state,
  mutations
}
