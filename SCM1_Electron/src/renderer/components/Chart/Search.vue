<template>
    <div class="search-layer">
        <img src="../../assets/images/search_icon.png" class="icon"></img>
        <div class="topChar">検索</div>
        <button type="button" class="back" @click="hideSearch">✖</button>
        <div>
            <input type="text" v-model="searchtxt" class="searchword">
                <img src="../../assets/images/search_button.png" class="button"></img>
            </input>			
        </div>
        <div class="announceChar">{{ this.searchEmp(searchtxt).searchMessage }}</div>
		<button type="button" :id="emp.EMP_NO" class="rslt" v-for="emp in this.searchEmp(searchtxt).filteredEmp" :key="emp.EMP_NO" @click="getpath">{{ emp.EMP_NO }} {{ emp.EMP_NM }}</button>
    </div>
</template>

<script>
import { mapActions, mapMutations, mapGetters ,mapState } from 'vuex'

export default {
    data: function () {
        return {
            searchtxt: null
        }
	},
	computed:{
		...mapState('getUserpath', {
			path: state => state.userPath
		}),
		...mapGetters({
      		searchEmp : 'search/searchEmp'
		})
   },
	methods:{
	   ...mapActions({
			getuserpath: 'getUserPath/getuserpath'
   		}),
		...mapMutations({
            hideSearch : 'search/hideSearch'
		}),
		
		getpath:function(event){
			this.getuserpath({
			EmpNo: event.target.id,
			Token: this.$store.state.auth.token
			})
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
	height: 30px;
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
