<template>
	<div class="form">
		<button type="button" class="back" @click="hideModal">✖</button>
		<div class="message">{{ message }}</div>
		<button type="button" class="btn" @click="confirmed">ＯＫ</button>
		<button type="button" class="btn" @click="hideModal">キャンセル</button>
    </div>
</template>

<script>
import { createNamespacedHelpers } from 'vuex'
const { mapMutations, mapState } = createNamespacedHelpers('modal')

export default {
  props: ['message'],
  computed: {
    ...mapState([
      'actionName', 'param'
    ])
  },
  methods: {
    ...mapMutations([
      'hideModal'
    ]),
    confirmed: function () {
      this.$store.dispatch(this.actionName, this.param)
      this.hideModal()
    }
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
	width: 500px;
	z-index: 3;
	padding: 3px;
	text-align: center;
}
.message{
	margin-top: -10px;
	color: #939393;
	font-size: 18px;
	font-family: 'Century Gothic';
	display: block;
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
	margin: 10px 20px;
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
