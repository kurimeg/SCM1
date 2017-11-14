import router from '@/router'
import axios from 'axios'

const state = {
    isLogged: !!localStorage.getItem('token')
}

const mutations = {
    login (state) {
        state.isLogged = true
      }
}

const actions = {
    login ({ commit }, authInfo) {
        // localStorage.setItem('token', 'sampletoken')
        // console.log(localStorage.getItem("token"))
        // commit('login')
        // router.replace('chart')
        axios.get('http://scm1test.azurewebsites.net/api/emp/', {
            params: {
                searchempno : 46012
            }
        })
        .then((response) =>{
            console.log(response)
        })


        // axios.post('', {
        //     empNo: authInfo.empNo,
        //     password: authInfo.password
        //   })
        //   .then((response) => {
        //     localStorage.setItem('token', 'sampletoken')
        //     commit('login')
        //     router.replace('chart')
        //   })
        //   .catch((error) => {
        //     console.log(error);
        //   });
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}