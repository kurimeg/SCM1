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
            store.commit('handler/success')
        }else{
            store.commit('handler/error', response.data.ResponseMessage)
        }
        return response.data
    }, (error) => {
        store.commit('handler/error', messages.E_001)
        return Promise.reject(error)
    })
  
    Vue.http = Vue.prototype.$http = client
}

