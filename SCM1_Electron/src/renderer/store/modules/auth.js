import router from '@/router'
import axios from 'axios'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const state = {
    isLogged: !!localStorage.getItem('token'),
    hasError: false,
    errorMessage: ''
}

const mutations = {
    login (state) {
        state.isLogged = true
    },
    error (state, errorMessage) {
        state.hasError = true
        state.errorMessage = errorMessage
    }
}

const actions = {
    login ({ commit }, authInfo) {
        axios.post('http://scm1test.azurewebsites.net/api/auth',authInfo)
        .then((response) =>{
            if(response.data.Status === constants.STATUS_OK && response.data.Authenticated)
            {
                localStorage.setItem('token', response.data.Token)
                commit('login')
                router.replace('chart')
            } 
            else
            {
                commit('error', messages.E_001)
            }
        }).catch((error) => {
            commit('error', messages.E_001)
    });

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