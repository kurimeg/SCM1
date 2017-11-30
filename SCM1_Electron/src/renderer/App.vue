<template>
  <div id="app">
    <router-view></router-view>
    <div class="alert-layer" v-if="this.$store.state.alertHandler.show">
      <alert :alert="this.$store.state.alertHandler"></alert>
    </div>
    <div class="alert-layer" v-if="this.$store.state.errorHandler.show">
      <error :error="this.$store.state.errorHandler"></error>
    </div>
  </div>
</template>

<script>
import Alert from './components/Alert'
import Error from './components/Error'

export default {
  name: 'electron_vue',
  components: {
    Alert,Error
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
  }
  .alert-layer{
    position: absolute;
    width: 1400px;
    height: 700px;
    margin: 0 0 0 11px;
    z-index: 4;
  }
</style>
