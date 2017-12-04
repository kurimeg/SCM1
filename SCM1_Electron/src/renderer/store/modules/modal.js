import * as constants from '@/assets/constants'

const state = {
    modalName: '',
    actionName: '',
    message: ''
  }
  
  const mutations = {
    setModal (state, modalInfo) {
      state.modalName = modalInfo.modalName
      state.message = modalInfo.message
      state.actionName = modalInfo.actionName
    },
    hideModal (state) {
      state.modalName = ''
      state.message = ''
    }
  }
  
  const actions = {
    showAlert ({ commit }, modalInfo) {
      commit('setModal', { modalName: constants.MODAL_NM_ALERT, message: modalInfo.message, actionName: modalInfo.actionName })
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