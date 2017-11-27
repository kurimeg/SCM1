<template>
	<button type="button" class="seat"　@click="onReserve">{{ name }}</button>
</template>

<script>
    import { createNamespacedHelpers } from 'vuex'
    const { mapActions } = createNamespacedHelpers('reserve')

    export default {
    data: function () {
        return {
            name: null,
            empNo: null,
            password: null
        }
    },
    methods: {
        ...mapActions([
            'reserve'
        ]),
        // setName: function () {
        //     //TODO: ここでaction呼び出してセット、今べた書きだとレイアウト崩れる。。。
        //     if(!this.$data.name){
        //         alert("登録が完了しました")
        //         this.$data.name = "栗原"
        //     }
        //     else{
        //         alert("登録を解除しました")
        //         this.$data.name = ""
        //     }
        // },
        onReserve: function () {
            if(!this.$data.name){
				this.reserve({
					EmpNo: '46012',
					Password: '46012'
				})
				alert("登録が完了しました")
				this.$data.name = "栗原"
			}else{
				alert("登録を解除しました")
				this.$data.name = ""
			}
        },
        created: function () {
            let authInfo = JSON.parse(localStorage.getItem('authInfo'))
            this.reserve({
                EmpNo: authInfo.EmpNo,
                Password: authInfo.Password
            })
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
