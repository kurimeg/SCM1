<template>
    <div class="backimageToka">
        <div class="form">
            <div class="login-char">社員番号</div>
            <input type="text" v-model="empNo" class="txtbox"></input>
            <div class="login-char">パスワード</div>
            <input type="password" v-model="password" class="txtbox"></input>
            <button type="button" @click="onLogin" class="login">ログイン</button>
        </div>
    </div>
</template>

<script>
import { createNamespacedHelpers } from 'vuex'

const { mapState, mapActions } = createNamespacedHelpers('auth')

 export default {
   data: function () {
     return {
       empNo: null,
       password: null
     }
   },
   beforeCreate () {
        if (this.$store.state.isLogged) {
            this.$router.replace('chart')
        }
    },
    methods: {
        ...mapActions([
            'login'
        ]),

        onLogin: function () {
            this.login({
                empNo: this.empNo,
                password: this.password
            })
        }
    }
}
</script>

<style>
    body {
        /* background-image: url("../assets/images/back.jpg"); */
        background-size: 100% auto;
        background-repeat: no-repeat;
        margin: 0;
        font-family: 'ＭＳ Ｐ明朝', 'MS PMincho','ヒラギノ明朝 Pro W3', 'Hiragino Mincho Pro', 'serif'sans-serif;
    }
    .floatL {
        float: left;
    }
    .backimageToka{
        height: 100vh;
        background: rgba(255, 255, 255, 0.5);
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
        margin-left: 100px
    }
</style>