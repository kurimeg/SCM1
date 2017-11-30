import router from '@/router'
// TODO: main.jsでimport済。各moduleでそれを使うには？
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

// deleteのために実装(TODO:共通化できないか...)
import axios from 'axios'

// TODO: localStateとしたい。
const state = {
    isReserved: false
}

// TODO: もっときれいになるはず。
const mutations = {
    reserve (state , isReserved) {
        state.isReserved = isReserved
    }
}

const actions = {
    reserve ({ commit }, reserveInfo) {
        if(!state.isReserved){
            //登録処理
            Vue.http.put('/emplocation/RegisterEmpLocation',reserveInfo)
            .then((data) =>{
                if(data.ProcessStatus === constants.STATUS_OK)
                {
                    commit('reserve', true)
                    return true
                }
            })
        }else{
            //解除処理
            Vue.http({method: 'delete', url: '/emplocation/ClearEmpLocationInfo', data: reserveInfo})
            .then((data) =>{
                if(data.ProcessStatus === constants.STATUS_OK)
                {
                    commit('reserve', false)
                    return true
                }
            })
        }
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}