<template>
	<button type="button" class="seat"　@click="setName">{{ name }}</button>
</template>

<script>
import { createNamespacedHelpers } from 'vuex'

//TODO: moduleのマップ
// const { mapActions } = createNamespacedHelpers('auth')

 export default {
   data: function () {
     return {
		name: null
     }
   },
    methods: {
        //TODO: moduleのマップ
        // ...mapActions([
        //     'login'
        // ]),

        setName: function () {
            //TODO: ここでaction呼び出してセット、今べた書きだとレイアウト崩れる。。。
            if(!this.$data.name){
                this.$data.name = "栗原"
            }
            else{
                this.$data.name = ""
            }
            
        }
	}
}
</script>

<style>
body {
	margin: 0;
	font-family: 'ＭＳ Ｐ明朝', 'MS PMincho','ヒラギノ明朝 Pro W3', 'Hiragino Mincho Pro', 'serif'sans-serif;
}
.seat {
    margin: 5px 2px;
    width: 22px;
    text-decoration: none;
    display: block;
    text-align: center;
    padding: 23px 0;
    background-color: #FFFFFF;
    border: 2px solid #B8C8D6;
    border-radius: 10px;
    cursor: pointer;
    font-size: 14px;
	z-index: 999;
}
</style>
