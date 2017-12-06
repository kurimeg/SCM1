<template>
  <transition name="fade">
    <div class="alert-layer" v-if="show">
        <component :is="modalName" :message="message"></component>
    </div>
  </transition>
</template>

<script>
import { createNamespacedHelpers } from 'vuex'
import Alert from './Modal/Alert'
import Error from './Modal/Error'
import regAlert from './Modal/regAlert'
const { mapState, mapMutations } = createNamespacedHelpers('modal')

export default {
    computed: {
        ...mapState([
            'modalName', 'message'
        ]),
        show () {
            return this.modalName !== ''
        }
    },
    components: {
        Alert,Error,regAlert
    }
}
</script>