<template>
	<div class="form">
		<button type="button" class="back" @click="hideModal">✖</button>
		<div class="message">{{ message }}</div>
		<button type="button" class="btn" @click="hideModal">ＯＫ</button>
    </div>
</template>

<script>
import { createNamespacedHelpers } from 'vuex'
const { mapMutations } = createNamespacedHelpers('modal')

export default {
  props: ['message'],
  methods: {
    ...mapMutations([
      'hideModal'
    ])
  }
}
</script>

<style scoped>
button:focus{
 outline:none;
}
.form{
	position: absolute;
	border: 5px solid #28a1f7;
	border-radius: 15px;
	background-color: #d8d8d8;
	overflow: hidden;
	width: 560px;
	z-index: 3;
	padding: 3px;
}
.message{
	margin: 3px auto;
	color: #939393;
	font-size: 18px;
	font-family: 'Century Gothic';
	display: flex;
	justify-content: center;
	align-content: center;
}
.btn{
	background-color: #28a1f7;
	width: 150px;
	color: #ffffff;
	font-size: 18px;
	font-family: 'Century Gothic';
	border-radius: 15px;
	cursor: pointer;
	text-decoration: none;
	margin: 10px auto;
	display: block;
	border-style: none;
}
.back{
	width: 30px;
	height: 30px;
	margin: 3px 3px 0 auto;
	display: block;
	background: none;
	color: #939393;
	font-size: 20px;
	font-family: 'Century Gothic';
	border-style: none;
	cursor: pointer;
}
</style>
