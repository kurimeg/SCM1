<template>
	<div class="main-layer">
		<img src="../assets/images/search_icon.png" class="icon" @click="showSearch"></img>	
		<search v-if="show"></search>
		<div class="tables">
			<div class="row01 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare">2001</div>
				</div>
				<div class="floatL">
					<div class="desk_rec01">
						<div class="naisen_l">
							<div class="naisen naisen_oneigyo">2007</div>
							<div class="naisen naisen_oneigyo">2008</div>
							<div class="naisen naisen_oneigyo">2009</div>
							<div class="naisen naisen_oneigyo">2010</div>
							<div class="naisen naisen_oneigyo">2011</div>
							<div class="naisen naisen_oneigyo">2012</div>
						</div>
					</div>
				</div>
			</div>
			<div class="rack01 floatL"></div>
			<div class="row02 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare">2002</div>
				</div>
				<div class="desk_rec02">
						<div class="naisen naisen_l2">2013</div>
				</div>
				<div class="rack02 floatL"></div>
			</div>
			<div class="row02 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare">2003</div>
				</div>
				<div class="desk_rec02">
					<div class="naisen_l">
						<div class="naisen naisen_l3">2014</div>
						<div class="naisen naisen_l3">2015</div>
					</div>
				</div>
				<div class="rack02 floatL"></div>
			</div>
			<div class="row02 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare">2004</div>
				</div>
				<div class="desk_rec02">
					<div class="naisen_l">
						<div class="naisen naisen_l4">2016</div>
						<div class="naisen naisen_l4">2017</div>
					</div>
				</div>
				<div class="rack02 floatL"></div>
			</div>
			<div class="row02 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare">2005</div>
				</div>
				<div class="desk_rec05">
					<div class="naisen naisen_l2">2018</div>
				</div>
				<div class="rack02 floatL"></div>
			</div>
			<div class="row01 floatL child">
				<div class="desk_square">
					<div class="naisen naisen_onsquare">2006</div>
				</div>
					<div class="desk_rec06">
						<div class="naisen_l">
							<div class="naisen naisen_l4">2019</div>
							<div class="naisen naisen_l4">2020</div>
						</div>
					</div>
				<div class="rack02 floatL"></div>
			</div>
			<div class="row07 floatL child">
				<div class="desk_rec07"></div>
				<div class="rack02 floatL"></div>
			</div>
			<!--正方形机1列目-->
			<div class="desk_recleft floatL child">
				<div class="desk_square02"></div>
				<div class="desk_square02">
					<div class="naisen naisen_onfree">2023</div>
				</div>
				<div class="desk_square02"></div>
				<div class="desk_square02">
					<div class="naisen naisen_onfree">2024</div>
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
				<div class="desk_square02"></div>
				<div class="desk_square02">
					<div class="naisen naisen_onfree">2025</div>
				</div>
				<div class="desk_square02"></div>
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
					<div class="naisen naisen_onfree">2026</div>
				</div>
				<div class="desk_square02"></div>
				<div class="desk_square02">
					<div class="naisen naisen_onfree">2027</div>
				</div>
			</div>
			<div class="seat-layer" >
				<seat :id="seat.SEAT_NO" :class="{ 'seatY': !seat.VERTICAL_FLG }" :seat-name="seat.SEAT_NO" v-for="seat in seats" :key="seat.SEAT_NO" :style="{left: seat.CONTENT_POSITION_X + 'px' ,top: seat.CONTENT_POSITION_Y + 'px'}"></seat>
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
		})
   },
   methods:{
	   ...mapActions({
			firstview: 'getMaster/firstview',
			fetchEmpInfo: 'getMaster/fetchEmpInfo',
			fetchAllEmpLocationInfo: 'getMaster/fetchAllEmpLocationInfo',
			setSeatInfo: 'getMaster/setSeatInfo'
   		}),
		
		...mapMutations({
            showSearch: 'search/showSearch'
   		})
   },
   created: function(){
	this.firstview({Token: this.$store.state.auth.token})
	this.fetchEmpInfo({
		Token: this.$store.state.auth.token,
		EmpNo: ""
	})
	this.fetchAllEmpLocationInfo({
		Token: this.$store.state.auth.token,
		EmpNo: ""
	})
	
   },
   mounted: function(){
		this.setSeatInfo()
   },
   components: {
	   Seat, Search
   }
//    methods: {
// 	   //TODO: modulesへ追加、stateに各配列をcommitする
//         ...mapActions([
//             'getNaisenIDs', 'getSeatIDs'
//         ])
// 	},
// 	created: function () {
// 		//TODO: 以下のような感じでIDをセット。もっといい感じの方法があるはず。。。
// 		const naisen = document.getElementsByClassName("naisen")
// 		this.getNaisenIDs()
// 		for(let i = 0; i < naisen.length; i++){
// 			naisen[i].setAttribute("id", this.$store.state.naisenIDs[i])
// 		}

// 		const seat = document.getElementsByClassName("seat")
// 		this.getSeatIDs
// 		for(let i = 0; i < naisen.length; i++){
// 			seat[i].setAttribute("id", this.$store.state.seatIDs[i])
// 		}
//     }
}
</script>

<style scoped>
body {
    margin: 0;
    font-family: 'ＭＳ Ｐ明朝', 'MS PMincho','ヒラギノ明朝 Pro W3', 'Hiragino Mincho Pro', 'serif'sans-serif;
}
.tables{
	position: relative;
    width: 1400px;
    height: 600px;
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
    margin: 137px 10px 0 5px;
    width: 15px;
    height: 450px;
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

/*列＿5行目*/
.desk_rec05 {
	margin: 85px 30px 0;
	width: 45px;
	height: 460px;
	background-color: #91cdf7;
}
/*列＿6行目*/
.desk_rec06 {
	margin: 85px 30px 0;
	width: 45px;
	height: 460px;
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
    margin-top: 34px;
    margin-bottom: 30px;
}
.naisen_l2{
    position: absolute;
    margin-left: -2px;
    margin-top: 50px;
}
.naisen_l3{
    margin-left: -2px;
    margin-top: 50px;
    margin-bottom: 140px;
}
.naisen_l4{
    margin-left: -2px;
    margin-top: 50px;
    margin-bottom: 200px;
}
.naisen_onfree{
    position: absolute;
    margin-left: 6px;
    margin-top: 19px;
}
</style>
