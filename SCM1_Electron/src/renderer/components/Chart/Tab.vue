<template>
  <div class="tab" 
      :id="floorPlace.FLOOR_PLACE_DV"
      @click="switchTab">
      {{ floorPlace.FLOOR_PLACE_DV_NM }}
    <span 
      :class="{ 'tab-active': floorPlace.FLOOR_PLACE_DV === floorPlaceDv }" 			
    ></span>				
  </div>	
</template>

<script>
  import { createNamespacedHelpers } from 'vuex'
  const { mapState, mapMutations } = createNamespacedHelpers('tab')

  export default {
    props: ['floorPlace'],
    computed: {
      ...mapState([
        'floorPlaceDv'
      ])
    },
    methods: {
      ...mapMutations([
        'setTab'
      ]),
      switchTab: function (event) {
        this.setTab(event.target.id)
        this.$store.commit('getUserPath/reset')
      }
    }
  }
</script>

<style scoped>
.tab{
	width: 240px;
	bottom: 0;
	font-size: 16px;
	font-family: 'Century Gothic';
	text-align: center;
  cursor: pointer;
}
.tab-active {
	display: inline-flex;
	bottom: 0;
	height: 3px;
	background: #28a1f7;
	width: 240px;
}
</style>