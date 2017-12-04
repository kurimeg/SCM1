<template>
    <button type="button" class="seat" @click="onReserve(seat.SEAT_NO)">{{seatName}}</button>
</template>

<script>
import { mapActions, mapMutations, mapState } from 'vuex'
import * as messages from '@/assets/messages'

    export default {
    data: function () {
        return {
            empLoyeeName: null
        }
    },
    computed: {
        ...mapState('getMaster', {
			empInfo: state => state.empInfo
        }),
        ...mapState('reserve', {
			isReserved: state => state.isReserved
		})
    },
    props: ['seat','seatName'],
    methods: {
        ...mapActions({
            reserve: 'reserve/reserve',
            showError: 'modal/showError',
            showAlert: 'modal/showAlert'
        }),
        onReserve: function () {
            //ユーザ名抽出処理
            let authInfo = JSON.parse(localStorage.getItem('authInfo'))
            for(var i = 0; i < this.empInfo.length; i++){
                if(this.empInfo[i].EMP_NO == authInfo.EmpNo){
                    this.empLoyeeName = this.empInfo[i].DISPLAY_EMP_NM
                    break
                }
            }
            //座席未登録 & 該当座席の名前がない場合
            if(!this.seatName && !this.isReserved){
                this.showAlert( {message: messages.I_003, actionName: 'reserve/reserve',})
                if(confirm("座席を登録しますか？")){
                    this.reserve({
                        Token : this.$store.state.auth.token,
                        EmpNo: authInfo.EmpNo,
                        seatNo: seatNo
                    })
                    this.$emit('changeName',seatNo,this.empLoyeeName)
                }
            //座席未登録 & 該当座席の名前が自分以外の場合
            }else if(this.seatName != this.empLoyeeName && !this.isReserved){
                this.showError(messages.E_002)
            //座席登録済 & 該当座席の名前が自分の場合
            }else if(this.seatName == this.empLoyeeName && this.isReserved){
                this.showAlert(messages.I_004)
                if(confirm("座席を解除しますか？")){
                    this.reserve({
                        Token : this.$store.state.auth.token,
                        EmpNo: authInfo.EmpNo
                    })
                    this.$emit('changeName',seatNo,'')
                }
            //座席登録済 & 該当座席の名前が自分以外の場合
            }else if(this.seatName != this.empLoyeeName && this.isReserved){
                this.showError(messages.E_003)
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
