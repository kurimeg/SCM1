import router from '@/router'
// TODO: main.jsでimport済。各moduleでそれを使うには？
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

// TODO: localStateとしたい。
const state = {
    show: false,
    empInfo: [],
    searchMessage: ''   
}

const getters = {
    searchEmp: (state, getters) => (seachText) => {
        if(!seachText) return []

        let filteredEmp = state.empInfo.filter(emp => emp.EMP_NM.replace(/\s+/g, "").startsWith(seachText) || emp.EMP_KANA_NM.replace(/\s+/g, "").startsWith(seachText))
        let searchMessage = ''
        if(filteredEmp.length > 0){
            searchMessage = messages.I_001
        }else{
            searchMessage = messages.I_002
        }
               
        return { filteredEmp: filteredEmp, searchMessage: searchMessage }
    }
}

const mutations = {
    show (state, bool) {
        state.show = bool
    },
    fetchEmpInfo (state , empInfo) {
        state.empInfo = empInfo
    },
    setSearchMessage (state, searchMessage) {
        state.searchMessage = searchMessage
    }

}

const actions = {
    fetchEmpInfo({ commit }, token) {
        Vue.http.post('/emp/FetchEmpInfo', token)
        .then((data) =>{          
            if(data.ProcessStatus === constants.STATUS_OK)
            {
                commit('fetchEmpInfo', data.EmpInfo)
            } 
        })
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions,
    getters
}