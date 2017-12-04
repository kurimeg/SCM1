import router from '@/router'
// TODO: main.jsでimport済。各moduleでそれを使うには？
import Vue from 'vue'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

// TODO: localStateとしたい。
const state = {
    show: false,
    searchMessage: ''   
}

const getters = {
    searchEmp: (state, getters, rootState) => (seachText) => {
        if(!seachText) return []

        //TODO: NULL対応
        let filteredEmp = rootState.getMaster.empInfo.filter(emp => emp.EMP_NM.replace(/\s+/g, "").startsWith(seachText))        
        // let filteredEmp = state.empInfo.filter(emp => emp.EMP_NM.replace(/\s+/g, "").startsWith(seachText) || emp.EMP_KANA_NM.replace(/\s+/g, "").startsWith(seachText))
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
    showSearch (state) {
        state.show = true
    },
    hideSearch (state) {
        state.show = false
    },
    setSearchMessage (state, searchMessage) {
        state.searchMessage = searchMessage
    }

}

export default {
    namespaced: true,
    state,
    mutations,
    getters
}