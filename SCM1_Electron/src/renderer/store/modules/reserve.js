import router from '@/router'
// TODO: main.jsでimport済。各moduleでそれを使うには？
import Vue from 'vue'
import axios from 'axios'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const state = {
    isReserved: false
}

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
                }
            })
        }else{
            //解除処理
            Vue.http.delete('/emplocation/ClearEmpLocationInfo', {
                data: reserveInfo
            })
            .then((data) =>{
                if(data.ProcessStatus === constants.STATUS_OK)
                {
                    commit('reserve', false)
                }
            })
        }
    },
    // メッセージを出力させない為に共通を使用しない
    getIsReserved ({ commit }, empInfo) {
        axios.post('http://scm1test.azurewebsites.net/api/emplocation/FetchAllEmpLocationInfo', empInfo)
        .then((response) =>{
            if(response.data.ProcessStatus === constants.STATUS_OK)
            {
                commit('reserve', true)
            }
        }).catch((error) => {commit('error', messages.E_001)})
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}