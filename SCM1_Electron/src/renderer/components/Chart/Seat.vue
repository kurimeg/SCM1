<template>
    <button type="button" class="seat" v-on:click="onReserve">{{seatName}}</button>
</template>

<script>
    import { createNamespacedHelpers } from 'vuex'
    const { mapActions } = createNamespacedHelpers('reserve')

    export default {
    data: function () {
        return {
            
        }
    },
    props: ['seatName'],
    methods: {
        ...mapActions([
            'reserve'
        ]),
        // setName: function () {
        //     //TODO: ここでaction呼び出してセット、今べた書きだとレイアウト崩れる。。。
        //     if(!this.$data.seatName){
        //         alert("登録が完了しました")
        //         this.$data.seatName = "栗原"
        //     }
        //     else{
        //         alert("登録を解除しました")
        //         this.$data.seatName = ""
        //     }
        // },
        onReserve: function () {
            //座席未登録 & 該当座席の名前がない場合
            let authInfo = JSON.parse(localStorage.getItem('authInfo'))
            if(!this.seatName && !this.$store.state.reserve.isReserved){
                if(confirm("座席を登録しますか？")){
                    if(this.reserve({
                        Token : this.$store.state.auth.token,
                        EmpNo: authInfo.EmpNo,
                        seatNo: "E84-1"
                    })){
                        this.$data.seatName = "栗原"
                    }else{
                        alert(this.$store.state.reserve.errorMessage)
                    }
                }
            //座席未登録 & 該当座席の名前が自分以外の場合
            }else if(this.seatName != "栗原" && !this.$store.state.reserve.isReserved){
                alert("選択された座席は既に利用されています。")
            //座席登録済 & 該当座席の名前が自分の場合
            }else if(this.seatName == "栗原" && this.$store.state.reserve.isReserved){
                if(confirm("座席を解除しますか？")){
                    if(this.reserve({
                        Token : this.$store.state.auth.token,
                        EmpNo: authInfo.EmpNo
                    })){
                        this.$data.seatName = ""
                    }else{
                        alert(this.$store.state.reserve.errorMessage)
                    }
                }
            //座席登録済 & 該当座席の名前が自分以外の場合
            }else if(this.seatName != "栗原" && this.$store.state.reserve.isReserved){
                alert("あなたの座席は既に登録されています。")
            }
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
.seat {
    width: 24px;
    height: 60px;
    text-align: center;
    vertical-align: middle;
    text-decoration: none;
    padding: 3px 0;
    background-color: #FFFFFF;
    border: 2px solid #B8C8D6;
    border-radius: 10px;
    cursor: pointer;
    font-size: 16px;
    font-family: 'Century Gothic';
	z-index: 1;
    position: absolute;
	float: left;
    line-height: 1.1;
}
.seatY{
    position: absolute;
	width: 60px;
    height: 24px;
    padding: 0 0;
}
</style>
