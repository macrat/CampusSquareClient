using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CampusSquare
{
    class CampusSquareClient : ICampusSquareClient
    {
        private const string GET_GRADES_URL = "https://kyo-web.teu.ac.jp/campusweb/campussquare.do?_flowId=SIW0001300-flow";
        private const string LOGIN_URL = "https://kyo-web.teu.ac.jp/campusweb/campussquare.do";
        private string userName, password;

        public CampusSquareClient(string userName,string password)
        {
            var client = new CustomWebClient();
            this.userName = userName;
            this.password = password;  
            client = getCookkie(userName,password);
        }

        public string GetGradePage()
        {
            throw new NotImplementedException();
        }

        public string GetGradePage(int year)
        {
            throw new NotImplementedException();
        }

        public string GetGradePage(int year, bool firstHalf)
        {
            throw new NotImplementedException();
        }

        private CustomWebClient getCookkie(string userName, string password)
        {
            var client = new CustomWebClient();
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36");
            client.Encoding = Encoding.UTF8;
            var data = client.UploadValues(LOGIN_URL, new NameValueCollection {
                { "locale", "ja_JP" },
                { "_flowId", "USW0009000-flow"},
                { "requestparames", ""},
                { "userName", userName},
                { "password", password},
            });
            var res = System.Text.Encoding.UTF8.GetString(data);
            var result = client.DownloadString(GET_GRADES_URL);

            Console.WriteLine(result);
            return client;
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
    }

}
