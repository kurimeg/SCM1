<template>
	<div class="main">
		<search v-if="false"></search>
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
		<!--正方形机-->
		<div class="eight_desk floatL child">
			<table>
				<tbody>
					<tr>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
							</div>
						</td>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
							</div>
						</td>
					</tr>
					<tr>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
									<div class="naisen naisen_onfree">2023</div>
								</div>
							</div>
						</td>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
							</div>
						</td>
					</tr>
					<tr>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
							</div>
						</td>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
							</div>
						</td>
					</tr>
					<tr>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
									<div class="naisen naisen_onfree">2027</div>
								</div>
							</div>
						</td>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
							</div>
						</td>
					</tr>
				</tbody>
			</table>
		</div>
		<!--正方形机-->
		<div class="nine_desk floatL child">
			<table>
				<tbody>
					<tr>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
							</div>
						</td>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
							</div>
						</td>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
									<div class="naisen naisen_onfree">2031</div>
								</div>
							</div>
						</td>
					</tr>
					<tr>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
									<div class="naisen naisen_onfree">2032</div>
								</div>
							</div>
						</td>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
							</div>
						</td>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
								</div>
						</td>
					</tr>
					<tr>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
							</div>
						</td>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
								</div>
							</div>
						</td>
						<td>
							<div class="freeSpace">
								<div class="desk_square02">
									<div class="naisen naisen_onfree">2037</div>
								</div>
							</div>
						</td>
					</tr>
				</tbody>
			</table>
		</div>
		<div id="minimap"></div>
		<div class="seat-layer" >
			<seat class="seat" :class="{ seatY: seat.class }" :seat-name="seat.name" v-for="seat in seats" :key="seat.name" :style="{left: seat.positionX + 'px' ,top: seat.positionY + 'px'}"></seat>
		</div>
	</div>
</template>

<script>
import Seat from './Chart/Seat'
import Search from './Chart/Search'

export default {
   data: function () {
     return {
		seats: [
			{name: "栗原" , positionX:3 ,positionY:40 ,class:false},
            {name: "佐貫" , positionX:3 ,positionY:120 ,class:false},
            {name: "和田" , positionX:940 ,positionY:320 ,class:true}
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
	position: relative;
    width: 1420px;
    height: 600px;
    margin: 10px auto;
}
.floatL {
	float: left;
}

/*ラック*/
.rack01 {
    margin: 137px 15px 0 0;
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
	background-color: #7EA88D;
}
.desk_rec01 {
    margin: 30px 30px 0 30px;
    width: 45px;
    height: 390px;
    background-color: #7EA88D;
}
/*列＿２行目以降*/
.row02 {
    margin: 50px 0 0;
}
.desk_rec02 {
    margin: 30px 30px 0;
    width: 45px;
    height: 450px;
	background-color: #7EA88D;
}

/*列＿5行目*/
.desk_rec05 {
	margin: 85px 30px 0;
	width: 45px;
	height: 395px;
	background-color: #7EA88D;
}
/*列＿6行目*/
.desk_rec06 {
	margin: 85px 30px 0;
	width: 45px;
	height: 395px;
	background-color: #7EA88D;
}

/*列＿7行目*/
.desk_rec07 {
	margin: 130px 30px 0 30px;
	width: 45px;
	height: 450px;
	background-color: #7EA88D;
}

/*フリースペース_正方形*/
.freeSpace {
	width: 110px;
	max-height: 130px;
	position: relative;
	margin-left: 8px;
}
.desk_square02 {
    position: relative;
    left: 25px;
	margin: 25px 0 25px 0;
	width: 60px;
	height: 60px;
	background-color: #7EA88D;
}
.nine_desk {
	margin: 215px 0 0;
}
.eight_desk{
    margin: 105px 0 0 20px;
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
	position: absolute;
    width: 1420px;
    height: 600px;
    margin: 10px auto;
}
.seat{
	position: absolute;
	float: left;
}
</style>
