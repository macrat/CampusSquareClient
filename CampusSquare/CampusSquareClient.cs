using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CampusSquare
{
    class CampusSquareClient : ICampusSquareClient
    {
        private const string URL = "https://kyo-web.teu.ac.jp/campusweb/campussquare.do";

        private CustomWebClient client;


        public CampusSquareClient(string userName, string password)
        {
            client = new CustomWebClient();

            Login(userName, password);
        }

        private void Login(string userName, string password)
        {
			if(userName == "" || password == "")
			{
				throw new ArgumentException("missing user name or password");
			}

            var result = client.Post(URL, new NameValueCollection {
                { "locale", "ja_JP" },
                { "_flowId", "USW0009000-flow"},
                { "requestparames", ""},
                { "userName", userName},
                { "password", password},
            });

			if(result.Contains("ユーザ名またはパスワードの入力に誤りがあります"))
			{
                throw new AuthenticationException();
			}
        }

        private string GetFlowExecutionKey()
        {
            var result = client.Get(URL + "?_flowId=SIW0001300-flow");

            if(result.Contains("認証エラー"))
            {
                throw new AuthenticationException();
            }

            return Regex.Match(
                result,
                "<input type=\"hidden\" name=\"_flowExecutionKey\" value=\"(.+?)\">"
            ).Groups[1].Value;
        }

        public string GetGradePage()
        {
            return GetGradePage(new NameValueCollection {
                {"spanType", "0"}
            });
        }

        public string GetGradePage(int year, bool firstHalf)
        {
            return GetGradePage(new NameValueCollection {
                {"spanType", "1"},
                {"nendo", year.ToString()},
                {"gakkiKbnCd", firstHalf ? "1" : "2"}
            });
        }

        private string GetGradePage(NameValueCollection argument)
        {
            argument.Add("status", "1");
            argument.Add("_flowExecutionKey", GetFlowExecutionKey());
            argument.Add("_eventId", "display");

            return client.Post(URL, argument);
        }
    }


    class CustomWebClient : WebClient
    {
        private CookieContainer cookieContainer = new CookieContainer();

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = cookieContainer;
            }
            return request;
        }

        public void InitializeHeader()
        {
            Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36");
            Encoding = Encoding.UTF8;
        }

        public string Post(string address, NameValueCollection data)
        {
            InitializeHeader();
            return System.Text.Encoding.UTF8.GetString(
                UploadValues(address, data)
            );
        }

        public string Get(string address)
        {
            InitializeHeader();
            return DownloadString(address);
        }
    }
}
