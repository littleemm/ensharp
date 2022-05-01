using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace LibraryProgram
{
    class NaverBookAPI
    {
        private static string CLIENT_ID = "Gy_693vcZVxD7SqwKVzr";
        private static string CLIENT_SECRET = "SdGR7yh_9b";
        
        public void OpenAPI()
        {
            string query = "노인과 바다"; // 검색할 문자열
            string url = "https://openapi.naver.com/v1/search/book?query" + query; // 결과가 JSON 포맷
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("X-Naver-Client-Id", CLIENT_ID); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", CLIENT_SECRET);       // 클라이언트 시크릿
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string status = response.StatusCode.ToString();
                if (status == "OK")
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    string text = reader.ReadToEnd();
                    Console.WriteLine(text);
                }
                else
                {
                    Console.WriteLine("Error 발생=" + status);
                }
            }
            catch (WebException e)
            {
                if (e.Response == null)
                {
                    throw;
                }
            }
          
        }
    }
}
