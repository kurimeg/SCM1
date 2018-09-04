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
    components: {
      Loading, Modal
    }
  }
</script>

<style>
  body {
    margin: 0 0 0 0;
    font-family: 'Century Gothic';
  }
  .main-layer {
    position: absolute;
    width: 986px;
    height: 549.5px;
    margin: 10px 14px 0 14px;
    z-index: 1;
    overflow: hidden;
  }
  .desk-layer {
	  position: absolute;
    width: 1400px;
    height: 685px;
    margin: 50px 0 0 0;
    z-index: 2;
  }
  .seat-layer {
    position: absolute;
    width: 1400px;
    height: 685px;
    margin: 50px 0 0 0;
    z-index: 3;
  }
  .search-layer{
    position: absolute;
    overflow: hidden;	
    width: 400px;
    border: 5px solid #28a1f7;
    border-radius: 15px;
    background-color: #5d5d5d;
    padding-bottom: 15px;
    z-index: 4;
  }
  .alert-layer{
    position: absolute;
    width: 1000px;
    height: 560px;
    margin: 0 0 0 0;
    display: flex;
    justify-content: center; /*左右中央揃え*/
    align-items: center;     /*上下中央揃え*/
    z-index: 5;
  }
  .loading-layer{
    position: absolute;
    background: #ffffff;
    width: 1000px;
    height: 560px;
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
