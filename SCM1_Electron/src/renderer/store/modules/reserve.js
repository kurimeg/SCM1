import router from '@/router'
// TODO: main.jsでimport済。各moduleでそれを使うには？
import axios from 'axios'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

// TODO: localStateとしたい。
const state = {
    isReserved: false,
    hasError: false,
    errorMessage: ''
}

// TODO: もっときれいになるはず。
const mutations = {
    reserve (state , isReserved) {
        state.isReserved = isReserved
        state.hasError = false
        state.errorMessage = ''
    },
    error (state, errorMessage) {
        state.isReserved = false
        state.hasError = true
        state.errorMessage = errorMessage
    }
}

const actions = {
    reserve ({ commit }, reserveInfo) {
        if(!state.isReserved){
            //登録処理
            axios.put('http://scm1test.azurewebsites.net/api/emplocation/RegisterEmpLocation',reserveInfo)
            .then((response) =>{
                if(response.data.ResponseMessage != "処理に成功しました。")
                {
                    commit('error', response.data.ResponseMessage)
                }
                else
                {
                    commit('reserve', true)
                }
            }).catch((error) => {
                commit('error', messages.E_001)
            })
        }else{
            //解除処理
            axios.put('http://scm1test.azurewebsites.net/api/emplocation/RegisterEmpLocation',reserveInfo)
            .then((response) =>{
                if(response.data.ResponseMessage != "処理に成功しました。")
                {
                    commit('error', response.data.ResponseMessage)
                }
                else
                {
                    commit('reserve', false)
                }
            }).catch((error) => {
                commit('error', messages.E_001)
            })
        }
        return state.hasError
        
        // GET sample
        // axios.get('http://scm1test.azurewebsites.net/api/emp/testget/', {
        //     params: {
        //         value : 47003
        //     }
        // })
        // .then((response) =>{
        //     console.log(response)
        // })
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}