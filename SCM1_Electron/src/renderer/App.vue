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
  .main-layer {
      position: absolute;
      width: 1400px;
      height: 700px;
      margin: 15px 0 0 20px;
      z-index: 1;
      overflow: hidden;
  }
  .seat-layer {
    position: absolute;
    width: 1400px;
    height: 800px;
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
    width: 1429px;
    height: 833px;
    margin: 0 0 0 0;
    z-index: 4;
    display: flex;
    justify-content: center; /*左右中央揃え*/
    align-items: center;     /*上下中央揃え*/
  }
  .loading-layer{
    position: absolute;
    background: #ffffff;
    width: 1429px;
    height: 833px;
    margin: 0 0 0 0;
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
