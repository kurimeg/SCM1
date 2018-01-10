
const state = {
  floorPlaceDv: 'F01'
}

const mutations = {
  setTab (state, floorPlaceDv) {
    state.floorPlaceDv = floorPlaceDv
  }
}

export default {
  namespaced: true,
  state,
  mutations
}
