using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using MSScriptControl;
using Newtonsoft.Json;

namespace YutuskiTranslate
{
    internal class Google
    {
        //  谷歌翻译引擎
        public string GoogleTranslate(string text, string fromLanguage, string toLanguage)
        {
            var cc = new CookieContainer();

            var GoogleTransBaseUrl = "https://translate.google.cn/";

            var BaseResultHtml = GetResultHtml(GoogleTransBaseUrl, cc, "");

            var re = new Regex(@"(?<=TKK=)(.*?)(?=\);)");

            var TKKStr = re.Match(BaseResultHtml) + ")"; //在返回的HTML中正则匹配TKK的JS代码

            var TKK = ExecuteScript(TKKStr, TKKStr); //执行TKK代码，得到TKK值

            var GetTkkJS = File.ReadAllText("./GetTk.js");

            var tk = ExecuteScript("tk(\"" + text + "\",\"" + TKK + "\")", GetTkkJS);

            var googleTransUrl = "https://translate.google.cn/translate_a/single?client=t&sl=" + fromLanguage + "&tl=" +
                                 toLanguage +
                                 "&hl=en&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&ie=UTF-8&oe=UTF-8&otf=1&ssel=0&tsel=0&kc=1&tk=" +
                                 tk + "&q=" + HttpUtility.UrlEncode(text);

            var ResultHtml = GetResultHtml(googleTransUrl, cc, "https://translate.google.cn/");

            dynamic TempResult = JsonConvert.DeserializeObject(ResultHtml);

            string ResultText = Convert.ToString(TempResult[0][0][0]);

            return ResultText;
        }


        public string GetResultHtml(string url, CookieContainer cookie, string refer)
        {
            var html = "";

            var webRequest = WebRequest.Create(url) as HttpWebRequest;

            webRequest.Method = "GET";

            webRequest.CookieContainer = cookie;

            webRequest.Referer = refer;

            webRequest.Timeout = 20000;

            webRequest.Headers.Add("X-Requested-With:XMLHttpRequest");

            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";

            webRequest.UserAgent = " Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";

            using (var webResponse = (HttpWebResponse) webRequest.GetResponse())
            {
                using (var reader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {
                    html = reader.ReadToEnd();

                    reader.Close();

                    webResponse.Close();
                }
            }
            return html;
        }


        //     执行JS
        private string ExecuteScript(string sExpression, string sCode)
        {
            var scriptControl = new ScriptControl();

            scriptControl.UseSafeSubset = true;

            scriptControl.Language = "JScript";

            scriptControl.AddCode(sCode);
            try
            {
                string str = scriptControl.Eval(sExpression).ToString();

                return str;
            }
            catch (Exception ex)
            {
                var dd = ex.Message;
            }

            return null;
        }
    }
}