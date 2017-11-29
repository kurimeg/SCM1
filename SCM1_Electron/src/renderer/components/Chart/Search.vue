<template>
    <div class="form">
        <img src="../../assets/images/search_icon.png" class="icon"></img>
        <div class="topChar">検索</div>
        <button type="button" class="back">✖</button>
        <div>
            <input type="text" v-model="searchtxt" class="searchword"></input>
			<img class="button" src="../../assets/images/search_button.png" ></input>
        </div>
        <!-- 1件以上のときは選択してほしい旨、0件のときはその旨の入った文言が入る -->
        <div class="announceChar">下記候補から選択してください。</div>
        <!-- 件数フラグで回すか？リスト？ -->
        <button type="button" class="rslt">48006 斎藤哲良</button>
        <button type="button" class="rslt">48010 佐貫寧乙</button>
    </div>
</template>

<script>
export default {
    data: function () {
        return {
            searchtxt: null
        }
    }
}
</script>

<style scoped>
body {
	margin: 0;
	font-family: 'ＭＳ Ｐ明朝', 'MS PMincho','ヒラギノ明朝 Pro W3', 'Hiragino Mincho Pro', 'serif'sans-serif;
}
.floatL {
	float: left;
}
input:focus{
 outline:none;
}
button:focus{
 outline:none;
}
.form{
	position: absolute;
	z-index: 2;
	overflow: hidden;	
	width: 400px;
	border: 5px solid #28a1f7;
	border-radius: 15px;
	background-color: #5d5d5d;
}
.icon{
	margin-left: 3px; 
	margin-top: 3px;
	width: 50px;
	height: 50px;
	float: left;
}
.button{
	position: absolute;
	margin-left: -40px;
	margin-top: 2px;
	width: 30px;
	height: 30px;
	cursor: pointer;
}
.back{
	width: 30px;
	height: 30px;
	float: left;
	margin-left: 250px; 
	margin-top: 10px;
	background: none;
	color: #ffffff;
	font-size: 20px;
	font-family: 'Century Gothic';
	border-style: none;
	cursor: pointer;
}
.topChar{
	margin-left: 5px; 
	margin-top: 15px;
	color: #ffffff;
	font-size: 20px;
	float: left;
}
.announceChar{
	margin-left: 30px; 
	margin-top: 15px;
	color: #ffffff;
	font-size: 18px;
}
.searchword{
	position: relative;
	margin-left: 30px;
	width: 330px;
	height: 35px;
	text-indent: 1em;
	font-family: 'Century Gothic';
	font-size: 20px;
	background-color: #ffffff;
	color: #5d5d5d;
	border-radius: 20px;
	border-style: none;
}
.rslt{
	margin-left: 40px; 
	margin-top: 5px;
	margin-bottom: 6px;
	color: #ffffff;
	font-size: 15px;
	font-family: 'Century Gothic';
	display: block;
	border-style: none;
	background: none;
	cursor: pointer;
}
</style>
