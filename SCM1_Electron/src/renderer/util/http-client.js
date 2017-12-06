import axios from 'axios';
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const client = axios.create({
    baseURL: 'http://scm1test.azurewebsites.net/api'
  })

export default (Vue, { store }) => {
    
    client.interceptors.request.use((config) => {
        return config;
    }, (error) => {
        return Promise.reject(error)
    })
  
    client.interceptors.response.use((response) => {
        if(response.data.ProcessStatus === constants.STATUS_OK){
            store.commit('modal/hideModal')
        } else if(response.data.ProcessStatus === constants.STATUS_TOKEN_ER){
            store.dispatch('auth/logout')
            store.dispatch('modal/showError',response.data.ResponseMessage)
        }
        else{
            store.dispatch('modal/showError',response.data.ResponseMessage)
        }
        return response.data
    }, (error) => {
        store.dispatch('modal/showError',response.data.ResponseMessage)
        return Promise.reject(error)
    })
  
    Vue.http = Vue.prototype.$http = client
}

