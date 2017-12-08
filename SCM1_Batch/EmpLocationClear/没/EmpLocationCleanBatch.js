//requestをrequire
var request = require('request');

//ヘッダーを定義
var headers = {
  'Accept': "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
  ,'Content-Type': "application/json"
  ,'Accept-Language': "ja,en-US;q=0.8,en;q=0.6"
  ,'Accept-Encoding': "gzip, deflate, br"
}

//オプションを定義
var options = {
  url: 'http://scm1api.azurewebsites.net/api/emplocation/ClearEmpLocationInfo',
  method: 'DELETE',
  headers: headers,
  json: { EmpNo: "DailyClearBatch" } 
}


//リクエスト送信
request.delete(options, function (error, response, body) {
  //コールバック処理
   if (error) {
            context.log(error);
        }

        if (!error && response.statusCode == 200) {
            context.log(body) // Show the HTML for the Bing homepage. 
        }
});