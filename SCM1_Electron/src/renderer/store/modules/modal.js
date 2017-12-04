import * as constants from '@/assets/constants'

const state = {
    modalName: '',
    message: ''
  }
  
  const mutations = {
    setModal (state, modalInfo) {
      state.modalName = modalInfo.modalName
      state.message = modalInfo.message
    },
    hideModal (state) {
      state.modalName = ''
      state.message = ''
    }
  }
  
  const actions = {
    showAlert ({ commit }, message) {
      commit('setModal', { modalName: constants.MODAL_NM_ALERT, message: message })
    },
    showError ({ commit }, message) {
      commit('setModal', { modalName: constants.MODAL_NM_ERROR, message: message })
    },
  }
  
  export default {
    namespaced: true,
    state,
    mutations,
    actions
  }