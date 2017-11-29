<template>
  <div id="app">
    <router-view></router-view>
    <div class="alert-layer" v-if="this.$store.state.handler.hasError">
      <alert :error="this.$store.state.handler"></alert>
    </div>
  </div>
</template>

<script>
import Alert from './components/Alert'

export default {
  name: 'electron_vue',
  components: {
    Alert
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
  .alert-layer{
    position: absolute;
    width: 1400px;
    height: 700px;
    z-index: 3;
  }
</style>
