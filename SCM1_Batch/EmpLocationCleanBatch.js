//requestをrequire
var request = require('request');

//ヘッダーを定義
var headers = {
  'Content-Type':'application/json'
}

//オプションを定義
var options = {
  url: 'http://scm1test.azurewebsites.net/api/auth/',
  method: 'POST',
  headers: headers,
  json: true,
  form: {"Empno":"46012", "Password":"46012"}
}

//リクエスト送信
request(options, function (error, response, body) {
  //コールバックで色々な処理
})