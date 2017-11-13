import router from '@/router'

const state = {
    isLogged: !!localStorage.getItem('token')
}

const mutations = {
    login (state) {
        state.isLogged = true
      }
}
  
const actions = {
    login ({ commit }, payload) {
        localStorage.setItem('token', 'sampletoken')
        commit('login')
        router.replace('chart')
        // axios.post('/', {
        //     empNo: payload.empNo,
        //     password: payload.password
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