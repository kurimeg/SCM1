<template>
  <div id="app">
    <router-view></router-view>
    <loading></loading>
    <modal></modal>
  </div>
</template>

<script>
import Modal from './components/Modal'
import Loading from './components/Loading'

export default {
  name: 'SekiPa',
  components: {
    Loading, Modal
  }
}
</script>

<style>
  #app{
    position: relative;
    zoom: 70%;
  }
  body {
    margin: 0 0 0 0;
    font-family: 'ＭＳ Ｐ明朝', 'MS PMincho','ヒラギノ明朝 Pro W3', 'Hiragino Mincho Pro', 'serif'sans-serif;
  }
  .main-layer {
      position: absolute;
      width: 1429px;
      height: 804px;
      z-index: 1;
      overflow: hidden;
  }
  .seat-layer {
    position: absolute;
    width: 1429px;
    height: 804px;
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
    height: 804px;
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
    height: 804px;
    margin: 0 0 0 0;
    z-index: 999;
  }
  .fade-enter-active, .fade-leave-active {
    transition: opacity .3s
  }
  .fade-enter, .fade-leave-to{
    opacity: 0
  }
  .fade-loading-leave-active {
    transition: opacity .3s
  }
  .fade-loading-leave-to{
    opacity: 0
  }
</style>
