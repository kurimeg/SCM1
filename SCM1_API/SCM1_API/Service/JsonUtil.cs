using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace SCM1_API.Service
{
    public static class JsonUtil
    {
        public static HttpResponseMessage ReturnJson(object obj)
        {
            var responce = new HttpResponseMessage();

            // CORS（Cross-Origin Resource Sharing）の設定（クロスドメイン対策）
            responce.Headers.Add("Access-Control-Allow-Origin", "*");
            responce.Headers.Add("Access-Control-Allow-Headers", "X-Requested-With");
            responce.Headers.Add("Access-Control-Allow-Methods", "GET");
            responce.Headers.Add("Access-Control-Allow-Methods", "POST");
            responce.Headers.Add("Access-Control-Allow-Methods", "PUT");
            responce.Headers.Add("Access-Control-Allow-Methods", "DELETE");

            responce.Content = CreateHttpContentJson(obj);

            return responce;
        }

        private static HttpContent CreateHttpContentJson(object obj)
        {
            var jsonText = JsonConvert.SerializeObject(obj);
            var content = new ByteArrayContent(Encoding.UTF8.GetBytes(jsonText));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}