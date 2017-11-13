import Vue from 'vue'
import Router from 'vue-router'
import Auth from '@/store/modules/auth'
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
      component: Chart,
      meta: {
        requiresAuth: true
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth) && !Auth.state.isLogged) {
    next({
      path: '/login'
    })
  } else {
    next()
  }
})

export default router