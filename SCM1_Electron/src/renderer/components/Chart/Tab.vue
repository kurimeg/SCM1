<template>
  <div class="tab">
    <a>{{ floorPlace.FLOOR_PLACE_DV_NM }}</a>
    <span class="tab-active"></span>				
  </div>	
</template>

<script>
  export default {
    props: ['floorPlace']
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