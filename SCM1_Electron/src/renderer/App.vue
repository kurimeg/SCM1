<template>
  <div id="app">
    <router-view></router-view>
    <div class="loading-layer" v-if="this.$store.state.loading.show">
      <img src="./assets/images/loading.gif" class="loading"></img>
    </div>
    <modal></modal>
  </div>
</template>

<script>
import Modal from './components/Modal'

export default {
  name: 'electron_vue',
  components: {
    Modal
  }
}
</script>

<style>
  #app{
    position: relative;
    zoom: 70%;
  }
  .main {
      position: absolute;
      width: 1400px;
      height: 700px;
      margin: 0 0 0 11px;
      z-index: １;
  }
  .seat-layer {
    position: absolute;
    width: 1400px;
    height: 700px;
    z-index: 2;
  }
  .search-layer{
    position: absolute;
    z-index: 3;
    overflow: hidden;	
    width: 400px;
    border: 5px solid #28a1f7;
    border-radius: 15px;
    background-color: #5d5d5d;
    padding-bottom: 15px;
  }
  .alert-layer{
    position: absolute;
    width: 1400px;
    height: 700px;
    margin: 0 0 0 11px;
    z-index: 4;
  }
  .loading-layer{
    position: absolute;
    background: #ffffff;
    width: 1400px;
    height: 700px;
    margin: 0 0 0 11px;
    z-index: 999;
  }
  .loading{
    position: absolute;
    top: 0;
    bottom: 0;
    right: 0;
    left: 0;
    margin: auto;
  }

  body{
    margin: 0 0 0 0;
  }
</style>
