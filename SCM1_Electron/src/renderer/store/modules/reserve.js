import router from '@/router'
// TODO: main.jsでimport済。各moduleでそれを使うには？
import axios from 'axios'

// TODO: localStateとしたい。
const state = {
    token: '',
    hasError: false,
    errorMessage: ''
}

// TODO: もっときれいになるはず。
const mutations = {
    reserve (state , token) {
        state.token = token
        state.hasError = false
        state.errorMessage = ''
    },
    error (state, errorMessage) {
        state.token = ''
        state.hasError = true
        state.errorMessage = errorMessage
    }
}

const actions = {
    reserve ({ commit }, reserveInfo) {
        axios.post('http://scm1test.azurewebsites.net/api/auth',reserveInfo)
        .then((response) =>{
            if(response.data.ProcessStatus === constants.STATUS_OK && response.data.Authenticated)
            {
                commit('reserve', 'OK')
            } 
            else
            {
                commit('error', response.data.ResponseMessage)
            }
        }).catch((error) => {
            commit('error', messages.E_001)
    })

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