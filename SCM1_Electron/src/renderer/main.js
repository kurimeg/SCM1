import Vue from 'vue'
import axios from 'axios'

import App from './App'
import router from './router'
import store from './store'

import httpClient from './util/http-client'

if (!process.env.IS_WEB) Vue.use(require('vue-electron'))
Vue.use(httpClient, { store })
Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  components: { App },
  router,
  store,
  template: '<App/>'
}).$mount('#app')
