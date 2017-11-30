import router from '@/router'
// TODO: main.jsでimport済。各moduleでそれを使うには？
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

// TODO: localStateとしたい。
const state = {
    show: false   
}

// TODO: もっときれいになるはず。
const mutations = {
    show (state) {
        state.show = true
    },
    hide (state) {
        state.show = false
    }

}

const actions = {

}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}