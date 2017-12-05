<template>
	<div class="main-layer">
		<img src="../assets/images/search_icon.png" class="icon" @click="showSearch"></img>	
		<search v-if="show"></search>
		<div class="tables">
			<div class="row01 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare"></div>
				</div>
				<div class="floatL">
					<div class="desk_rec01">
						<div class="naisen_l">
							<div class="naisen naisen_oneigyo"></div>
							<div class="naisen naisen_oneigyo"></div>
							<div class="naisen naisen_oneigyo"></div>
							<div class="naisen naisen_oneigyo"></div>
							<div class="naisen naisen_oneigyo"></div>
							<div class="naisen naisen_oneigyo"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="rack01 floatL"></div>
			<div class="row02 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare">2022</div>
				</div>
				<div class="desk_rec02">
						<div class="naisen naisen_l2">2002</div>
				</div>
				<div class="rack02 floatL"></div>
			</div>
			<div class="row02 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare">2015</div>
				</div>
				<div class="desk_rec02">
					<div class="naisen_l">
						<div class="naisen naisen_l3">2003</div>
						<div class="naisen naisen_l3">2004</div>
						<div class="naisen naisen_l3 naisen_hashi">2011</div>
						<div class="naisen naisen_l3 naisen_taka">2031</div>
					</div>
				</div>
				<div class="rack02 floatL"></div>
			</div>
			<div class="row02 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare">2014</div>
				</div>
				<div class="desk_rec02">
					<div class="naisen_l">
						<div class="naisen naisen_l4">2005</div>
						<div class="naisen naisen_l4">2023</div>
					</div>
				</div>
				<div class="rack02 floatL"></div>
			</div>
			<div class="row02 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare">2013</div>
				</div>
				<div class="desk_rec0506">
					<div class="naisen_l">
						<div class="naisen naisen_l56">2024</div>
					</div>
				</div>
				<div class="rack02 floatL"></div>
			</div>
			<div class="row01 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare">2012</div>
				</div>
					<div class="desk_rec0506">
						<div class="naisen_l">
							<div class="naisen naisen_l56">2025</div>
							<div class="naisen naisen_l56">2041</div>
						</div>
					</div>
				<div class="rack02 floatL"></div>
			</div>
			<div class="row07 floatL child">
				<div class="desk_rec07">
					<div class="naisen_l">
							<div class="naisen naisen_l7">2122</div>
					</div>
				</div>
				<div class="rack02 floatL">
				</div>
			</div>
			<!--正方形机1列目-->
			<div class="desk_recleft floatL child">
				<div class="desk_square02"></div>
				<div class="desk_square02">
					<div class="naisen naisen_onfree">2060</div>
				</div>
				<div class="desk_square02"></div>
				<div class="desk_square02">
					<div class="naisen naisen_onfree">2063</div>
				</div>
			</div>
			<!--正方形机2列目-->
			<div class="desk_recleft floatL child">
				<div class="desk_square02"></div>
				<div class="desk_square02"></div>
				<div class="desk_square02"></div>
				<div class="desk_square02"></div>
			</div>
			<!--正方形机3列目-->
			<div class="desk_recright floatL child">
				<div class="desk_square02">
					<div class="naisen naisen_onfree">2061</div>
				</div>
				<div class="desk_square02"></div>
				<div class="desk_square02">
					<div class="naisen naisen_onfree">2064</div>
				</div>
			</div>
			<!--正方形机4列目-->
			<div class="desk_recright floatL child">
				<div class="desk_square02"></div>
				<div class="desk_square02"></div>
				<div class="desk_square02"></div>
			</div>
			<!--正方形机5列目-->
			<div class="desk_recright floatL child">
				<div class="desk_square02">
					<div class="naisen naisen_onfree">2062</div>
				</div>
				<div class="desk_square02"></div>
				<div class="desk_square02">
					<div class="naisen naisen_onfree">2065</div>
				</div>
			</div>
			<div class="seat-layer" >
				<seat :id="seat.SEAT_NO" :class="{ 'seatY': !seat.VERTICAL_FLG , 'searched': userPath.length != 0 && seat.EMP_NO === userPath[0].EMP_NO }" :seat-name="seat.DISPLAY_EMP_NM" v-for="seat in seats" :key="seat.SEAT_NO" :style="{left: seat.CONTENT_POSITION_X + 'px' ,top: seat.CONTENT_POSITION_Y + 'px'}"></seat>
			</div>

		</div>
		<div id="minimap"></div>
	</div>
</template>

<script>
import Seat from './Chart/Seat'
import Search from './Chart/Search'
import { mapActions, mapMutations, mapState } from 'vuex'

export default {
	data: function () {
		return {

		}
	},
	computed:{
		...mapState('search', {
			show: state => state.show
		}),
		...mapState('getMaster', {
			seats: state => state.seatInfo
		}),
        ...mapState('getUserPath', {
			userPath: state => state.userPath
        })
	},
	methods:{
		...mapActions({
			firstview: 'getMaster/firstview',
			fetchEmpInfo: 'getMaster/fetchEmpInfo',
			getIsReserved: 'reserve/getIsReserved'
		}),

		...mapMutations({
				showSearch: 'search/showSearch'
			}),
			changeEmpName: function (seatNo, empName) {
			document.getElementById(seatNo).innerHTML = empName
		}
	},
	created: function(){
		this.firstview({
			Token: this.$store.state.auth.token
		})
		this.fetchEmpInfo({
			Token: this.$store.state.auth.token,
			EmpNo: ""
		})
		this.getIsReserved({
			EmpNo: JSON.parse(localStorage.getItem('authInfo')).EmpNo,
			Token: this.$store.state.auth.token
		})
	},
	components: {
		Seat, Search
	}
}
</script>

<style scoped>
body {
    margin: 0;
    font-family: 'ＭＳ Ｐ明朝', 'MS PMincho','ヒラギノ明朝 Pro W3', 'Hiragino Mincho Pro', 'serif'sans-serif;
}
.main-layer{
	height: 800px;
	margin: 15px 0 0 20px;
}
.tables{
	position: relative;
    width: 1400px;
    height: 700px;
    margin: 50px 0 0 0;
}
.floatL {
	float: left;
}
.icon{
	margin-left: 3px; 
	margin-top: 3px;
	width: 55px;
	height: 55px;
	float: left;
	z-index: 999;
	position: absolute;
	cursor: pointer;
}

/*ラック*/
.rack01 {
    margin: 130px 10px 0 5px;
    width: 15px;
    height: 515px;
    background-color: #E1BE7E;
}
.rack02 {
    width: 65px;
    height: 20px;
    margin: 5px 19px 0;
    background-color: #E1BE7E;
}

/*列＿1行目*/
.row01 {
    margin: 50px 8px 0 0;
}
.desk_square {
    margin: 0 30px 0 30px;
    width: 45px;
    height: 50px;
	background-color: #91cdf7;
}
.desk_rec01 {
    margin: 30px 30px 0 30px;
    width: 45px;
    height: 450px;
    background-color: #91cdf7;
}
/*列＿２行目以降*/
.row02 {
    margin: 50px 0 0;
}
.desk_rec02 {
    margin: 30px 30px 0;
    width: 45px;
    height: 515px;
	background-color: #91cdf7;
}

/*列＿5,6行目*/
.desk_rec0506 {
	margin: 95px 30px 0;
	width: 45px;
	height: 450px;
	background-color: #91cdf7;
}

/*列＿7行目*/
.desk_rec07 {
	margin: 130px 30px 0 30px;
	width: 45px;
	height: 515px;
	background-color: #91cdf7;
}
/*列＿8.9行目*/
.desk_recleft {
	margin: 130px 0 0 ;
}
/*列＿10.11.12行目*/
.desk_recright {
	margin: 260px 0 0 ;
}

/*フリースペース_正方形*/
.desk_square02 {
    position: relative;
    left: 25px;
	margin: 0 28px 70px;
	width: 60px;
	height: 60px;
	background-color: #91cdf7;
}

/* 内線関係 */
.naisen{
    width: 45px;
    height: 20px;
    background-color: #f7ffa3;
    color: #495f92;
    font-family: 'Century Gothic';
    font-size: 16px;
    font-weight: bold;
    text-align: center;
    border: 2px solid #495f92;
    border-radius: 5px;
}
.naisen_onsquare{
    position: absolute;
    margin-left: -2px;
    margin-top: 13px;
}
.naisen_l{
    position: absolute;
}
.naisen_oneigyo{
    margin-left: -2px;
    margin-top: 43px;
    margin-bottom: 20px;
}
.naisen_l2{
    position: absolute;
    margin-left: -2px;
    margin-top: 35px;
}
.naisen_l3{
    margin-left: -2px;
    margin-top: 35px;
    margin-bottom: 205px;
}
.naisen_l4{
    margin-left: -2px;
    margin-top: 35px;
    margin-bottom: 205px;
}
.naisen_l56{
    margin-left: -2px;
    margin-top: 35px;
    margin-bottom: 205px;
}
.naisen_l7{
    margin-left: -2px;
    margin-top: 458px;
}
.naisen_onfree{
    position: absolute;
    margin-left: 6px;
    margin-top: 19px;
}
.naisen_hashi{
	margin-left: -2px;
	margin-top: -35px;
	margin-bottom: 0px;
}
.naisen_taka{
	margin-left: -2px;
	margin-bottom: 0px;
	margin-top: 5px;
}
</style>
