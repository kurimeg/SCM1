<template>
	<div class="main-layer">
		<img 
			class="icon" 
			src="../assets/images/search_icon.png" 			
			@click="showSearch"
		>	
		<search v-if="show"></search>
		<img 
			class="rel" 
			src="../assets/images/reload.png" 			
			@click="reload"
		>
		<button 
			class="logout" 
			v-if="!isGuest"
			@click="logout" 			
		>Log out</button>
		<div class="tabs">
			<tab
        v-for="floorPlace in floorPlaces" 
        :key="floorPlace.FLOOR_PLACE_DV"
        :floorPlace="floorPlace"
      ></tab>				
		</div>
		<div class="desk-layer">
			<desk></desk>
		</div>
		<div class="seat-layer" >
				<seat 
					v-for="seat in this.seats" 
					:id="seat.SEAT_NO" 
					:key="seat.SEAT_NO" 
					:class="{ 'seatY': !seat.VERTICAL_FLG , 'searched': userPath.length != 0 && seat.SEAT_NO === userPath[0].SEAT_NO }" 			
					:style="{ left: seat.CONTENT_POSITION_X + 'px', top: seat.CONTENT_POSITION_Y + 'px' }"
					:seat="seat" 	
				></seat>
		</div>
	</div>
</template>

<script>
import Seat from './Chart/Seat'
import Search from './Chart/Search'
import Desk from './Chart/Desk'
import Tab from './Chart/Tab'
import * as messages from '@/assets/messages'
import { mapActions, mapMutations, mapState, mapGetters } from 'vuex'

export default {
  components: {
    Seat, Desk, Search, Tab
  },
  data: function () {
    return {
      empNo: JSON.parse(localStorage.getItem('authInfo')).EmpNo
    }
  },
  computed: {
    ...mapState('auth', {
      token: state => state.token,
      isGuest: state => state.isGuest
    }),
    ...mapState('search', {
      show: state => state.show
    }),
    ...mapState('getMaster', {
      floorPlaces: state => state.floorPlaces
    }),
    ...mapState('getUserPath', {
      userPath: state => state.userPath
    }),
    ...mapGetters({
      seats: 'tab/filterSeat'
    })
  },
  created: function () {
    this.showLoading(true)
    this.firstview({
      Token: this.token
    })
    this.fetchAllFloorPlace({
      Token: this.token
    })
    this.fetchEmpInfo({
      token: {
        Token: this.token,
        EmpNo: ''
      },
      loginEmpNO: this.empNo
    })
    this.getIsReserved({
      EmpNo: this.empNo,
      Token: this.token
    })
    // 5分でポーリングして初期表示処理を呼び出す
    setInterval(() => {
      this.firstview({
        Token: this.token
      })
    }, 300000)
  },
  updated: function () {
    this.showLoading(false)
  },
  methods: {
    ...mapActions({
      firstview: 'getMaster/firstview',
      fetchAllFloorPlace: 'getMaster/fetchAllFloorPlace',
      fetchEmpInfo: 'getMaster/fetchEmpInfo',
      getIsReserved: 'reserve/getIsReserved',
      showAlert: 'modal/showAlert'
    }),
    ...mapMutations({
      showSearch: 'search/showSearch',
      showLoading: 'loading/showLoading'
    }),
    logout: function () {
      this.showAlert({
        message: messages.I_005,
        actionName: 'auth/logout',
        param: {}
      })
    },
    reload: function () {
      this.showLoading(true)
      this.firstview({
        Token: this.token
      })
    }
  }
}
</script>

<style scoped>
button:focus{
 outline:none;
}
.icon{
	margin-left: 9px; 
	margin-top: 8px;
	width: 50px;
	height: 50px;
	float: left;
	z-index: 2;
	position: absolute;
	cursor: pointer;
}
.icon:active{
	width: 49px;
    height: 49px;
	margin-top: 7.9px;
	filter:brightness(98%);
}
.rel{
	margin-left: 65px; 
	margin-top: 8px;
	width: 50px;
	height: 50px;
	float: left;
	z-index: 2;
	position: absolute;
	cursor: pointer;
}
.rel:active{
	width: 49px;
	height: 49px;
	margin-top: 7.9px;
	filter:brightness(98%);
}
.logout{
	margin-top: 5px;
	margin-bottom: 6px;
	margin-right: 8px;
	color: #cccccc;
	font-size: 18px;
	font-family: 'Century Gothic';
	display: block;
	float: right;
	border-style: dashed;
	background: none;
	cursor: pointer;
}
.tabs{
	position:absolute;
	display: flex;
  width: 1400px;
  justify-content:flex-end;
	bottom: 0;
	z-index: 3;
}
</style>
