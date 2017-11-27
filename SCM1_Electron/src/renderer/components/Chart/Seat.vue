<template>
	<button type="button" class="seat" v-on:click="onReserve">{{ name }}</button>
</template>

<script>
    import { createNamespacedHelpers } from 'vuex'
    const { mapActions } = createNamespacedHelpers('reserve')

    export default {
    data: function () {
        return {
            name: null,
            Token : null,
            EmpNo: null,
            seatNo: null,
            Password: null
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
            //座席未登録 & 該当座席の名前がない場合
            if(!this.$data.name && !this.$store.state.reserve.isReserved){
                if(confirm("座席を登録しますか？")){
                    this.reserve({
                        Token : this.$store.state.auth.token,
                        EmpNo: "46012",
                        seatNo: "E84-1"
                    })
                    if(!this.$store.state.reserve.hasError){
                        this.$data.name = "栗原"
                    }else{
                        alert(this.$store.state.reserve.errorMessage)
                    }
                }
            //座席未登録 & 該当座席の名前が自分以外の場合
            }else if(this.$data.name != "栗原" && !this.$store.state.reserve.isReserved){
                alert("選択された座席は既に利用されています。")
            //座席登録済 & 該当座席の名前が自分の場合
            }else if(this.$data.name == "栗原" && this.$store.state.reserve.isReserved){
                if(confirm("座席を解除しますか？")){
                    this.reserve({
                        Token : this.$store.state.auth.token,
                        EmpNo: "46012",
                        seatNo: "E84-1"
                    })
                    if(!this.$store.state.reserve.hasError){
                        this.$data.name = ""
                    }else{
                        alert(this.$store.state.reserve.errorMessage)
                    }
                }
            //座席登録済 & 該当座席の名前が自分以外の場合
            }else if(this.$data.name != "栗原" && this.$store.state.reserve.isReserved){
                alert("あなたの座席は既に登録されています。")
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
