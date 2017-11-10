import Vue from 'vue'
import Router from 'vue-router'
import Auth from '@/store/modules/auth'

Vue.use(Router)

var router = new Router({
  mode: 'history',
  routes: [   
    {
      path: '/',
      name: 'login',
      component: require('@/components/Login').default
    },
    {
      path: '/',
      name: 'chart',
      component: require('@/components/Chart'),
      meta: {
        requiresAuth: true
      }
    }
  ]
})

// router.beforeEach((to, from, next) => {
//   if (to.matched.some(record => record.meta.requiresAuth) && !Auth.state.loggedIn) {
//     next({
//       path: '/login'
//     })
//   } else {
//     next()
//   }
// })

export default router