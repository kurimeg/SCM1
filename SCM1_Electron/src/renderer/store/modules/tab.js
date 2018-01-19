
const state = {
  floorPlaceDv: 'F01'
}

const getters = {
  filterSeat: (state, getters, rootState) => {
    return rootState.getMaster.seatInfo.filter(seat => seat.FLOOR_PLACE_DV === state.floorPlaceDv)
  }
}

const mutations = {
  setTab (state, floorPlaceDv) {
    state.floorPlaceDv = floorPlaceDv
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  getters
}
