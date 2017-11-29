<template>
	<div class="main">
		<img src="../assets/images/search_icon.png" class="icon"></img>
		<search v-if="false"></search>
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
				<seat class="seat" :class="{ 'seatY':seat.class }" :seat-name="seat.name" v-for="seat in seats" :key="seat.name" :style="{left: seat.positionX + 'px' ,top: seat.positionY + 'px'}"></seat>
			</div>
		</div>
		<div id="minimap"></div>
	</div>
</template>

<script>
import Seat from './Chart/Seat'
import Search from './Chart/Search'

export default {
   data: function () {
     return {
		seats: [
			/*一列目左*/
			{name: "栗原萌" , positionX:2 ,positionY:45 ,class:false},
			{name: "佐貫" , positionX:2 ,positionY:130 ,class:false},
			{name: "" , positionX:2 ,positionY:195 ,class:false},
			{name: "" , positionX:2 ,positionY:260 ,class:false},
			{name: "" , positionX:2 ,positionY:325 ,class:false},
			{name: "" , positionX:2 ,positionY:390 ,class:false},
			{name: "" , positionX:2 ,positionY:455 ,class:false},
			/*一列目右*/
			{name: "" , positionX:79 ,positionY:45 ,class:false},
			{name: "" , positionX:79 ,positionY:130 ,class:false},
			{name: "" , positionX:79 ,positionY:195 ,class:false},
			{name: "" , positionX:79 ,positionY:260 ,class:false},
			{name: "" , positionX:79 ,positionY:325 ,class:false},
			{name: "" , positionX:79 ,positionY:390 ,class:false},
			{name: "" , positionX:79 ,positionY:455 ,class:false},
			/*二列目左*/
			{name: "" , positionX:145 ,positionY:45 ,class:false},
			{name: "" , positionX:145 ,positionY:130 ,class:false},
			{name: "" , positionX:145 ,positionY:195 ,class:false},
			{name: "" , positionX:145 ,positionY:260 ,class:false},
			{name: "" , positionX:145 ,positionY:325 ,class:false},
			{name: "" , positionX:145 ,positionY:390 ,class:false},
			{name: "" , positionX:145 ,positionY:455 ,class:false},
			{name: "" , positionX:145 ,positionY:520 ,class:false},
			/*二列目右*/
			{name: "" , positionX:222 ,positionY:45 ,class:false},
			{name: "" , positionX:222 ,positionY:130 ,class:false},
			{name: "" , positionX:222 ,positionY:195 ,class:false},
			{name: "" , positionX:222 ,positionY:260 ,class:false},
			{name: "" , positionX:222 ,positionY:325 ,class:false},
			{name: "" , positionX:222 ,positionY:390 ,class:false},
			{name: "" , positionX:222 ,positionY:455 ,class:false},
			{name: "" , positionX:222 ,positionY:520 ,class:false},
			/*三列目左*/
			{name: "" , positionX:250 ,positionY:45 ,class:false},
			{name: "" , positionX:250 ,positionY:130 ,class:false},
			{name: "" , positionX:250 ,positionY:195 ,class:false},
			{name: "" , positionX:250 ,positionY:260 ,class:false},
			{name: "" , positionX:250 ,positionY:325 ,class:false},
			{name: "" , positionX:250 ,positionY:390 ,class:false},
			{name: "" , positionX:250 ,positionY:455 ,class:false},
			{name: "" , positionX:250 ,positionY:520 ,class:false},
			/*三列目右*/
			{name: "" , positionX:327 ,positionY:45 ,class:false},
			{name: "" , positionX:327 ,positionY:130 ,class:false},
			{name: "" , positionX:327 ,positionY:195 ,class:false},
			{name: "" , positionX:327 ,positionY:260 ,class:false},
			{name: "" , positionX:327 ,positionY:325 ,class:false},
			{name: "" , positionX:327 ,positionY:390 ,class:false},
			{name: "" , positionX:327 ,positionY:455 ,class:false},
			{name: "" , positionX:327 ,positionY:520 ,class:false},
			/*四列目左*/
			{name: "" , positionX:355 ,positionY:45 ,class:false},
			{name: "" , positionX:355 ,positionY:130 ,class:false},
			{name: "" , positionX:355 ,positionY:195 ,class:false},
			{name: "" , positionX:355 ,positionY:260 ,class:false},
			{name: "" , positionX:355 ,positionY:325 ,class:false},
			{name: "" , positionX:355 ,positionY:390 ,class:false},
			{name: "" , positionX:355 ,positionY:455 ,class:false},
			{name: "" , positionX:355 ,positionY:520 ,class:false},
			/*四列目右*/
			{name: "" , positionX:432 ,positionY:45 ,class:false},
			{name: "" , positionX:432 ,positionY:130 ,class:false},
			{name: "" , positionX:432 ,positionY:195 ,class:false},
			{name: "" , positionX:432 ,positionY:260 ,class:false},
			{name: "" , positionX:432 ,positionY:325 ,class:false},
			{name: "" , positionX:432 ,positionY:390 ,class:false},
			{name: "" , positionX:432 ,positionY:455 ,class:false},
			{name: "中村史" , positionX:432 ,positionY:520 ,class:false},
			/*五列目左*/
			{name: "" , positionX:460 ,positionY:45 ,class:false},
			{name: "" , positionX:460 ,positionY:195 ,class:false},
			{name: "" , positionX:460 ,positionY:260 ,class:false},
			{name: "" , positionX:460 ,positionY:325 ,class:false},
			{name: "" , positionX:460 ,positionY:390 ,class:false},
			{name: "" , positionX:460 ,positionY:455 ,class:false},
			{name: "" , positionX:460 ,positionY:520 ,class:false},
			/*五列目右*/
			{name: "" , positionX:537 ,positionY:45 ,class:false},
			{name: "" , positionX:537 ,positionY:195 ,class:false},
			{name: "" , positionX:537 ,positionY:260 ,class:false},
			{name: "" , positionX:537 ,positionY:325 ,class:false},
			{name: "" , positionX:537 ,positionY:390 ,class:false},
			{name: "" , positionX:537 ,positionY:455 ,class:false},
			{name: "" , positionX:537 ,positionY:520 ,class:false},
			/*六列目左*/
			{name: "" , positionX:565 ,positionY:45 ,class:false},
			{name: "" , positionX:565 ,positionY:195 ,class:false},
			{name: "" , positionX:565 ,positionY:260 ,class:false},
			{name: "" , positionX:565 ,positionY:325 ,class:false},
			{name: "" , positionX:565 ,positionY:390 ,class:false},
			{name: "" , positionX:565 ,positionY:455 ,class:false},
			{name: "" , positionX:565 ,positionY:520 ,class:false},
			/*六列目右*/
			{name: "" , positionX:642 ,positionY:45 ,class:false},
			{name: "" , positionX:642 ,positionY:195 ,class:false},
			{name: "" , positionX:642 ,positionY:260 ,class:false},
			{name: "" , positionX:642 ,positionY:325 ,class:false},
			{name: "" , positionX:642 ,positionY:390 ,class:false},
			{name: "" , positionX:642 ,positionY:455 ,class:false},
			{name: "" , positionX:642 ,positionY:520 ,class:false},
			/*七列目左*/
			{name: "" , positionX:678 ,positionY:130 ,class:false},
			{name: "" , positionX:678 ,positionY:195 ,class:false},
			{name: "" , positionX:678 ,positionY:260 ,class:false},
			{name: "" , positionX:678 ,positionY:325 ,class:false},
			{name: "" , positionX:678 ,positionY:390 ,class:false},
			{name: "" , positionX:678 ,positionY:455 ,class:false},
			{name: "" , positionX:678 ,positionY:520 ,class:false},
			/*七列目右*/
			{name: "" , positionX:754 ,positionY:130 ,class:false},
			{name: "" , positionX:754 ,positionY:195 ,class:false},
			{name: "" , positionX:754 ,positionY:260 ,class:false},
			{name: "" , positionX:754 ,positionY:325 ,class:false},
			{name: "清水" , positionX:754 ,positionY:390 ,class:false},
			{name: "" , positionX:754 ,positionY:455 ,class:false},
			{name: "" , positionX:754 ,positionY:520 ,class:false},
			/*八列目左*/
			{name: "" , positionX:807 ,positionY:130 ,class:false},
			{name: "" , positionX:807 ,positionY:260 ,class:false},
			{name: "" , positionX:807 ,positionY:390 ,class:false},
			{name: "" , positionX:807 ,positionY:520 ,class:false},
			/*八列目上*/
			{name: "" , positionX:834 ,positionY:103 ,class:true},
			{name: "" , positionX:834 ,positionY:233 ,class:true},
			{name: "" , positionX:834 ,positionY:363 ,class:true},
			{name: "" , positionX:834 ,positionY:493 ,class:true},
			/*八列目下*/
			{name: "" , positionX:834 ,positionY:193 ,class:true},
			{name: "" , positionX:834 ,positionY:323 ,class:true},
			{name: "" , positionX:834 ,positionY:453 ,class:true},
			{name: "" , positionX:834 ,positionY:583 ,class:true},
			/*八列目右*/
			{name: "" , positionX:897 ,positionY:130 ,class:false},
			{name: "" , positionX:897 ,positionY:260 ,class:false},
			{name: "" , positionX:897 ,positionY:390 ,class:false},
			{name: "" , positionX:897 ,positionY:520 ,class:false},
			/*九列目左*/
			{name: "" , positionX:923 ,positionY:130 ,class:false},
			{name: "" , positionX:923 ,positionY:260 ,class:false},
			{name: "" , positionX:923 ,positionY:390 ,class:false},
			{name: "" , positionX:923 ,positionY:520 ,class:false},
			/*九列目上*/
			{name: "" , positionX:950 ,positionY:103 ,class:true},
			{name: "" , positionX:950 ,positionY:233 ,class:true},
			{name: "" , positionX:950 ,positionY:363 ,class:true},
			{name: "" , positionX:950 ,positionY:493 ,class:true},
			/*九列目下*/
			{name: "" , positionX:950 ,positionY:193 ,class:true},
			{name: "" , positionX:950 ,positionY:323 ,class:true},
			{name: "" , positionX:950 ,positionY:453 ,class:true},
			{name: "" , positionX:950 ,positionY:583 ,class:true},
			/*九列目右*/
			{name: "" , positionX:1013 ,positionY:130 ,class:false},
			{name: "" , positionX:1013 ,positionY:260 ,class:false},
			{name: "" , positionX:1013 ,positionY:390 ,class:false},
			{name: "" , positionX:1013 ,positionY:520 ,class:false},
			/*十列目左*/
			{name: "" , positionX:1039 ,positionY:260 ,class:false},
			{name: "" , positionX:1039 ,positionY:390 ,class:false},
			{name: "" , positionX:1039 ,positionY:520 ,class:false},
			/*十列目上*/
			{name: "和田" , positionX:1066 ,positionY:233 ,class:true},
			{name: "" , positionX:1066 ,positionY:363 ,class:true},
			{name: "" , positionX:1066 ,positionY:493 ,class:true},
			/*十列目下*/
			{name: "" , positionX:1066 ,positionY:323 ,class:true},
			{name: "" , positionX:1066 ,positionY:453 ,class:true},
			{name: "" , positionX:1066 ,positionY:583 ,class:true},
			/*十列目右*/
			{name: "" , positionX:1129 ,positionY:260 ,class:false},
			{name: "" , positionX:1129 ,positionY:390 ,class:false},
			{name: "" , positionX:1129 ,positionY:520 ,class:false},
			/*十一列目左*/
			{name: "" , positionX:1155 ,positionY:260 ,class:false},
			{name: "" , positionX:1155 ,positionY:390 ,class:false},
			{name: "" , positionX:1155 ,positionY:520 ,class:false},
			/*十一列目上*/
			{name: "斎藤哲" , positionX:1182 ,positionY:233 ,class:true},
			{name: "" , positionX:1182 ,positionY:363 ,class:true},
			{name: "" , positionX:1182 ,positionY:493 ,class:true},
			/*十一列目下*/
			{name: "" , positionX:1182 ,positionY:323 ,class:true},
			{name: "" , positionX:1182 ,positionY:453 ,class:true},
			{name: "" , positionX:1182 ,positionY:583 ,class:true},
			/*十一列目右*/
			{name: "" , positionX:1245 ,positionY:260 ,class:false},
			{name: "" , positionX:1245 ,positionY:390 ,class:false},
			{name: "" , positionX:1245 ,positionY:520 ,class:false},
			/*十二列目左*/
			{name: "" , positionX:1271 ,positionY:260 ,class:false},
			{name: "" , positionX:1271 ,positionY:390 ,class:false},
			{name: "" , positionX:1271 ,positionY:520 ,class:false},
			/*十二列目上*/
			{name: "" , positionX:1298 ,positionY:233 ,class:true},
			{name: "" , positionX:1298 ,positionY:363 ,class:true},
			{name: "" , positionX:1298 ,positionY:493 ,class:true},
			/*十二列目下*/
			{name: "" , positionX:1298 ,positionY:323 ,class:true},
			{name: "" , positionX:1298 ,positionY:453 ,class:true},
			{name: "" , positionX:1298 ,positionY:583 ,class:true},
			/*十二列目右*/
			{name: "" , positionX:1361 ,positionY:260 ,class:false},
			{name: "" , positionX:1361 ,positionY:390 ,class:false},
			{name: "" , positionX:1361 ,positionY:520 ,class:false}
		]
     }
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
.main {
	position: absolute;
    width: 1400px;
    height: 700px;
	margin: 0 0 0 11px;
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
	width: 50px;
	height: 50px;
	float: left;
	z-index: 999;
	position: absolute;
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
    height: 390px;
    background-color: #91cdf7;
}
/*列＿２行目以降*/
.row02 {
    margin: 50px 0 0;
}
.desk_rec02 {
    margin: 30px 30px 0;
    width: 45px;
    height: 450px;
	background-color: #91cdf7;
}

/*列＿5行目*/
.desk_rec05 {
	margin: 85px 30px 0;
	width: 45px;
	height: 395px;
	background-color: #91cdf7;
}
/*列＿6行目*/
.desk_rec06 {
	margin: 85px 30px 0;
	width: 45px;
	height: 395px;
	background-color: #91cdf7;
}

/*列＿7行目*/
.desk_rec07 {
	margin: 130px 30px 0 30px;
	width: 45px;
	height: 450px;
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
.seat-layer {
	position: relative;
    width: 1400px;
    height: 600px;
}
</style>
