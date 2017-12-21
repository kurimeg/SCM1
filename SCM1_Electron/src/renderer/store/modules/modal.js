import * as constants from '@/assets/constants'

const state = {
  modalName: '',
  actionName: '',
  param: [],
  message: ''
}

const mutations = {
  setModal (state, modalInfo) {
    state.modalName = modalInfo.modalName
    state.message = modalInfo.message
    state.actionName = modalInfo.actionName
    state.param = modalInfo.param
  },
  hideModal (state) {
    state.modalName = ''
    state.message = ''
    state.actionName = ''
    state.param = ''
  },
  changeParam (state, changedParam) {
    state.param = changedParam
  }
}

const actions = {
  showAlert ({ commit }, modalInfo) {
    commit('setModal', { modalName: constants.MODAL_NM_ALERT, message: modalInfo.message, actionName: modalInfo.actionName, param: modalInfo.param })
  },
  showError ({ commit }, message) {
    commit('setModal', { modalName: constants.MODAL_NM_ERROR, message: message })
  },
  showAlertReg ({ commit }, modalInfo) {
    commit('setModal', { modalName: constants.MODAL_NM_REGALERT, message: modalInfo.message, actionName: modalInfo.actionName, param: modalInfo.param })
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}
