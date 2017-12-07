<template>
	<div class="main-layer">
		<div class="form">
			<div class="login-char">社員番号</div>
			<input type="text" v-model="empNo" class="txtbox"></input>
			<div class="login-char">パスワード</div>
			<input type="password" v-model="password" class="txtbox"></input>
			<button type="button"  @keyup.enter="onLogin" @click="onLogin" class="login">ログイン</button>
		</div>
	</div>
</template>

<script>
import * as constants from '@/assets/constants'
import { mapActions, mapMutations, mapState } from 'vuex'


 export default {
   data: function () {
     return {
		empNo: null,
		password: null
     }
   },
    methods: {
        ...mapActions({
			login: 'auth/login', 
			guestLogin: 'auth/guestLogin'
		}),
		...mapMutations({
			showLoading: 'loading/showLoading'
		}),
        onLogin: function () {
            this.login({
						EmpNo: this.empNo,
						Password: this.password
            })
        }
	},
	created: function () {
		this.showLoading(true)
		// WEB用
		// this.guestLogin({
		// 		authInfo: {
		// 			EmpNo: constants.GUEST_USER_EMP_NO,
		// 			Password: constants.GUEST_USER_PASSWORD
		// 		},
		// 		token: constants.GUEST_USER_TOKEN
		// })
		if(process.env.IS_WEB){
			this.guestLogin({
				authInfo: {
					EmpNo: constants.GUEST_USER_EMP_NO,
					Password: constants.GUEST_USER_PASSWORD
				},
				token: constants.GUEST_USER_TOKEN
			})
		}
        else if (this.$store.state.auth.isLogged) {
			let authInfo = JSON.parse(localStorage.getItem('authInfo'))
            this.login({
						EmpNo: authInfo.EmpNo,
						Password: authInfo.Password
            })
        }
	},
	mounted: function(){
		this.showLoading(false)
	}
}
</script>

<style scoped>
body {
	margin: 0;
	font-family: 'ＭＳ Ｐ明朝', 'MS PMincho','ヒラギノ明朝 Pro W3', 'Hiragino Mincho Pro', 'serif'sans-serif;
}
input:focus{
 outline:none;
}
button:focus{
 outline:none;
}
.main-layer{
	background-image: url("../assets/images/back.jpg");
	background-repeat: no-repeat;
	background-size: 100%;
	width: 1429px;
	height: 804px;
    margin: 0 0 0 0;
	z-index: 3;
}
.form{
	position: absolute;
	top: 0;
	right: 0;
	bottom: 0;
	left: 0;
	margin: auto;
	height: 300px;
	width: 400px;
	border: 5px solid #28a1f7;
	border-radius: 15px;
	background-color: #d8d8d8;
}
.login-char{
	margin-left: 25px; 
	margin-top: 20px;
	color: #28a1f7;
	font-size: 20px;
	font-family: 'Century Gothic';
	display: block;
}
.txtbox{
	margin-left: 30px;
	margin-top: 10px;
	text-indent: 1em;
	font-family: 'Century Gothic';
	font-size: 20px;
	background-color: #ffffff;
	color: #909090;
	width: 330px;
	height: 30px;
	border: 2px solid #28a1f7;
	border-radius: 20px;
}
.login{
	background-color: #28a1f7;
	width: 200px;
	color: #ffffff;
	font-size: 20px;
	font-family: 'Century Gothic';
	border-radius: 15px;
	cursor: pointer;
	text-decoration: none;
	margin-top: 45px;
	margin-left: 100px;
	border-style: none;
}
</style>
