
const state = {
  floorPlaceDv: 'F01'
<<<<<<< HEAD
=======
}

const getters = {
  filterSeat: (state, getters, rootState) => {
    return rootState.getMaster.seatInfo.filter(seat => seat.FLOOR_PLACE_DV === state.floorPlaceDv)
  }
>>>>>>> 5fde66c9acadf126d7c9035a5ce97bdbd62e87ab
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
