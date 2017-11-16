import router from '@/router'
// TODO: main.jsでimport済。各moduleでそれを使うには？
import axios from 'axios'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

// TODO: localStateとしたい。
const state = {
    isLogged: !!localStorage.getItem('authInfo'),
    token: '',
    hasError: false,
    errorMessage: ''
}

// TODO: もっときれいになるはず。
const mutations = {
    login (state , token) {
        state.isLogged = true
        state.token = token
        state.hasError = false
        state.errorMessage = ''
    },
    error (state, errorMessage) {
        state.isLogged = false
        state.token = ''
        state.hasError = true
        state.errorMessage = errorMessage
    },
    logout (state) {
        state.isLogged = false
        state.token = ''
        state.hasError = false
        state.errorMessage = ''
    }
}

const actions = {
    login ({ commit }, authInfo) {
        axios.post('http://scm1test.azurewebsites.net/api/auth',authInfo)
        .then((response) =>{
            if(response.data.Status === constants.STATUS_OK && response.data.Authenticated)
            {
                localStorage.setItem('authInfo', JSON.stringify(authInfo))
                commit('login', response.data.Token)
                router.replace('chart')
            } 
            else
            {
                commit('error', messages.E_001)
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
    },
    logout ({ commit }) {
        localStorage.removeItem('authInfo')
        commit('logout')
        router.replace('login')
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}