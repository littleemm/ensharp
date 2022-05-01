using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace LibraryProgram
{
    class NaverBookAPI
    {
        private static string CLIENT_ID = "Gy_693vcZVxD7SqwKVzr";
        private static string CLIENT_SECRET = "SdGR7yh_9b";


        public string OpenAPI()
        {
            string query = "노인과 바다"; // 검색할 문자열
            string url = "https://openapi.naver.com/v1/search/book?query=" + query; // 결과가 JSON 포맷
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", CLIENT_ID); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", CLIENT_SECRET);       // 클라이언트 시크릿

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();
            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string requestResult = reader.ReadToEnd();

                return requestResult;

            }
            else
            {
                Console.WriteLine("Error 발생=" + status);
                return "ERROR";
            }
        }

        private void EditResultData()
        {
            string requestResult = OpenAPI();
            requestResult = requestResult.Replace("<b>", "");
            requestResult = requestResult.Replace("</b>", "");
            requestResult = requestResult.Replace(",", "");
            requestResult = requestResult.Replace("title", "  NAME   ");
            requestResult = requestResult.Replace("price", "  PRICE  ");
            requestResult = requestResult.Replace("author", " AUTHOR  ");
            requestResult = requestResult.Replace("publisher", "PUBLISHER");
            requestResult = requestResult.Replace("pubdate", " PUBDATE ");
            requestResult = requestResult.Replace("isbn", "  ISBN   ");

            var parseJson = JObject.Parse(requestResult);
            var countsOfDisplay = Convert.ToInt32(parseJson["display"]);

            List<string> resultList = new List<string>();
            for (int i = 0; i < countsOfDisplay; i++)
            {

                var title = parseJson["items"][i]["title"].ToString();
                var price = parseJson["items"][i]["price"].ToString();
                var author = parseJson["items"][i]["author"].ToString();
                var publisher = parseJson["items"][i]["publisher"].ToString();
                var pubdate = parseJson["items"][i]["pubdate"].ToString();
                var isbn = parseJson["items"][i]["isbn"].ToString();

                resultList.Add(price.ToString());
            }
            for (int i = 0; i < resultList.Count; i++)
            {
                Console.WriteLine(resultList[i]);
            }
        }
    }
}
