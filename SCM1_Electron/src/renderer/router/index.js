import Vue from 'vue'
import Router from 'vue-router'
import store from '@/store'
import Login from '@/components/Login'
import Chart from '@/components/Chart'

Vue.use(Router)

const router = new Router({
  routes: [   
    {
      path: '/',
      name: 'login',
      component: Login
    },
    {
      path: '/chart',
      name: 'chart',
      component: Chart
    }
  ]
})

router.beforeEach((to, from, next) => {
  // Loadingの削除はVueコンポーネントのライフサイクルフック(created,mounted,updatedなど)で実装すること！
  store.commit('loading/showLoading', true)
  next()
})

export default router