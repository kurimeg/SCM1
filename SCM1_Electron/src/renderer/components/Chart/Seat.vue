<template>
    <button type="button" class="seat" @click="onReserve">{{ displayEmpNm }}</button>
</template>

<script>
import { mapActions, mapMutations, mapState } from 'vuex'
import * as messages from '@/assets/messages'

    export default {
    data: function () {
        return {
            displayEmpNm: this.seatName,
            empNo: JSON.parse(localStorage.getItem('authInfo')).EmpNo
        }
    },
    computed: {
        ...mapState('auth', {
			token: state => state.token
        }),
        ...mapState('getMaster', {
			empLoyeeName (state) {
                return state.empInfo.find(emp => emp.EMP_NO === this.empNo).DISPLAY_EMP_NM
            }
        }),
        ...mapState('reserve', {
			isReserved: state => state.isReserved
        })
    },
    props: ['seatName'],
    methods: {
        ...mapActions({
            reserve: 'reserve/reserve',
            showError: 'modal/showError',
            showAlert: 'modal/showAlert'
        }),
        onReserve: function (event) {
            //座席未登録 & 該当座席の名前がない場合
            if(!this.displayEmpNm && !this.isReserved){                
                this.showAlert({
                    message: messages.I_003, 
                    actionName: 'reserve/reserve', 
                    param: {
                        Token : this.token,
                        EmpNo: this.empNo,
                        seatNo: event.target.id
                    }
                })
            //座席未登録 & 該当座席の名前が自分以外の場合
            }else if(this.displayEmpNm != this.empLoyeeName && !this.isReserved){
                this.showError(messages.E_002)
            //座席登録済 & 該当座席の名前が自分の場合
            }else if(this.displayEmpNm == this.empLoyeeName && this.isReserved){
                this.showAlert({ 
                    message: messages.I_004, 
                    actionName: 'reserve/reserve', 
                    param: {
                        Token : this.token,
                        EmpNo: this.empNo,
                    }
                })
            //座席登録済 & 該当座席の名前が自分以外の場合
            }else if(this.displayEmpNm != this.empLoyeeName && this.isReserved){
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
.searched{
    animation: changecolor 30s 1 forwards;
    -webkit-animation: changecolor 30s 1 forwards;
}
@keyframes changecolor {
    1% { background-color: #ff7777; }
    2% { background-color: #ffffff; }
    3% { background-color: #ff7777; }
    4% { background-color: #ffffff; }
    6% { background-color: #ff7777; }
    90% { background-color: #ff7777; }
    100% { background-color: #ffffff; }
}
</style>
