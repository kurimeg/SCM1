<template>
	<transition name="fade-loading">
    <div class="loading-layer" v-if="show">
      <img src="../assets/images/loading.gif" class="loading"></img>
    </div>
	</transition>
</template>

<script>
import { createNamespacedHelpers } from 'vuex'
const { mapState } = createNamespacedHelpers('loading')

 export default {  
    computed: {
        ...mapState({
            show: state => state.show
		})
    }
}
</script>

<style scoped>
.loading{
	position: absolute;
	top: 0;
	bottom: 0;
	right: 0;
	left: 0;
	margin: auto;
}
</style>
