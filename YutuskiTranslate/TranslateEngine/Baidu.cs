using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace YutuskiTranslate
{
    /// <summary>
    ///     百度翻译API
    ///     参考文档：http://api.fanyi.baidu.com/api/trans/product/apidoc
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class BaiduFanyiJson
    {
        public string from { get; set; }
        public string to { get; set; }
        public TransResult[] trans_result { get; set; }

        public bool IsNull => string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to) && trans_result == null;
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class TransResult
    {
        //原文
        public string src { get; set; }

        //译文
        public string dst { get; set; }
    }

    //错误信息
    [JsonObject(MemberSerialization.OptOut)]
    public class ErrorResult
    {
        public string error_code { get; set; }
        public string error_msg { get; set; }

        public string ErrorMsg()
        {
            string msg;
            switch (error_code)
            {
                case "52001":
                    msg = "请求超时，请重试";
                    break;
                case "52002":
                    msg = "系统错误，请重试";
                    break;
                case "52003":
                    msg = "未授权用户，请检查您的appid 是否正确";
                    break;
                case "54000":
                    msg = "必填参数为空，请检查是否少传参数";
                    break;
                case "58000":
                    msg = "客户端IP非法，请检查个人资料里填写的IP地址是否正确";
                    break;
                case "54001":
                    msg = "签名错误，请检查您的签名生成方法";
                    break;
                case "54003":
                    msg = "访问频率受限，请降低您的调用频率";
                    break;
                case "58001":
                    msg = "译文语言方向不支持，请检查译文语言是否在语言列表里";
                    break;
                case "54004":
                    msg = "账户余额不足，请前往管理控制平台为账户充值";
                    break;
                case "54005":
                    msg = "长query请求频繁，请降低长query的发送频率，3s后再试";
                    break;
                default:
                    msg = "未知错误";
                    break;
            }

            return msg;
        }
    }

    public class BaiduTranslator
    {
        private readonly string _appid;
        private readonly string _key;

        public BaiduTranslator(string appid, string key)
        {
            _appid = appid;
            _key = key;
        }

        public static string MD5(string str, Encoding encode)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var t = md5.ComputeHash(encode.GetBytes(str));
            var sb = new StringBuilder(32);
            for (var i = 0; i < t.Length; i++)
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            return sb.ToString();
        }

        public string Translate(string q, string from, string to)
        {
            // 生成随机数
            var r = new Random(int.MaxValue);
            var salt = r.Next(1000000, int.MaxValue).ToString();

            // 生成签名
            var sign = MD5(_appid + q + salt + _key, Encoding.UTF8);

            // 请求网址
            var url = string.Format(
                "http://api.fanyi.baidu.com/api/trans/vip/translate?appid={0}&salt={1}&from={2}&to={3}&sign={4}",
                _appid, salt, from, to, sign);

            // 以POST方式发送数据(非WEB项目需要添加引用C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.Web.dll)
            var postData = string.Format("q={0}", HttpUtility.UrlEncode(q, Encoding.UTF8));
            var bytes = Encoding.UTF8.GetBytes(postData);

            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            client.Headers.Add("ContentLength", postData.Length.ToString());
            var responseData = client.UploadData(url, "POST", bytes);

            // 取得响应结果 
            var strResult = Encoding.GetEncoding("utf-8").GetString(responseData);

            var strFanyi = "";

            //反序列化结果
            var fanyi = JsonConvert.DeserializeObject<BaiduFanyiJson>(strResult);

            if (fanyi.IsNull)
            {
                var error = JsonConvert.DeserializeObject<ErrorResult>(strResult);
                Console.Write(error.ErrorMsg());
            }
            else
            {
                foreach (var tr in fanyi.trans_result)
                    strFanyi += tr.dst;
            }

            return strFanyi;
        }
    }
}