<template>
	<div class="form">
		<button type="button" class="back" @click="hideModal">✖</button>
		<div class="message">{{ message }}</div>
		<input type="checkbox" name="check" v-model="fixed" id="kotei">
		<label for="kotei" class="label">固定席として登録する</label><br>
		<button type="button" class="btn" @click="confirmed">ＯＫ</button>
		<button type="button" class="btn" @click="hideModal">キャンセル</button>
    </div>
</template>

<script>
import { createNamespacedHelpers } from 'vuex'
const { mapMutations, mapState } = createNamespacedHelpers('modal')

export default {
	data: function () {
		return {
			fixed: false
		}
	},
	props: ['message'],
	computed:{
		...mapState([
            'actionName', 'param'
		])
	},
    methods:{
        ...mapMutations([
            'hideModal', 'changeParam'
		]),
		
        confirmed: function () {
			let changedParam = {
                        Token : this.param.Token,
                        EmpNo: this.param.EmpNo,
                        seatNo: this.param.seatNo,
                        fixedFlg : this.fixed
			}
			this.changeParam(changedParam)
            this.$store.dispatch(this.actionName, this.param)
            this.hideModal()
        }
    }
}
</script>

<style scoped>
body {
	margin: 0;
	font-family: 'ＭＳ Ｐ明朝', 'MS PMincho','ヒラギノ明朝 Pro W3', 'Hiragino Mincho Pro', 'serif'sans-serif;
}
button:focus{
 outline:none;
}
input:focus{
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
	margin: 0 3px 0 auto;
	display: block;
	background: none;
	color: #939393;
	font-size: 20px;
	font-family: 'Century Gothic';
	border-style: none;
	cursor: pointer;
}
#kotei{
	margin-top: 10px;
	-moz-transform:		scale(1.4);
	-webkit-transform:	scale(1.4);
	transform:		scale(1.4);
}
.label{
	margin-top: 20px;
	color: #939393;
	font-size: 15px;
	font-family: 'Century Gothic';
}
</style>
