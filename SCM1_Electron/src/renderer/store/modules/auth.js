import router from '@/router'
import axios from 'axios'

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

const data = { token :"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE1MTA2NTE5MjEsImV4cCI6MTUxMDY1NTUyMSwiaWF0IjoxNTEwNjUxOTIxLCJpc3MiOiJTQ01Jc3N1ZXIifQ.kmIZaixhSrmkT-b_3GjMO7GKmhm-TEaFUKD9kq2tEw8"}
const client = axios.create({
    'Content-Type': 'application/x-www-form-urlencoded'
})
const actions = {
    login ({ commit }, authInfo) {
        // axios.post('http://scm1test.azurewebsites.net/api/emp/InspectToken',"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE1MTA2NTE5MjEsImV4cCI6MTUxMDY1NTUyMSwiaWF0IjoxNTEwNjUxOTIxLCJpc3MiOiJTQ01Jc3N1ZXIifQ.kmIZaixhSrmkT-b_3GjMO7GKmhm-TEaFUKD9kq2tEw8")
        // .then((response) =>{
        //     if(response.data.Item1)
        //     {
        //         localStorage.setItem('token', response.data.Item2)
        //         commit('login')
        //         router.replace('chart')
        //     } 
        //     else
        //     {
        //         commit('error', response.data.Item2)
        //     }
        // }).catch((error) => {
        //     commit('error', '予期せぬエラーが発生しました。')
        // });

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